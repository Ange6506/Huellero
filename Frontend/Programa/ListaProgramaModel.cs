using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Huellero.Controllers; // Ajusta según tu espacio de nombres real
using Huellero.Controllers.Login;

namespace Huellero.Frontend.Programa
{
    public partial class ListaProgramaModel : Form
    {
        private readonly string rutaEditar = @"C:\\Users\\DESARROLLO - SISTEMA\\Desktop\\Huellitas\\Huellero\\Recursos\\IconoEditar.png";
        private readonly GetPrograma _getPrograma;

        public ListaProgramaModel()
        {
            InitializeComponent();
            _getPrograma = new GetPrograma();
        }

        private async void FormularioPrograma_Load(object sender, EventArgs e)
        {
            await CargarDatosAsync();
        }

        private async Task CargarDatosAsync()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            // Definir columnas
            dataGridView1.Columns.Add("IdPrograma", "ID"); // Agregar ID del programa
            dataGridView1.Columns["IdPrograma"].Visible = false; // Ahora sí existe y se puede ocultar
            dataGridView1.Columns.Add("NombrePrograma", "Nombre del Programa");
            dataGridView1.Columns.Add("FechaIngreso", "Fecha de Ingreso");
            dataGridView1.Columns.Add("HoraIngreso", "Hora de Ingreso");
            dataGridView1.Columns.Add("Usuario", "Usuario");
            dataGridView1.Columns.Add("Estado", "Estado");

            DataGridViewImageColumn imgColumn = new DataGridViewImageColumn
            {
                Name = "Editar",
                HeaderText = "Editar",
                ImageLayout = DataGridViewImageCellLayout.Zoom
            };
            dataGridView1.Columns.Add(imgColumn);

            var programas = await _getPrograma.GetProgramasAsync();

            foreach (var programa in programas)
            {
                dataGridView1.Rows.Add(
                    programa.IdPrograma, // Agregar ID del programa
                    programa.NombrePrograma,
                    programa.FechaIngreso,
                    programa.HoraIngreso,
                    programa.Usuario,
                    programa.Estado,
                    File.Exists(rutaEditar) ? Image.FromFile(rutaEditar) : null
                );
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;

            if (columnName == "Editar")
            {
                EditarRegistro(e.RowIndex);
            }
        }

        private void EditarRegistro(int rowIndex)
        {
            if (rowIndex < 0) return;
            int idPrograma = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["IdPrograma"].Value);
            string nombrePrograma = dataGridView1.Rows[rowIndex].Cells["NombrePrograma"].Value.ToString();
            DateTime fechaIngreso = DateTime.Parse(dataGridView1.Rows[rowIndex].Cells["FechaIngreso"].Value.ToString());
            DateTime horaIngreso = DateTime.Parse(dataGridView1.Rows[rowIndex].Cells["HoraIngreso"].Value.ToString());
            string username = dataGridView1.Rows[rowIndex].Cells["Usuario"].Value.ToString();
            string estado = dataGridView1.Rows[rowIndex].Cells["Estado"].Value.ToString();

            UpdatePrograma updateForm = new UpdatePrograma(idPrograma, nombrePrograma, fechaIngreso, horaIngreso, username, estado);
            updateForm.ShowDialog();
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