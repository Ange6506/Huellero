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
        private DateTimePicker dtpFechaIngreso;
        private DateTimePicker dtpHoraIngreso;
        private ComboBox cmbEstado;
        private Button btnAgregar;
        private Label lblMensaje;
        private readonly AddPrograma programaService = new AddPrograma();

        public AgregarProgramaForm()
        {
            this.Text = "Agregar Programa";
            this.Size = new Size(400, 400);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;

            Label lblPrograma = new Label() { Text = "Programa", Top = 20, Left = 20, Width = 150 };
            txtPrograma = new TextBox() { Top = 45, Left = 20, Width = 300 };

            Label lblFechaIngreso = new Label() { Text = "Fecha Ingreso", Top = 80, Left = 20, Width = 150 };
            dtpFechaIngreso = new DateTimePicker() { Top = 105, Left = 20, Width = 300, Format = DateTimePickerFormat.Short };

            Label lblHoraIngreso = new Label() { Text = "Hora Ingreso", Top = 140, Left = 20, Width = 150 };
            dtpHoraIngreso = new DateTimePicker() { Top = 165, Left = 20, Width = 300, Format = DateTimePickerFormat.Time, ShowUpDown = true };

            Label lblUsuario = new Label() { Text = "Usuario", Top = 200, Left = 20, Width = 150 };
            txtUsuario = new TextBox() { Top = 225, Left = 20, Width = 300, ReadOnly = true };
            txtUsuario.Text = ObtenerUsuarioLogueado();

            Label lblEstado = new Label() { Text = "Estado", Top = 260, Left = 20, Width = 150 };
            cmbEstado = new ComboBox() { Top = 285, Left = 20, Width = 300, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbEstado.Items.AddRange(new string[] { "Activo", "Inactivo" });

            btnAgregar = new Button() { Text = "Agregar", Top = 320, Left = 20, Width = 300 };
            btnAgregar.Click += new EventHandler(async (sender, e) => await AgregarProgramaAsync());

            lblMensaje = new Label() { Top = 350, Left = 20, Width = 300, ForeColor = Color.Red };

            this.Controls.Add(lblPrograma);
            this.Controls.Add(lblFechaIngreso);
            this.Controls.Add(dtpFechaIngreso);
            this.Controls.Add(lblHoraIngreso);
            this.Controls.Add(dtpHoraIngreso);
            this.Controls.Add(lblUsuario);
            this.Controls.Add(btnAgregar);
            this.Controls.Add(lblEstado);
            this.Controls.Add(cmbEstado);
            this.Controls.Add(txtPrograma);
            this.Controls.Add(txtUsuario);
            this.Controls.Add(lblMensaje);
        }

        private string ObtenerUsuarioLogueado()
        {
            return Login.UsuarioActual ?? "Desconocido";
        }

        private async Task AgregarProgramaAsync()
        {
            lblMensaje.Text = "";
            lblMensaje.ForeColor = Color.Red;

            if (string.IsNullOrWhiteSpace(txtPrograma.Text) || cmbEstado.SelectedItem == null)
            {
                lblMensaje.Text = "Por favor, complete todos los campos.";
                return;
            }

            string programa = txtPrograma.Text.Trim();
            string fechaIngreso = dtpFechaIngreso.Value.ToString("yyyy-MM-dd");
            string horaIngreso = dtpHoraIngreso.Value.ToString("HH:mm:ss");
            string usuario = txtUsuario.Text.Trim();
            string estado = cmbEstado.SelectedItem.ToString();

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
                    cmbEstado.SelectedIndex = -1;
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
    }
}
