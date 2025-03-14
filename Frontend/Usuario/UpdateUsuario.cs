using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Huellero.Controllers.Update;
using Huellero.Controllers;

namespace Huellero.Frontend.Usuario
{
    public partial class UpdateUsuario : Form
    {
        private readonly GetRol rolService = new GetRol();
        private readonly UpdateUsuarioController usuarioService = new UpdateUsuarioController();
        private Dictionary<string, int> rolesDictionary = new Dictionary<string, int>();

        private int _idUsuario;

        public UpdateUsuario(int idUsuario, string username, string password, string nombreRol, string estado)
        {
            InitializeComponent();
            _idUsuario = idUsuario;
            txtUsername.Text = username;
            txtPassword.Text = password;

            _ = CargarRolesAsync(nombreRol); // Ahora pasamos el nombre del rol
            cmbEstado.SelectedItem = estado;
        }

        private async Task CargarRolesAsync(string nombreRol)
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
                else
                {
                    // Buscar el rol por nombre y seleccionarlo
                    if (rolesDictionary.ContainsKey(nombreRol))
                    {
                        cmbRoles.SelectedItem = nombreRol;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obtener los valores de los campos
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();
                string estado = cmbEstado.SelectedItem?.ToString() ?? "Inactivo"; // Si no selecciona, por defecto "Inactivo"

                // Validar que el usuario ingresó un rol válido
                if (cmbRoles.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar un rol.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int idRol = rolesDictionary[cmbRoles.SelectedItem.ToString()]; // Convertir nombre a ID

                // Llamar al servicio para actualizar el usuario
                bool actualizado = await usuarioService.ActualizarUsuarioAsync(_idUsuario, username, password, idRol, estado);

                if (actualizado)
                {
                    MessageBox.Show("Usuario actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Cerrar la ventana después de actualizar
                }
                else
                {
                    MessageBox.Show("No se pudo actualizar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
