using System;
using System.Drawing;
using System.Windows.Forms;
using Huellero.Controllers.Login;

namespace Huellero.Frontend.Login
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
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

       



        private void BtnLogin_Click_1(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;

            if (usuario == "Usuario" || contraseña == "Contraseña")
            {
                MessageBox.Show("Por favor, ingresa tus credenciales.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Huellero.Controllers.Login.Login loginController = new Huellero.Controllers.Login.Login();
            bool esValido = loginController.IniciarSesion(usuario, contraseña);

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
