namespace Huellero.Frontend.Programa
{
    partial class UpdatePrograma
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtPrograma = new System.Windows.Forms.TextBox();
            this.lblPrograma = new System.Windows.Forms.Label();
            this.lblFechaIngreso = new System.Windows.Forms.Label();
            this.lblHoraIngreso = new System.Windows.Forms.Label();
            this.txtHoraIngreso = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.btnEditar = new System.Windows.Forms.Button();
            this.txtFechaIngreso = new System.Windows.Forms.DateTimePicker();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtPrograma
            // 
            this.txtPrograma.Location = new System.Drawing.Point(158, 44);
            this.txtPrograma.Name = "txtPrograma";
            this.txtPrograma.Size = new System.Drawing.Size(200, 20);
            this.txtPrograma.TabIndex = 2;
            // 
            // lblPrograma
            // 
            this.lblPrograma.Location = new System.Drawing.Point(52, 47);
            this.lblPrograma.Name = "lblPrograma";
            this.lblPrograma.Size = new System.Drawing.Size(100, 23);
            this.lblPrograma.TabIndex = 3;
            this.lblPrograma.Text = "Programa";
            // 
            // lblFechaIngreso
            // 
            this.lblFechaIngreso.Location = new System.Drawing.Point(52, 95);
            this.lblFechaIngreso.Name = "lblFechaIngreso";
            this.lblFechaIngreso.Size = new System.Drawing.Size(100, 23);
            this.lblFechaIngreso.TabIndex = 4;
            this.lblFechaIngreso.Text = "Fecha Ingreso";
            // 
            // lblHoraIngreso
            // 
            this.lblHoraIngreso.Location = new System.Drawing.Point(52, 150);
            this.lblHoraIngreso.Name = "lblHoraIngreso";
            this.lblHoraIngreso.Size = new System.Drawing.Size(100, 23);
            this.lblHoraIngreso.TabIndex = 6;
            this.lblHoraIngreso.Text = "Hora Ingreso";
            // 
            // txtHoraIngreso
            // 
            this.txtHoraIngreso.Location = new System.Drawing.Point(158, 137);
            this.txtHoraIngreso.Name = "txtHoraIngreso";
            this.txtHoraIngreso.Size = new System.Drawing.Size(200, 20);
            this.txtHoraIngreso.TabIndex = 8;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Location = new System.Drawing.Point(52, 198);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(100, 23);
            this.lblUsuario.TabIndex = 9;
            this.lblUsuario.Text = "Usuario";
            // 
            // lblEstado
            // 
            this.lblEstado.Location = new System.Drawing.Point(52, 242);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(100, 23);
            this.lblEstado.TabIndex = 11;
            this.lblEstado.Text = "Estado";
            // 
            // cbEstado
            // 
            this.cbEstado.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cbEstado.Location = new System.Drawing.Point(159, 239);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(200, 21);
            this.cbEstado.TabIndex = 12;
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(141, 289);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 13;
            this.btnEditar.Text = "Agregar";
            this.btnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // txtFechaIngreso
            // 
            this.txtFechaIngreso.Location = new System.Drawing.Point(158, 89);
            this.txtFechaIngreso.Name = "txtFechaIngreso";
            this.txtFechaIngreso.Size = new System.Drawing.Size(200, 20);
            this.txtFechaIngreso.TabIndex = 14;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(159, 198);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(199, 20);
            this.txtUsuario.TabIndex = 15;
            // 
            // UpdatePrograma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 407);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.txtFechaIngreso);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.cbEstado);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtHoraIngreso);
            this.Controls.Add(this.lblHoraIngreso);
            this.Controls.Add(this.lblFechaIngreso);
            this.Controls.Add(this.lblPrograma);
            this.Controls.Add(this.txtPrograma);
            this.Name = "UpdatePrograma";
            this.Text = "UpdatePrograma";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPrograma;
        private System.Windows.Forms.Label lblPrograma;
        private System.Windows.Forms.Label lblFechaIngreso;
        private System.Windows.Forms.Label lblHoraIngreso;
        private System.Windows.Forms.TextBox txtHoraIngreso;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.DateTimePicker txtFechaIngreso;
        private System.Windows.Forms.TextBox txtUsuario;
    }
}