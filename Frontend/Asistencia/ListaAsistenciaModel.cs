using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Collections.Generic;
using Huellero.Controllers;
using Huellero.Controllers.Get;
using System.Linq;
using System.Threading.Tasks;

namespace Huellero.Frontend.Asistencia
{
    public partial class ListaAsistenciaModel : Form
    {
        private readonly GetAsistencia _getAsistencia;
        private readonly GetPrograma _getPrograma;
        private List<dynamic> listaAsistencias = new List<dynamic>();

        private PrintDocument printDocument = new PrintDocument();
        private PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();

        public ListaAsistenciaModel()
        {
            InitializeComponent();
            _getAsistencia = new GetAsistencia();
            _getPrograma = new GetPrograma();

            dateFiltro.ShowCheckBox = true;
            dateFiltro.Checked = false;

            // Eventos
            this.Shown += async (sender, e) => await CargarDatosAsync();
            Buscador.TextChanged += (sender, e) => FiltrarPorTexto();
            dateFiltro.ValueChanged += (sender, e) => FiltrarPorFecha();
            cmbFiltroPrograma.SelectedIndexChanged += (sender, e) => FiltrarPorPrograma();
            dateFiltro.ValueChanged += (sender, e) => FiltrarPorFecha();

            btnImprimir.Click += BtnImprimir_Click;
            printDocument.PrintPage += PrintDocument_PrintPage;
        }

        private async Task CargarDatosAsync()
        {
            try
            {
                listaAsistencias = await _getAsistencia.GetAsistenciaAsync();
                Console.WriteLine($"Cantidad de registros obtenidos: {listaAsistencias.Count}");
                if (listaAsistencias == null || listaAsistencias.Count == 0)
                {
                    MessageBox.Show("No se encontraron registros de asistencia.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (listaAsistencias == null)
                    listaAsistencias = new List<dynamic>();

                LlenarDataGrid(listaAsistencias);
                await CargarProgramasAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LlenarDataGrid(IEnumerable<dynamic> asistencias)
        {
            dataGridViewAlumnos.Rows.Clear();
            foreach (var asistencia in asistencias)
            {
                int rowIndex = dataGridViewAlumnos.Rows.Add(
                    asistencia.NombreCompleto,
                    asistencia.Cedula,
                    asistencia.FechaHoraEntrada,
                    asistencia.FechaHoraSalida,
                    asistencia.Programa
                );
                dataGridViewAlumnos.Rows[rowIndex].Tag = asistencia;
            }
            dataGridViewAlumnos.Refresh();
        }

        private async Task CargarProgramasAsync()
        {
            try
            {
                cmbFiltroPrograma.Items.Clear();
                cmbFiltroPrograma.Items.Add("Todos");

                List<dynamic> programas = await _getPrograma.GetProgramasAsync();
                if (programas.Count == 0)
                {
                    MessageBox.Show("No se encontraron programas.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (var programa in programas)
                {
                    cmbFiltroPrograma.Items.Add(programa.NombrePrograma);
                }
                cmbFiltroPrograma.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar programas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FiltrarPorTexto()
        {
            string filtroTexto = Buscador.Text.ToLower().Trim();
            var filtrados = string.IsNullOrEmpty(filtroTexto)
                ? listaAsistencias
                : listaAsistencias.Where(a =>
                    a?.NombreCompleto?.ToString().ToLower().Contains(filtroTexto) == true ||
                    a?.Cedula?.ToString().Contains(filtroTexto) == true
                ).ToList();
            LlenarDataGrid(filtrados);
        }

        private void FiltrarPorPrograma()
        {
            string programaSeleccionado = cmbFiltroPrograma.SelectedItem?.ToString();
            var filtrados = string.IsNullOrEmpty(programaSeleccionado) || programaSeleccionado == "Todos"
                ? listaAsistencias
                : listaAsistencias.Where(a =>
                    a?.Programa?.ToString() == programaSeleccionado
                ).ToList();
            LlenarDataGrid(filtrados);
        }

        private void FiltrarPorFecha()
        {
            if (!dateFiltro.Checked) // Si el usuario desmarca la casilla, mostrar todos los registros
            {
                LlenarDataGrid(listaAsistencias);
                return;
            }

            DateTime fechaSeleccionada = dateFiltro.Value.Date;
            var filtrados = listaAsistencias.Where(a =>
                DateTime.TryParse(a?.FechaHoraEntrada?.ToString(), out DateTime fechaEntrada) &&
                fechaEntrada.Date == fechaSeleccionada
            ).ToList();

            LlenarDataGrid(filtrados);
        }

        private void BtnImprimir_Click(object sender, EventArgs e)
        {
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.ShowDialog();
        }

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font fontTitle = new Font("Arial", 16, FontStyle.Bold);
            Font font = new Font("Arial", 10);
            Pen pen = new Pen(Color.Black, 1);
            int marginLeft = 50;
            int marginTop = 50;
            int rowHeight = 25;
            int columnWidth = 150;

            // Dibujar título
            e.Graphics.DrawString("Lista de Asistencia", fontTitle, Brushes.Black, marginLeft + 150, marginTop);
            marginTop += 40;

            // Dibujar encabezados
            string[] headers = { "Nombre", "Cédula", "Entrada", "Salida", "Programa" };
            for (int i = 0; i < headers.Length; i++)
            {
                e.Graphics.DrawRectangle(pen, marginLeft + (i * columnWidth), marginTop, columnWidth, rowHeight);
                e.Graphics.DrawString(headers[i], font, Brushes.Black, marginLeft + (i * columnWidth) + 5, marginTop + 5);
            }
            marginTop += rowHeight;

            // Dibujar datos de la tabla
            foreach (DataGridViewRow row in dataGridViewAlumnos.Rows)
            {
                if (row.Cells[0].Value != null)
                {
                    for (int i = 0; i < headers.Length; i++)
                    {
                        e.Graphics.DrawRectangle(pen, marginLeft + (i * columnWidth), marginTop, columnWidth, rowHeight);
                        e.Graphics.DrawString(row.Cells[i].Value.ToString(), font, Brushes.Black, marginLeft + (i * columnWidth) + 5, marginTop + 5);
                    }
                    marginTop += rowHeight;
                }
            }
        
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
        }
}
