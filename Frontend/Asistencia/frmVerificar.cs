using DPFP;
using DPFP.Verification;
using Huellero.Backend.DatabaseConnection;
using Npgsql;
using System;
using System.IO;
using System.Windows.Forms;

namespace Huellero
{
    public partial class frmVerificar : CaptureForm
    {
        private DPFP.Verification.Verification Verificator;
        private readonly DatabaseConnection _databaseConnection;

        public frmVerificar()
        {
            InitializeComponent();
            Verificator = new DPFP.Verification.Verification();
            _databaseConnection = new DatabaseConnection();
        }

        protected override void Init()
        {
            base.Init();
            base.Text = "Verificación de huella digital";
            UpdateStatus(0);
        }

        private void UpdateStatus(int FAR)
        {
            SetStatus($"False Accept Rate (FAR) = {FAR}");
        }

        protected override void Process(DPFP.Sample Sample)
        {
            base.Process(Sample);
            DPFP.FeatureSet feature = ExtractFeatures(Sample, DPFP.Processing.DataPurpose.Verification);

            if (feature == null) return;

            try
            {
                using (var conn = _databaseConnection.GetConnectionAsync().GetAwaiter().GetResult())
                {
                    string sql = "SELECT id_estudiantes, nombre_del_estudiante, huella FROM estudiantes";

                    using (var cmd = new NpgsqlCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            byte[] huellaBytes = (byte[])reader["huella"];
                            string nombre = reader["nombre_del_estudiante"].ToString();
                            int idEstudiante = reader.GetInt32(0);

                            using (MemoryStream stream = new MemoryStream(huellaBytes))
                            {
                                DPFP.Template templateFromDb = new DPFP.Template(stream);
                                DPFP.Verification.Verification.Result result = new DPFP.Verification.Verification.Result();
                                Verificator.Verify(feature, templateFromDb, ref result);
                                UpdateStatus(result.FARAchieved);

                                if (result.Verified)
                                {
                                    reader.Close();
                                    RegistrarAsistencia(idEstudiante, conn);

                                    var msg = new Form();
                                    var timer = new System.Windows.Forms.Timer();
                                    timer.Interval = 3000;
                                    timer.Tick += (s, e) => { msg.Close(); timer.Stop(); };
                                    timer.Start();
                                    MessageBox.Show(msg, $"Huella verificada: {nombre}", "Información");

                                    return;
                                }
                            }
                        }
                    }
                }

                var msgNoMatch = new Form();
                var timerNoMatch = new System.Windows.Forms.Timer();
                timerNoMatch.Interval = 3000;
                timerNoMatch.Tick += (s, e) => { msgNoMatch.Close(); timerNoMatch.Stop(); };
                timerNoMatch.Start();
                MessageBox.Show(msgNoMatch, "Huella no reconocida.", "Información");
            }
            catch (Exception ex)
            {
                var msgError = new Form();
                var timerError = new System.Windows.Forms.Timer();
                timerError.Interval = 3000;
                timerError.Tick += (s, e) => { msgError.Close(); timerError.Stop(); };
                timerError.Start();
                MessageBox.Show(msgError, "Error al verificar la huella: " + ex.Message, "Error");
            }
        }

