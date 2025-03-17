using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Huellero.Frontend.Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None; // Quita el borde del formulario
            this.Region = new Region(RoundedRectangle(this.ClientRectangle, 20)); // Aplica esquinas redondeadas

        }
        private GraphicsPath RoundedRectangle(Rectangle bounds, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            Rectangle arc = new Rectangle(bounds.Location, new Size(diameter, diameter));

            // Esquinas redondeadas
            path.AddArc(arc, 180, 90);
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }


        private void RemoverPlaceholder(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (txt.ForeColor == Color.Gray)
            {
                txt.Text = "";
                txt.ForeColor = Color.Black;
                if (txt == txtContraseña)
                {
                    txt.PasswordChar = '*';
                }
            }
        }

        private void AgregarPlaceholder(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                if (txt == txtUsuario)
                {
                    txt.Text = "Usuario";
                }
                else if (txt == txtContraseña)
                {
                    txt.Text = "Contraseña";
                    txt.PasswordChar = '\0';
                }
                txt.ForeColor = Color.Gray;
            }
        }





        private async void BtnLogin_Click_1(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;

            if (usuario == "Usuario" || contraseña == "Contraseña")
            {
                MessageBox.Show("Por favor, ingresa tus credenciales.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Huellero.Controllers.Login.Login loginController = new Huellero.Controllers.Login.Login();
            bool esValido = await loginController.IniciarSesionAsync(usuario, contraseña); // 🔹 Llamada asíncrona

            if (esValido)
            {
                MessageBox.Show("Inicio de sesión exitoso", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                main mainForm = new main();
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
    }
}
}
