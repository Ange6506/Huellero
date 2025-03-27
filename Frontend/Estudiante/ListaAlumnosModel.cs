using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using DPFP;
using Huellero.Controllers;
using Huellero.Controllers.Update;
using Huellero.Controllers.Login;

namespace Huellero.Frontend.Estudiante
{
    public partial class ListaAlumnosModel : Form
    {
        private readonly GetEstudiante getEstudiante = new GetEstudiante();
        private readonly HuellaUpdate huellaUpdater = new HuellaUpdate();
        private DPFP.Template Template;
        private byte[] huellaEstudiante = null;
        private List<GetEstudiante.EstudianteDTO> listaEstudiantes = new List<GetEstudiante.EstudianteDTO>();

        public ListaAlumnosModel()
        {
            InitializeComponent();
            ConfigurarEventos();
            _ = CargarDatosAsync().ContinueWith(task => MostrarTodosEstudiantes(), TaskScheduler.FromCurrentSynchronizationContext());
        }
        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim().ToLower();

            foreach (DataGridViewRow row in dgvAlumnos.Rows)
            {
                if (row.Cells["dataGridViewTextBoxColumn1"].Value != null &&
                    row.Cells["dataGridViewTextBoxColumn2"].Value != null)
                {
                    string nombre = row.Cells["dataGridViewTextBoxColumn1"].Value.ToString().ToLower();
                    string identificacion = row.Cells["dataGridViewTextBoxColumn2"].Value.ToString().ToLower();

                    row.Visible = nombre.Contains(filtro) || identificacion.Contains(filtro);
                }
            }
        }

        private void TxtBuscar_Enter(object sender, EventArgs e)
        {
            if (txtBuscar.Text == "Buscar por nombre o identificación...")
            {
                txtBuscar.Text = "";
                txtBuscar.ForeColor = System.Drawing.Color.Black;
            }
        }

        private void TxtBuscar_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                txtBuscar.Text = "Buscar por nombre o identificación...";
                txtBuscar.ForeColor = System.Drawing.Color.Gray;
            }
        }

        private void ConfigurarEventos()
        {
            txtBuscar.Text = "Buscar por nombre o identificación...";
            txtBuscar.ForeColor = Color.Gray;

            txtBuscar.Enter += (sender, e) =>
            {
                if (txtBuscar.Text == "Buscar por nombre o identificación...")
                {
                    txtBuscar.Text = "";
                    txtBuscar.ForeColor = Color.Black;
                }
            };

            txtBuscar.Leave += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtBuscar.Text))
                {
                    txtBuscar.Text = "Buscar por nombre o identificación...";
                    txtBuscar.ForeColor = Color.Gray;
                    MostrarTodosEstudiantes();
                }
            };

            txtBuscar.TextChanged += (sender, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtBuscar.Text))
                {
                    MostrarTodosEstudiantes();
                }
                else
                {
                    FiltrarEstudiantes(txtBuscar.Text);
                }
            };

            dgvAlumnos.CellClick += DgvAlumnos_CellClick;
        }

        private async Task CargarDatosAsync()
        {
            try
            {
                listaEstudiantes = new List<GetEstudiante.EstudianteDTO>(await getEstudiante.ObtenerEstudiantesAsync());
                if (listaEstudiantes.Count > 0)
                {
                    MostrarTodosEstudiantes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los estudiantes: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MostrarTodosEstudiantes()
        {
            FiltrarEstudiantes("");
        }

        private void FiltrarEstudiantes(string filtro)
        {
            dgvAlumnos.Rows.Clear();
            string rutaRecursos = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Recursos");
            string rutaEditar = Path.Combine(rutaRecursos, "IconoEditar.png");
            string rutaHuella = Path.Combine(rutaRecursos, "IconoHuella.png");


            foreach (var estudiante in listaEstudiantes)
            {
                if (string.IsNullOrWhiteSpace(filtro) ||
                    estudiante.NombreCompleto.IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0 ||
                    estudiante.Identificacion.IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    int rowIndex = dgvAlumnos.Rows.Add(
                        estudiante.NombreCompleto,
                        estudiante.Identificacion,
                        estudiante.Programa,
                        estudiante.FechaInicio.ToShortDateString(),
                        estudiante.FechaFinal.ToShortDateString()
                    );
                    dgvAlumnos.Rows[rowIndex].Tag = estudiante;

                    // Verificar y cargar imagen correctamente
                    if (File.Exists(rutaEditar))
                    {
                        dgvAlumnos.Rows[rowIndex].Cells["Editar"].Value = Image.FromFile(rutaEditar);
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el ícono de edición.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    if (File.Exists(rutaHuella))
                    {
                        dgvAlumnos.Rows[rowIndex].Cells["Capturar_Huella"].Value = Image.FromFile(rutaHuella);
                    }
                    else
                    {
                        MessageBox.Show("No se encontró el ícono de huella.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }


        private void DgvAlumnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == dgvAlumnos.Columns["Editar"].Index)
                    EditarEstudiante(e.RowIndex);
                else if (e.ColumnIndex == dgvAlumnos.Columns["Capturar_Huella"].Index)
                    CapturarHuella(e.RowIndex);
            }
        }

        private void EditarEstudiante(int rowIndex)
        {
            if (dgvAlumnos.Rows[rowIndex].Tag is GetEstudiante.EstudianteDTO estudiante)
            {
                using (EditarEstudianteModel editarForm = new EditarEstudianteModel(
                    estudiante.IdEstudiante, estudiante.Programa, estudiante.Asignatura, estudiante.Especialidad,
                    estudiante.SemestreAcademico, estudiante.DiasSemana, estudiante.SemanasDeRotacion,
                    estudiante.HorasPorDia, estudiante.NumeroHorasSemanales, estudiante.FechaInicio, estudiante.FechaFinal))
                {
                    if (editarForm.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Cambios guardados correctamente para: " + estudiante.NombreCompleto);
                        _ = CargarDatosAsync();
                    }
                }
            }
            else
            {
                MessageBox.Show("Error: No se pudo obtener el estudiante.");
            }
        }

        private void CapturarHuella(int rowIndex)
        {
            if (dgvAlumnos.Rows[rowIndex].Tag is GetEstudiante.EstudianteDTO estudiante)
            {
                CapturaHuella captura = new CapturaHuella();
                captura.OnTemplate += (template) =>
                {
                    this.Invoke(new Action(async () =>
                    {
                        Template = template;
                        if (Template != null)
                        {
                            huellaEstudiante = Template.Bytes;
                            bool exito = await huellaUpdater.GuardarHuellaEnBD(estudiante.IdEstudiante, huellaEstudiante);
                            MessageBox.Show(exito ? $"Huella registrada para {estudiante.NombreCompleto}" : "Error al registrar la huella.",
                                exito ? "Éxito" : "Error", MessageBoxButtons.OK, exito ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("La plantilla de huella no es válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }));
                };
                captura.ShowDialog();
            }
            else
            {
                MessageBox.Show("Error: No se pudo obtener el estudiante.");
            }
        }

        private void Cerrar_Sesion_Click(object sender, EventArgs e)
        {
            // Confirmar si el usuario quiere volver al menú principal 
            DialogResult result = MessageBox.Show(
                "¿Deseas volver al menú principal?",
                "Cerrar Sesión",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // Ocultar la ventana actual en lugar de cerrarla
                this.Hide();

                // Abrir el formulario principal (Main)
                main mainForm = new main();
                mainForm.ShowDialog();

                // Cerrar la ventana actual después de volver al Main
                this.Close();
            }
        

    }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
