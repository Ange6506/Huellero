using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Huellero.Controllers.Post;
using Huellero.Controllers.Login;

namespace Huellero
{
    public partial class AgregarProgramaForm : Form
    {
        private readonly AddPrograma programaService = new AddPrograma();

        public AgregarProgramaForm()
        {
                InitializeComponent();
    this.StartPosition = FormStartPosition.CenterScreen;
            txtUsuario.Text = ObtenerUsuarioLogueado();
        }

        private string ObtenerUsuarioLogueado()
        {
            return Login.UsuarioActual ?? "Desconocido";
        }




        private async void BtnAgregar_Click(object sender, EventArgs e)

        {
            lblMensaje.Text = "";
            lblMensaje.ForeColor = Color.Red;

            if (string.IsNullOrWhiteSpace(txtPrograma.Text) || cbEstado.SelectedItem == null)
            {
                lblMensaje.Text = "Por favor, complete todos los campos.";
                return;
            }

            string programa = txtPrograma.Text.Trim();
            string fechaIngreso = txtFechaIngreso.Value.ToString("yyyy-MM-dd");
            string horaIngreso = txtHoraIngreso.Text.Trim();
            string usuario = txtUsuario.Text.Trim();
            string estado = cbEstado.SelectedItem.ToString();

            if (usuario == "Desconocido")
            {
                lblMensaje.Text = "No se ha identificado un usuario válido.";
                return;
            }

            try
            {
                int? idPrograma = await programaService.AgregarProgramaAsync(programa, fechaIngreso, horaIngreso, usuario, estado);

                if (idPrograma != null)
                {
                    MessageBox.Show($"Programa agregado con éxito. ID: {idPrograma}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblMensaje.ForeColor = Color.Green;
                    lblMensaje.Text = "Programa agregado con éxito.";

                    txtPrograma.Clear();
                    cbEstado.SelectedIndex = -1;
                }
                else
                {
                    lblMensaje.Text = "Error al agregar el programa.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = $"Error: {ex.Message}";
            }
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
