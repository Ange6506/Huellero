using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using Huellero.Controllers;
using Huellero.Controllers.Get;

namespace Huellero.Frontend.Usuario
{
    public partial class ListaUsuarioModel : Form
    {
        private readonly GetUsuarios _usuarioController;
        private readonly string iconoEditarPath = @"C:\Users\DESARROLLO - SISTEMA\Desktop\Huellitas\Huellero\Recursos\IconoEditar.png";

        public ListaUsuarioModel()
        {
            InitializeComponent();
            _usuarioController = new GetUsuarios();
            ConfigurarDataGridView();
            CargarUsuariosAsync();
        }

        private void ConfigurarDataGridView()
        {
            // Verifica si la columna "Editar" ya existe y elimínala
            if (dataGridView1.Columns.Contains("Editar"))
            {
                dataGridView1.Columns.Remove("Editar");
            }

            // Cambia la columna "Editar" a tipo imagen
            DataGridViewImageColumn editarColumn = new DataGridViewImageColumn
            {
                Name = "Editar",
                HeaderText = "Editar",
                ImageLayout = DataGridViewImageCellLayout.Zoom
            };

            dataGridView1.Columns.Add(editarColumn);

            // Asigna el evento de clic en celdas
            dataGridView1.CellContentClick += DataGridView1_CellContentClick;
        }

        private async void CargarUsuariosAsync()
        {
            try
            {
                List<dynamic> usuarios = await _usuarioController.GetUsuariosAsync();

                if (usuarios.Count == 0)
                {
                    MessageBox.Show("No hay usuarios para mostrar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                dataGridView1.Rows.Clear();

                Image iconoEditar = null;
                if (System.IO.File.Exists(iconoEditarPath))
                {
                    iconoEditar = Image.FromFile(iconoEditarPath);
                }

                foreach (var usuario in usuarios)
                {
                    dataGridView1.Rows.Add(
                        usuario.IdUsuario,
                        usuario.Username,
                        usuario.Password,
                        usuario.NombreRol, // 🔹 Mostrar el nombre del rol en lugar del ID
                        usuario.Estado ? "Activo" : "Inactivo",
                        iconoEditar
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verifica si se hizo clic en la columna de edición
            if (e.ColumnIndex == dataGridView1.Columns["Editar"].Index && e.RowIndex >= 0)
            {
                // Obtener datos del usuario seleccionado
                int idUsuario = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                string username = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                string password = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                string nombreRol = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                string estado = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

                // Mostrar el formulario de actualización
                UpdateUsuario updateForm = new UpdateUsuario(idUsuario, username, password, nombreRol, estado);
                updateForm.ShowDialog();
            }
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
