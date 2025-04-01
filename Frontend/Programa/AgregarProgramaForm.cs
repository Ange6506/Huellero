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
        private Timer timer;

        public AgregarProgramaForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            txtUsuario.Text = ObtenerUsuarioLogueado();

            // Asigna la hora actual al abrir la ventana
            txtHoraIngreso.Text = DateTime.Now.ToString("HH:mm"); // Formato 24h
            txtFechaIngreso.Value = DateTime.Now;

            // Opcional: Actualizar la hora en tiempo real
            IniciarTimer();
        }

        private string ObtenerUsuarioLogueado()
        {
            return Login.UsuarioActual ?? "Desconocido";
        }

        private void IniciarTimer()
        {
            timer = new Timer();
            timer.Interval = 1000; // Actualiza cada 1 segundo
            timer.Tick += (s, e) => txtHoraIngreso.Text = DateTime.Now.ToString("HH:mm");
            timer.Start();
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
                    lblMensaje.ForeColor = Color.Green;

                    this.Close(); // Cierra la ventana
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