        private void RegistrarAsistencia(int idEstudiante, NpgsqlConnection conn)
        {
            try
            {
                string estudianteQuery = "SELECT id_est_x_semestre FROM est_x_semestre WHERE id_estudiante = @id";
                int? idEstXSemestre = null;

                using (var estudianteCmd = new NpgsqlCommand(estudianteQuery, conn))
                {
                    estudianteCmd.Parameters.AddWithValue("id", idEstudiante);
                    using (var reader = estudianteCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            idEstXSemestre = reader.GetInt32(0);
                        }
                    }
                }

                if (!idEstXSemestre.HasValue)
                {
                    var msg = new Form();
                    var timer = new System.Windows.Forms.Timer();
                    timer.Interval = 3000;
                    timer.Tick += (s, e) => { msg.Close(); timer.Stop(); };
                    timer.Start();
                    MessageBox.Show(msg, "El estudiante no está registrado en un semestre.", "Información");
                    return;
                }

                string asistenciaQuery = @"SELECT id_asistencia, fecha_hora_entrada FROM asistencia 
                                           WHERE id_est_x_semestre = @id 
                                           AND fecha_hora_salida IS NULL 
                                           ORDER BY fecha_hora_entrada DESC LIMIT 1";

                int? idAsistencia = null;
                DateTime? fechaEntrada = null;

                using (var asistenciaCmd = new NpgsqlCommand(asistenciaQuery, conn))
                {
                    asistenciaCmd.Parameters.AddWithValue("id", idEstXSemestre);
                    using (var reader = asistenciaCmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            idAsistencia = reader.GetInt32(0);
                            fechaEntrada = reader.GetDateTime(1);
                        }
                    }
                }

                if (idAsistencia.HasValue && fechaEntrada.HasValue)
                {
                    DateTime ahora = DateTime.Now;
                    TimeSpan diferenciaTiempo = ahora - fechaEntrada.Value;

                    if (fechaEntrada.Value.Date < ahora.Date)
                    {
                        string resetQuery = "UPDATE asistencia SET fecha_hora_salida = NULL WHERE id_asistencia = @id";
                        using (var resetCmd = new NpgsqlCommand(resetQuery, conn))
                        {
                            resetCmd.Parameters.AddWithValue("id", idAsistencia.Value);
                            resetCmd.ExecuteNonQuery();
                        }
                    }
                    else if (diferenciaTiempo.TotalMinutes < 5)
                    {
                        var msg = new Form();
                        var timer = new System.Windows.Forms.Timer();
                        timer.Interval = 3000;
                        timer.Tick += (s, e) => { msg.Close(); timer.Stop(); };
                        timer.Start();
                        MessageBox.Show(msg, "Debe esperar al menos 5 minutos antes de registrar su salida.", "Información");
                        return;
                    }
                    else
                    {
                        string updateQuery = "UPDATE asistencia SET fecha_hora_salida = NOW() WHERE id_asistencia = @id";
                        using (var updateCmd = new NpgsqlCommand(updateQuery, conn))
                        {
                            updateCmd.Parameters.AddWithValue("id", idAsistencia.Value);
                            updateCmd.ExecuteNonQuery();
                        }

                        var msg = new Form();
                        var timer = new System.Windows.Forms.Timer();
                        timer.Interval = 3000;
                        timer.Tick += (s, e) => { msg.Close(); timer.Stop(); };
                        timer.Start();
                        MessageBox.Show(msg, "Salida registrada exitosamente.", "Información");
                        return;
                    }
                }

                string insertQuery = @"INSERT INTO asistencia (fecha_hora_entrada, id_est_x_semestre) 
                                       VALUES (NOW(), @id) RETURNING id_asistencia";

                using (var insertCmd = new NpgsqlCommand(insertQuery, conn))
                {
                    insertCmd.Parameters.AddWithValue("id", idEstXSemestre);
                    int newId = (int)insertCmd.ExecuteScalar();

                    var msg = new Form();
                    var timer = new System.Windows.Forms.Timer();
                    timer.Interval = 3000;
                    timer.Tick += (s, e) => { msg.Close(); timer.Stop(); };
                    timer.Start();
                    MessageBox.Show(msg, $"Entrada registrada exitosamente. ID Asistencia: {newId}", "Información");
                }
            }
            catch (Exception ex)
            {
                var msg = new Form();
                var timer = new System.Windows.Forms.Timer();
                timer.Interval = 3000;
                timer.Tick += (s, e) => { msg.Close(); timer.Stop(); };
                timer.Start();
                MessageBox.Show(msg, "Error al registrar asistencia: " + ex.Message, "Error");
            }
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
