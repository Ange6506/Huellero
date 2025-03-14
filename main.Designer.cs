namespace Huellero
{
    partial class main
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.btnVerificar = new System.Windows.Forms.Button();
            this.btnFormularioAlumno = new System.Windows.Forms.Button();
            this.btnAgregarUsuario = new System.Windows.Forms.Button();
            this.btnAgregarPrograma = new System.Windows.Forms.Button();
            this.btnListEstudiante = new System.Windows.Forms.Button();
            this.btnListAsistencia = new System.Windows.Forms.Button();
            this.btnListPrograma = new System.Windows.Forms.Button();
            this.Cerrar_Sesion = new System.Windows.Forms.Button();
            this.ListUsuarios = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(258, 365);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(138, 30);
            this.btnRegistrar.TabIndex = 0;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click);
            // 
            // btnVerificar
            // 
            this.btnVerificar.Location = new System.Drawing.Point(258, 137);
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(138, 30);
            this.btnVerificar.TabIndex = 1;
            this.btnVerificar.Text = "Verificar";
            this.btnVerificar.Click += new System.EventHandler(this.btnVerificar_Click);
            // 
            // btnFormularioAlumno
            // 
            this.btnFormularioAlumno.Location = new System.Drawing.Point(428, 188);
            this.btnFormularioAlumno.Name = "btnFormularioAlumno";
            this.btnFormularioAlumno.Size = new System.Drawing.Size(136, 30);
            this.btnFormularioAlumno.TabIndex = 2;
            this.btnFormularioAlumno.Text = "Formulario Alumno";
            this.btnFormularioAlumno.Click += new System.EventHandler(this.btnFormularioAlumno_Click);
            // 
            // btnAgregarUsuario
            // 
            this.btnAgregarUsuario.Location = new System.Drawing.Point(428, 137);
            this.btnAgregarUsuario.Name = "btnAgregarUsuario";
            this.btnAgregarUsuario.Size = new System.Drawing.Size(136, 30);
            this.btnAgregarUsuario.TabIndex = 3;
            this.btnAgregarUsuario.Text = "Formulario Usuario";
            this.btnAgregarUsuario.Click += new System.EventHandler(this.btnAgregarUsuario_Click);
            // 
            // btnAgregarPrograma
            // 
            this.btnAgregarPrograma.Location = new System.Drawing.Point(428, 243);
            this.btnAgregarPrograma.Name = "btnAgregarPrograma";
            this.btnAgregarPrograma.Size = new System.Drawing.Size(136, 30);
            this.btnAgregarPrograma.TabIndex = 4;
            this.btnAgregarPrograma.Text = "Formulario Programa";
            this.btnAgregarPrograma.Click += new System.EventHandler(this.btnAgregarPrograma_Click);
            // 
            // btnListEstudiante
            // 
            this.btnListEstudiante.Location = new System.Drawing.Point(260, 243);
            this.btnListEstudiante.Name = "btnListEstudiante";
            this.btnListEstudiante.Size = new System.Drawing.Size(136, 30);
            this.btnListEstudiante.TabIndex = 6;
            this.btnListEstudiante.Text = "Lista Estudiantes";
            this.btnListEstudiante.Click += new System.EventHandler(this.btnListEstudiante_Click);
            // 
            // btnListAsistencia
            // 
            this.btnListAsistencia.Location = new System.Drawing.Point(258, 302);
            this.btnListAsistencia.Name = "btnListAsistencia";
            this.btnListAsistencia.Size = new System.Drawing.Size(138, 30);
            this.btnListAsistencia.TabIndex = 7;
            this.btnListAsistencia.Text = "Lista Asistencia";
            this.btnListAsistencia.Click += new System.EventHandler(this.BtnListAsistencia_Click);
            // 
            // btnListPrograma
            // 
            this.btnListPrograma.Location = new System.Drawing.Point(258, 188);
            this.btnListPrograma.Name = "btnListPrograma";
            this.btnListPrograma.Size = new System.Drawing.Size(138, 30);
            this.btnListPrograma.TabIndex = 8;
            this.btnListPrograma.Text = "Lista Programa";
            this.btnListPrograma.Click += new System.EventHandler(this.BtnListPrograma_Click);
            // 
            // Cerrar_Sesion
            // 
            this.Cerrar_Sesion.Location = new System.Drawing.Point(728, 467);
            this.Cerrar_Sesion.Name = "Cerrar_Sesion";
            this.Cerrar_Sesion.Size = new System.Drawing.Size(121, 23);
            this.Cerrar_Sesion.TabIndex = 9;
            this.Cerrar_Sesion.Text = "Cerrar Sesion";
            this.Cerrar_Sesion.UseVisualStyleBackColor = true;
            this.Cerrar_Sesion.Click += new System.EventHandler(this.Cerrar_Sesion_Click);
            // 
            // ListUsuarios
            // 
            this.ListUsuarios.Location = new System.Drawing.Point(426, 302);
            this.ListUsuarios.Name = "ListUsuarios";
            this.ListUsuarios.Size = new System.Drawing.Size(138, 30);
            this.ListUsuarios.TabIndex = 10;
            this.ListUsuarios.Text = "Lista Usuarios";
            this.ListUsuarios.Click += new System.EventHandler(this.ListUsuarios_Click);
            // 
            // main
            // 
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(873, 514);
            this.Controls.Add(this.ListUsuarios);
            this.Controls.Add(this.Cerrar_Sesion);
            this.Controls.Add(this.btnListPrograma);
            this.Controls.Add(this.btnListAsistencia);
            this.Controls.Add(this.btnListEstudiante);
            this.Controls.Add(this.btnAgregarPrograma);
            this.Controls.Add(this.btnAgregarUsuario);
            this.Controls.Add(this.btnRegistrar);
            this.Controls.Add(this.btnVerificar);
            this.Controls.Add(this.btnFormularioAlumno);
            this.Name = "main";
            this.Text = "Main";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Button btnVerificar;
        private System.Windows.Forms.Button btnFormularioAlumno;
        private System.Windows.Forms.Button btnAgregarUsuario;
        private System.Windows.Forms.Button btnAgregarPrograma;
        private System.Windows.Forms.Button btnListEstudiante;
        private System.Windows.Forms.Button btnListAsistencia;
        private System.Windows.Forms.Button btnListPrograma;
        private System.Windows.Forms.Button Cerrar_Sesion;
        private System.Windows.Forms.Button ListUsuarios;
    }
}

