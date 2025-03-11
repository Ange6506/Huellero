using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Huellero.Controllers.Post;

namespace Huellero
{
    public partial class AgregarRolForm : Form
    {
        private readonly AddRol rolService = new AddRol();

        public AgregarRolForm()
        {
            InitializeComponent();
            btnAgregar.Click += async (sender, e) => await AgregarRolAsync();
        }

        private async Task AgregarRolAsync()
        {
            lblMensaje.Text = "";
            lblMensaje.ForeColor = System.Drawing.Color.Red;

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                lblMensaje.Text = "Por favor, ingrese una descripción.";
                return;
            }

            string descripcion = txtDescripcion.Text.Trim();

            try
            {
                int? idRol = await rolService.AgregarRolAsync(descripcion);

                if (idRol != null)
                {
                    MessageBox.Show($"Rol agregado con éxito. ID: {idRol}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
                    lblMensaje.Text = "Rol agregado con éxito.";

                    txtDescripcion.Clear();
                }
                else
                {
                    lblMensaje.Text = "Error al agregar el rol.";
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = $"Error: {ex.Message}";
            }
        }
    }
}
