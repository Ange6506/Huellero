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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdatePrograma));
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
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.materialCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // txtPrograma
            // 
            this.txtPrograma.Location = new System.Drawing.Point(47, 177);
            this.txtPrograma.Name = "txtPrograma";
            this.txtPrograma.Size = new System.Drawing.Size(225, 20);
            this.txtPrograma.TabIndex = 2;
            // 
            // lblPrograma
            // 
            this.lblPrograma.BackColor = System.Drawing.Color.Transparent;
            this.lblPrograma.Location = new System.Drawing.Point(44, 151);
            this.lblPrograma.Name = "lblPrograma";
            this.lblPrograma.Size = new System.Drawing.Size(100, 23);
            this.lblPrograma.TabIndex = 3;
            this.lblPrograma.Text = "Programa";
            // 
            // lblFechaIngreso
            // 
            this.lblFechaIngreso.BackColor = System.Drawing.Color.Transparent;
            this.lblFechaIngreso.Location = new System.Drawing.Point(44, 211);
            this.lblFechaIngreso.Name = "lblFechaIngreso";
            this.lblFechaIngreso.Size = new System.Drawing.Size(100, 23);
            this.lblFechaIngreso.TabIndex = 4;
            this.lblFechaIngreso.Text = "Fecha Ingreso";
            // 
            // lblHoraIngreso
            // 
            this.lblHoraIngreso.BackColor = System.Drawing.Color.Transparent;
            this.lblHoraIngreso.Location = new System.Drawing.Point(44, 273);
            this.lblHoraIngreso.Name = "lblHoraIngreso";
            this.lblHoraIngreso.Size = new System.Drawing.Size(100, 23);
            this.lblHoraIngreso.TabIndex = 6;
            this.lblHoraIngreso.Text = "Hora Ingreso";
            // 
            // txtHoraIngreso
            // 
            this.txtHoraIngreso.Location = new System.Drawing.Point(47, 299);
            this.txtHoraIngreso.Name = "txtHoraIngreso";
            this.txtHoraIngreso.Size = new System.Drawing.Size(225, 20);
            this.txtHoraIngreso.TabIndex = 8;
            // 
            // lblUsuario
            // 
            this.lblUsuario.BackColor = System.Drawing.Color.Transparent;
            this.lblUsuario.Location = new System.Drawing.Point(44, 332);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(100, 23);
            this.lblUsuario.TabIndex = 9;
            this.lblUsuario.Text = "Usuario";
            // 
            // lblEstado
            // 
            this.lblEstado.BackColor = System.Drawing.Color.Transparent;
            this.lblEstado.Location = new System.Drawing.Point(44, 393);
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
            this.cbEstado.Location = new System.Drawing.Point(47, 415);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(225, 21);
            this.cbEstado.TabIndex = 12;
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(125, 463);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 13;
            this.btnEditar.Text = "Agregar";
            this.btnEditar.Click += new System.EventHandler(this.BtnEditar_Click);
            // 
            // txtFechaIngreso
            // 
            this.txtFechaIngreso.Location = new System.Drawing.Point(47, 237);
            this.txtFechaIngreso.Name = "txtFechaIngreso";
            this.txtFechaIngreso.Size = new System.Drawing.Size(225, 20);
            this.txtFechaIngreso.TabIndex = 14;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(47, 358);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(225, 20);
            this.txtUsuario.TabIndex = 15;
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.materialCard1.Controls.Add(this.pictureBox3);
            this.materialCard1.Controls.Add(this.pictureBox1);
            this.materialCard1.Controls.Add(this.btnEditar);
            this.materialCard1.Controls.Add(this.txtUsuario);
            this.materialCard1.Controls.Add(this.cbEstado);
            this.materialCard1.Controls.Add(this.label1);
            this.materialCard1.Controls.Add(this.lblEstado);
            this.materialCard1.Controls.Add(this.txtFechaIngreso);
            this.materialCard1.Controls.Add(this.lblPrograma);
            this.materialCard1.Controls.Add(this.txtPrograma);
            this.materialCard1.Controls.Add(this.lblUsuario);
            this.materialCard1.Controls.Add(this.lblFechaIngreso);
            this.materialCard1.Controls.Add(this.txtHoraIngreso);
            this.materialCard1.Controls.Add(this.lblHoraIngreso);
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(295, 23);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(327, 519);
            this.materialCard1.TabIndex = 16;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Location = new System.Drawing.Point(127, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 54);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(109, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Editar Programa";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.Location = new System.Drawing.Point(286, 5);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(37, 31);
            this.pictureBox3.TabIndex = 29;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.PictureBox3_Click);
            // 
            // UpdatePrograma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(859, 565);
            this.Controls.Add(this.materialCard1);
            this.Name = "UpdatePrograma";
            this.Text = "UpdatePrograma";
            this.materialCard1.ResumeLayout(false);
            this.materialCard1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

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
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}