using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using DPFP;
using Huellero.Controllers;
using static Huellero.CapturaHuella;

namespace Huellero
{
    public partial class FormularioAlumno : Form
    {
        private DPFP.Template Template;
        private byte[] huellaEstudiante = null;
        private readonly AddEstudiante estudianteService = new AddEstudiante();

        public EventHandler Txt_Enter { get; private set; }
        public EventHandler Txt_Leave { get; private set; }

        public delegate void OnTemplateEventHandler(DPFP.Template template);

        public FormularioAlumno()
        {
            InitializeComponent();
            CargarProgramas();
            InicializarPlaceholders();
        }

        private void InicializarPlaceholders()
        {
            ConfigurarPlaceholder(txtNombre, "Nombre del estudiante");
            ConfigurarPlaceholder(txtIdentificacion, "Identificación");
            ConfigurarPlaceholder(txtAsignatura, "Asignatura");
            ConfigurarPlaceholder(txtEspecialidad, "Especialidad");
            ConfigurarPlaceholder(txtDiasSemana, "Días de la Semana");
            ConfigurarPlaceholder(txtHorasDia, "Horas por Día");
            ConfigurarPlaceholder(txtSemanasRotacion, "Semanas de Rotación");
            ConfigurarPlaceholder(txtHorasSemanales, "Número de Horas Semanales");
            ConfigurarPlaceholder(txtSemestre, "Semestre Académico");
        }

        private void ConfigurarPlaceholder(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;
            textBox.Enter += Txt_Enter;
            textBox.Leave += Txt_Leave;
        }

        public void ProcesarTemplate(Template template)
        {
            this.Invoke(new Action(delegate ()
            {
                Template = template;
                btnRegistrarHuella.Enabled = (Template != null);

                if (Template != null)
                {
                    huellaEstudiante = Template.Bytes;
                    MessageBox.Show("La plantilla de huella está lista para la verificación.");
                    MessageBox.Show("Huella capturada correctamente");
                }
                else
                {
                    MessageBox.Show("La plantilla de huella no es válida.");
                }
            }));
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
                    comboBoxPrograma.Items.Add(programa.NombrePrograma);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar programas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnRegistrarHuella_Click_1(object sender, EventArgs e)
        {
            CapturaHuella captura = new CapturaHuella();
            captura.OnTemplate += this.ProcesarTemplate;
            captura.ShowDialog();
        }

        private async void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || txtNombre.Text == "Nombre del estudiante" ||
             string.IsNullOrWhiteSpace(txtIdentificacion.Text) || txtIdentificacion.Text == "Identificación" ||
             string.IsNullOrWhiteSpace(txtAsignatura.Text) || txtAsignatura.Text == "Asignatura" ||
             string.IsNullOrWhiteSpace(txtEspecialidad.Text) || txtEspecialidad.Text == "Especialidad" ||
             string.IsNullOrWhiteSpace(txtDiasSemana.Text) || txtDiasSemana.Text == "Días de la Semana" ||
             string.IsNullOrWhiteSpace(txtHorasDia.Text) || txtHorasDia.Text == "Horas por Día" ||
             string.IsNullOrWhiteSpace(txtSemanasRotacion.Text) || txtSemanasRotacion.Text == "Semanas de Rotación" ||
             string.IsNullOrWhiteSpace(txtHorasSemanales.Text) || txtHorasSemanales.Text == "Número de Horas Semanales" ||
             string.IsNullOrWhiteSpace(txtSemestre.Text) || txtSemestre.Text == "Semestre Académico" ||
             huellaEstudiante == null || huellaEstudiante.Length == 0 ||
             comboBoxPrograma.SelectedItem == null)
            {
                MessageBox.Show("Todos los campos deben estar llenos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DateTime fechaInicio = dateTimePickerInicio.Value;
                DateTime fechaTermino = dateTimePickerFin.Value;

                if (fechaInicio > fechaTermino)
                {
                    MessageBox.Show("La fecha de inicio no puede ser posterior a la de terminación.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int horasDia = int.Parse(txtHorasDia.Text);
                int semanasRotacion = int.Parse(txtSemanasRotacion.Text);
                int horasSemanales = int.Parse(txtHorasSemanales.Text);

                var (success, message) = await estudianteService.AddEstudianteAsync(
                    huellaEstudiante,
                    txtNombre.Text.Trim(),
                    txtIdentificacion.Text.Trim(),
                    comboBoxPrograma.SelectedItem.ToString(),
                    txtAsignatura.Text.Trim(),
                    txtEspecialidad.Text.Trim(),
                    fechaInicio,
                    fechaTermino,
                    txtDiasSemana.Text.Trim(),
                    horasDia,
                    semanasRotacion,
                    horasSemanales,
                    txtSemestre.Text.Trim()
                );

                if (success)
                {
                    MessageBox.Show("Estudiante registrado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error: " + message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Las horas por día, semanas de rotación y número de horas semanales deben ser valores numéricos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistrarHuella_Click(object sender, EventArgs e)
        {
            CapturaHuella captura = new CapturaHuella();
            captura.OnTemplate += this.ProcesarTemplate;
            captura.ShowDialog();
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
