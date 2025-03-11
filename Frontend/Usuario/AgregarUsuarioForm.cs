using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Huellero.Controllers;

namespace Huellero
{
    public partial class AgregarUsuarioForm : Form
    {
        private readonly GetRol rolService = new GetRol();
        private readonly AddUsuario usuarioService = new AddUsuario();
        private Dictionary<string, int> rolesDictionary = new Dictionary<string, int>();

        public AgregarUsuarioForm()
        {
            InitializeComponent();
            _ = CargarRolesAsync();
        }

        private async Task CargarRolesAsync()
        {
            try
            {
                List<dynamic> rolesDinamicos = await rolService.GetRolesAsync();
                cmbRoles.Items.Clear();
                rolesDictionary.Clear();

                foreach (var rol in rolesDinamicos)
                {
                    rolesDictionary.Add(rol.Descripcion, rol.IdRol);
                    cmbRoles.Items.Add(rol.Descripcion);
                }

                if (rolesDictionary.Count == 0)
                {
                    lblMensaje.Text = "No hay roles disponibles.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task RegistrarUsuarioAsync()
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text) || cmbRoles.SelectedItem == null || cmbEstado.SelectedItem == null)
            {
                lblMensaje.Text = "Por favor, complete todos los campos.";
                lblMensaje.ForeColor = Color.Red;
                return;
            }

            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string estado = cmbEstado.SelectedItem.ToString();
            string rolSeleccionado = cmbRoles.SelectedItem.ToString();

            if (!rolesDictionary.TryGetValue(rolSeleccionado, out int idRol))
            {
                lblMensaje.Text = "Error al obtener el ID del rol.";
                lblMensaje.ForeColor = Color.Red;
                return;
            }

            int? idUsuario = await usuarioService.AgregarUsuarioAsync(idRol, username, password, estado);

            if (idUsuario.HasValue)
            {
                lblMensaje.ForeColor = Color.Green;
                lblMensaje.Text = "Usuario registrado con éxito.";
                txtUsername.Clear();
                txtPassword.Clear();
                cmbRoles.SelectedIndex = -1;
                cmbEstado.SelectedIndex = -1;
            }
            else
            {
                lblMensaje.ForeColor = Color.Red;
                lblMensaje.Text = "Error al registrar usuario.";
            }
        }
    }
}