using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Huellero.Controllers;
using Huellero.Controllers.Get;

namespace Huellero.Frontend.Usuario
{
    public partial class ListaUsuarioModel : Form
    {
        private readonly GetUsuarios _usuarioController;
        private readonly string rutaEditar = Path.Combine(Application.StartupPath, "Recursos", "IconoEditar.png");
        private Image iconoEditar;

        public ListaUsuarioModel()
        {
            InitializeComponent();
            _usuarioController = new GetUsuarios();
            CargarIconoEditar();
            ConfigurarDataGridView();
            CargarUsuariosAsync();
        }

        private void CargarIconoEditar()
        {
            if (File.Exists(rutaEditar))
            {
                using (FileStream stream = new FileStream(rutaEditar, FileMode.Open, FileAccess.Read))
                {
                    iconoEditar = Image.FromStream(stream);
                }
            }
            else
            {
                MessageBox.Show("El icono de edición no se encontró en: " + rutaEditar, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ConfigurarDataGridView()
        {
            if (dataGridView1.Columns.Contains("Editar"))
            {
                dataGridView1.Columns.Remove("Editar");
            }

            DataGridViewImageColumn editarColumn = new DataGridViewImageColumn
            {
                Name = "Editar",
                HeaderText = "Editar",
                ImageLayout = DataGridViewImageCellLayout.Zoom
            };
            dataGridView1.Columns.Add(editarColumn);

            dataGridView1.CellContentClick -= DataGridView1_CellContentClick;
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

                foreach (var usuario in usuarios)
                {
                    dataGridView1.Rows.Add(
                        usuario.IdUsuario,
                        usuario.Username,
                        usuario.Password,
                        usuario.NombreRol,
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
            if (e.ColumnIndex == dataGridView1.Columns["Editar"].Index && e.RowIndex >= 0)
            {
                int idUsuario = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                string username = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                string password = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                string nombreRol = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                string estado = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();

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