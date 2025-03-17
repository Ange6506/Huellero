using System;
using System.Windows.Forms;
using Huellero.Controllers.Update;
using System.Threading.Tasks;

namespace Huellero.Frontend.Programa
{
    public partial class UpdatePrograma : Form
    {
        public int IdPrograma { get; set; }

        public UpdatePrograma(int idPrograma, string nombrePrograma, DateTime fechaIngreso, DateTime horaIngreso, string usuario, string estado)
        {
            InitializeComponent();

            // Asignar valores
            IdPrograma = idPrograma;
            txtPrograma.Text = nombrePrograma;
            txtFechaIngreso.Value = fechaIngreso;  
            txtHoraIngreso.Text = horaIngreso.ToString("HH:mm");
            txtUsuario.Text = usuario;

            // Llenar ComboBox con las opciones
            cbEstado.Items.Add("Activo");
            cbEstado.Items.Add("Inactivo");

            // Asignar el valor de estado
            cbEstado.SelectedItem = estado.ToLower() == "true" ? "Activo" : "Inactivo";
        }

        private async void BtnEditar_Click(object sender, EventArgs e)
        {
            // Validar que el ID del programa es válido
            if (IdPrograma <= 0)
            {
                MessageBox.Show("ID del programa no válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtener valores del formulario
            string programa = txtPrograma.Text.Trim();
            string fechaIngreso = txtFechaIngreso.Value.ToString("yyyy-MM-dd");
            string horaIngreso = txtHoraIngreso.Text.Trim();
            string usuario = txtUsuario.Text.Trim();
            string estadoTexto = cbEstado.SelectedItem?.ToString() ?? "Inactivo"; // Estado por defecto si no se selecciona

            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(programa) || string.IsNullOrWhiteSpace(horaIngreso) || string.IsNullOrWhiteSpace(usuario))
            {
                MessageBox.Show("Todos los campos deben estar llenos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar formato de la hora
            if (!TimeSpan.TryParse(horaIngreso, out _))
            {
                MessageBox.Show("El formato de la hora es incorrecto. Use HH:mm.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Instanciar UpdatePrograma y ejecutar la actualización
            var updateService = new Huellero.Controllers.Update.UpdatePrograma();
            bool success = await updateService.UpdateProgramaAsync(IdPrograma, programa, fechaIngreso, horaIngreso, usuario, estadoTexto);

            if (success)
            {
                MessageBox.Show("Programa actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Cierra el formulario después de actualizar
            }
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
