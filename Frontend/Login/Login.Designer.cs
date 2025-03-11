namespace Huellero.Frontend.Login
{
    partial class Login
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.Button btnLogin;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // txtUsuario
            this.txtUsuario.Location = new System.Drawing.Point(50, 30);
            this.txtUsuario.Width = 200;
            this.txtUsuario.Text = "Usuario";
            this.txtUsuario.ForeColor = System.Drawing.Color.Gray;
            this.txtUsuario.GotFocus += RemoverPlaceholder;
            this.txtUsuario.LostFocus += AgregarPlaceholder;

            // txtContraseña
            this.txtContraseña.Location = new System.Drawing.Point(50, 70);
            this.txtContraseña.Width = 200;
            this.txtContraseña.Text = "Contraseña";
            this.txtContraseña.ForeColor = System.Drawing.Color.Gray;
            this.txtContraseña.GotFocus += RemoverPlaceholder;
            this.txtContraseña.LostFocus += AgregarPlaceholder;

            // btnLogin
            this.btnLogin.Text = "Iniciar sesión";
            this.btnLogin.Location = new System.Drawing.Point(50, 110);
            this.btnLogin.Click += btnLogin_Click;

            // Login Form
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.txtContraseña);
            this.Controls.Add(this.btnLogin);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
        }
    }
}
