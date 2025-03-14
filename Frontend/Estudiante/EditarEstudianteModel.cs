using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Huellero.Controllers;

namespace Huellero.Frontend.Estudiante
{
    public partial class EditarEstudianteModel : Form
    {
        private string nombreEstudiante;
        private string identificacion;

        public string Programa { get; private set; }
        public string Asignatura { get; private set; }
        public string Especialidad { get; private set; }
        public string SemestreAcademico { get; private set; }
        public string DiaSemana { get; private set; }
        public int SemanaRotacion { get; private set; }
        public int HoraPorDia { get; private set; }
        public int NumeroHorasSemanales { get; private set; }
        public DateTime FechaInicio { get; private set; }
        public DateTime FechaFinal { get; private set; }
        public bool Guardado { get; private set; } = false;
        public int IdEstudiante { get; internal set; }

        public EditarEstudianteModel(int idEstudiante, string programa, string asignatura, string especialidad,
                                     string semestre, string diaSemana, int semanaRotacion, int horaPorDia,
                                     int numeroHorasSemanales, DateTime fechaInicio, DateTime fechaFinal)
        {
            InitializeComponent();
            CargarProgramas();

            this.IdEstudiante = idEstudiante;

            cmbPrograma.Text = programa;
            btnSemestre.Text = semestre;
            btnAsignatura.Text = asignatura;
            btnEspecialidad.Text = especialidad;
            btnDiaSemana.Text = diaSemana;

            nudSemanaRotacion.Value = semanaRotacion;
            nudHoraPorDia.Value = horaPorDia;
            nudHorasSemanales.Value = numeroHorasSemanales;

            dtpFechaInicio.Value = fechaInicio;
            dtpFechaFin.Value = fechaFinal;
        }

        public EditarEstudianteModel(string nombreEstudiante, string identificacion)
        {
            this.nombreEstudiante = nombreEstudiante;
            this.identificacion = identificacion;
        }

        public EditarEstudianteModel(string identificacion)
        {
            this.identificacion = identificacion;
        }

        private async void CargarProgramas()
        {
            try
            {
                GetPrograma programaService = new GetPrograma();
                List<dynamic> programas = await programaService.GetProgramasAsync();

                if (programas.Count == 0)
                {
                    MessageBox.Show("No se encontraron programas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (var programa in programas)
                {
                    cmbPrograma.Items.Add(programa.NombrePrograma);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar programas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            Programa = cmbPrograma.Text;
            SemestreAcademico = btnSemestre.Text;
            Asignatura = btnAsignatura.Text;
            Especialidad = btnEspecialidad.Text;
            DiaSemana = btnDiaSemana.Text;
            SemanaRotacion = (int)nudSemanaRotacion.Value;
            HoraPorDia = (int)nudHoraPorDia.Value;
            NumeroHorasSemanales = (int)nudHorasSemanales.Value;
            FechaInicio = dtpFechaInicio.Value;
            FechaFinal = dtpFechaFin.Value;

            var updateEstudiante = new UpdateEstudiante();
            bool isUpdated = await updateEstudiante.EditarEstudianteAsync(
                IdEstudiante, Programa, SemestreAcademico, Asignatura,
                Especialidad, DiaSemana,
                SemanaRotacion, HoraPorDia, NumeroHorasSemanales, FechaInicio, FechaFinal
            );

            if (isUpdated)
            {
                Guardado = true;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Hubo un error al guardar los cambios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }

      

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();

        }
    }
}