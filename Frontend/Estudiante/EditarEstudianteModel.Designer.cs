namespace Huellero.Frontend.Estudiante
{
    partial class EditarEstudianteModel
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label lblPrograma;
        private System.Windows.Forms.ComboBox cmbPrograma;
        private System.Windows.Forms.Label lblAsignatura;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.Label lblDiaSemana;
        private System.Windows.Forms.Label lblHoraPorDia;
        private System.Windows.Forms.NumericUpDown nudHoraPorDia;
        private System.Windows.Forms.Label lblSemanaRotacion;
        private System.Windows.Forms.NumericUpDown nudSemanaRotacion;
        private System.Windows.Forms.Label lblSemestre;
        private System.Windows.Forms.Label lblHorasSemanales;
        private System.Windows.Forms.NumericUpDown nudHorasSemanales;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Button btnGuardar;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditarEstudianteModel));
            this.lblPrograma = new System.Windows.Forms.Label();
            this.cmbPrograma = new System.Windows.Forms.ComboBox();
            this.lblAsignatura = new System.Windows.Forms.Label();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.lblDiaSemana = new System.Windows.Forms.Label();
            this.lblHoraPorDia = new System.Windows.Forms.Label();
            this.nudHoraPorDia = new System.Windows.Forms.NumericUpDown();
            this.lblSemanaRotacion = new System.Windows.Forms.Label();
            this.nudSemanaRotacion = new System.Windows.Forms.NumericUpDown();
            this.lblSemestre = new System.Windows.Forms.Label();
            this.lblHorasSemanales = new System.Windows.Forms.Label();
            this.nudHorasSemanales = new System.Windows.Forms.NumericUpDown();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnAsignatura = new System.Windows.Forms.TextBox();
            this.btnEspecialidad = new System.Windows.Forms.TextBox();
            this.btnDiaSemana = new System.Windows.Forms.TextBox();
            this.btnSemestre = new System.Windows.Forms.TextBox();
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudHoraPorDia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSemanaRotacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHorasSemanales)).BeginInit();
            this.materialCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPrograma
            // 
            this.lblPrograma.AutoSize = true;
            this.lblPrograma.BackColor = System.Drawing.Color.Transparent;
            this.lblPrograma.Location = new System.Drawing.Point(63, 132);
            this.lblPrograma.Name = "lblPrograma";
            this.lblPrograma.Size = new System.Drawing.Size(55, 13);
            this.lblPrograma.TabIndex = 0;
            this.lblPrograma.Text = "Programa:";
            // 
            // cmbPrograma
            // 
            this.cmbPrograma.Location = new System.Drawing.Point(66, 169);
            this.cmbPrograma.Name = "cmbPrograma";
            this.cmbPrograma.Size = new System.Drawing.Size(232, 21);
            this.cmbPrograma.TabIndex = 1;
            // 
            // lblAsignatura
            // 
            this.lblAsignatura.AutoSize = true;
            this.lblAsignatura.BackColor = System.Drawing.Color.Transparent;
            this.lblAsignatura.Location = new System.Drawing.Point(354, 132);
            this.lblAsignatura.Name = "lblAsignatura";
            this.lblAsignatura.Size = new System.Drawing.Size(60, 13);
            this.lblAsignatura.TabIndex = 2;
            this.lblAsignatura.Text = "Asignatura:";
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.BackColor = System.Drawing.Color.Transparent;
            this.lblEspecialidad.Location = new System.Drawing.Point(63, 215);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(70, 13);
            this.lblEspecialidad.TabIndex = 4;
            this.lblEspecialidad.Text = "Especialidad:";
            // 
            // lblDiaSemana
            // 
            this.lblDiaSemana.AutoSize = true;
            this.lblDiaSemana.BackColor = System.Drawing.Color.Transparent;
            this.lblDiaSemana.Location = new System.Drawing.Point(63, 292);
            this.lblDiaSemana.Name = "lblDiaSemana";
            this.lblDiaSemana.Size = new System.Drawing.Size(70, 13);
            this.lblDiaSemana.TabIndex = 6;
            this.lblDiaSemana.Text = "Día Semana:";
            // 
            // lblHoraPorDia
            // 
            this.lblHoraPorDia.AutoSize = true;
            this.lblHoraPorDia.BackColor = System.Drawing.Color.Transparent;
            this.lblHoraPorDia.Location = new System.Drawing.Point(354, 219);
            this.lblHoraPorDia.Name = "lblHoraPorDia";
            this.lblHoraPorDia.Size = new System.Drawing.Size(77, 13);
            this.lblHoraPorDia.TabIndex = 8;
            this.lblHoraPorDia.Text = "Horas por Día:";
            // 
            // nudHoraPorDia
            // 
            this.nudHoraPorDia.BackColor = System.Drawing.Color.White;
            this.nudHoraPorDia.Location = new System.Drawing.Point(357, 245);
            this.nudHoraPorDia.Name = "nudHoraPorDia";
            this.nudHoraPorDia.Size = new System.Drawing.Size(232, 20);
            this.nudHoraPorDia.TabIndex = 9;
            // 
            // lblSemanaRotacion
            // 
            this.lblSemanaRotacion.AutoSize = true;
            this.lblSemanaRotacion.BackColor = System.Drawing.Color.Transparent;
            this.lblSemanaRotacion.Location = new System.Drawing.Point(354, 296);
            this.lblSemanaRotacion.Name = "lblSemanaRotacion";
            this.lblSemanaRotacion.Size = new System.Drawing.Size(95, 13);
            this.lblSemanaRotacion.TabIndex = 10;
            this.lblSemanaRotacion.Text = "Semana Rotación:";
            // 
            // nudSemanaRotacion
            // 
            this.nudSemanaRotacion.Location = new System.Drawing.Point(357, 329);
            this.nudSemanaRotacion.Name = "nudSemanaRotacion";
            this.nudSemanaRotacion.Size = new System.Drawing.Size(232, 20);
            this.nudSemanaRotacion.TabIndex = 11;
            // 
            // lblSemestre
            // 
            this.lblSemestre.AutoSize = true;
            this.lblSemestre.BackColor = System.Drawing.Color.Transparent;
            this.lblSemestre.Location = new System.Drawing.Point(63, 372);
            this.lblSemestre.Name = "lblSemestre";
            this.lblSemestre.Size = new System.Drawing.Size(110, 13);
            this.lblSemestre.TabIndex = 12;
            this.lblSemestre.Text = "Semestre Académico:";
            // 
            // lblHorasSemanales
            // 
            this.lblHorasSemanales.AutoSize = true;
            this.lblHorasSemanales.BackColor = System.Drawing.Color.Transparent;
            this.lblHorasSemanales.Location = new System.Drawing.Point(354, 372);
            this.lblHorasSemanales.Name = "lblHorasSemanales";
            this.lblHorasSemanales.Size = new System.Drawing.Size(93, 13);
            this.lblHorasSemanales.TabIndex = 14;
            this.lblHorasSemanales.Text = "Horas Semanales:";
            // 
            // nudHorasSemanales
            // 
            this.nudHorasSemanales.Location = new System.Drawing.Point(357, 404);
            this.nudHorasSemanales.Name = "nudHorasSemanales";
            this.nudHorasSemanales.Size = new System.Drawing.Size(232, 20);
            this.nudHorasSemanales.TabIndex = 15;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.BackColor = System.Drawing.Color.Transparent;
            this.lblFechaInicio.Location = new System.Drawing.Point(63, 451);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(68, 13);
            this.lblFechaInicio.TabIndex = 16;
            this.lblFechaInicio.Text = "Fecha Inicio:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Location = new System.Drawing.Point(66, 482);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(232, 20);
            this.dtpFechaInicio.TabIndex = 17;
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.BackColor = System.Drawing.Color.Transparent;
            this.lblFechaFin.Location = new System.Drawing.Point(354, 451);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(57, 13);
            this.lblFechaFin.TabIndex = 18;
            this.lblFechaFin.Text = "Fecha Fin:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Location = new System.Drawing.Point(357, 482);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(232, 20);
            this.dtpFechaFin.TabIndex = 19;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(293, 522);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 20;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnAsignatura
            // 
            this.btnAsignatura.Location = new System.Drawing.Point(357, 170);
            this.btnAsignatura.Name = "btnAsignatura";
            this.btnAsignatura.Size = new System.Drawing.Size(232, 20);
            this.btnAsignatura.TabIndex = 23;
            // 
            // btnEspecialidad
            // 
            this.btnEspecialidad.Location = new System.Drawing.Point(66, 245);
            this.btnEspecialidad.Name = "btnEspecialidad";
            this.btnEspecialidad.Size = new System.Drawing.Size(232, 20);
            this.btnEspecialidad.TabIndex = 22;
            // 
            // btnDiaSemana
            // 
            this.btnDiaSemana.Location = new System.Drawing.Point(66, 329);
            this.btnDiaSemana.Name = "btnDiaSemana";
            this.btnDiaSemana.Size = new System.Drawing.Size(232, 20);
            this.btnDiaSemana.TabIndex = 24;
            // 
            // btnSemestre
            // 
            this.btnSemestre.Location = new System.Drawing.Point(66, 404);
            this.btnSemestre.Name = "btnSemestre";
            this.btnSemestre.Size = new System.Drawing.Size(232, 20);
            this.btnSemestre.TabIndex = 25;
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.materialCard1.Controls.Add(this.pictureBox3);
            this.materialCard1.Controls.Add(this.pictureBox1);
            this.materialCard1.Controls.Add(this.btnGuardar);
            this.materialCard1.Controls.Add(this.dtpFechaFin);
            this.materialCard1.Controls.Add(this.lblFechaFin);
            this.materialCard1.Controls.Add(this.dtpFechaInicio);
            this.materialCard1.Controls.Add(this.lblFechaInicio);
            this.materialCard1.Controls.Add(this.nudHorasSemanales);
            this.materialCard1.Controls.Add(this.lblHorasSemanales);
            this.materialCard1.Controls.Add(this.btnSemestre);
            this.materialCard1.Controls.Add(this.btnDiaSemana);
            this.materialCard1.Controls.Add(this.lblSemestre);
            this.materialCard1.Controls.Add(this.nudSemanaRotacion);
            this.materialCard1.Controls.Add(this.lblSemanaRotacion);
            this.materialCard1.Controls.Add(this.nudHoraPorDia);
            this.materialCard1.Controls.Add(this.lblHoraPorDia);
            this.materialCard1.Controls.Add(this.label1);
            this.materialCard1.Controls.Add(this.lblPrograma);
            this.materialCard1.Controls.Add(this.lblDiaSemana);
            this.materialCard1.Controls.Add(this.btnEspecialidad);
            this.materialCard1.Controls.Add(this.btnAsignatura);
            this.materialCard1.Controls.Add(this.lblEspecialidad);
            this.materialCard1.Controls.Add(this.cmbPrograma);
            this.materialCard1.Controls.Add(this.lblAsignatura);
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(265, 49);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(637, 590);
            this.materialCard1.TabIndex = 26;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.Location = new System.Drawing.Point(593, 8);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(37, 31);
            this.pictureBox3.TabIndex = 28;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.PictureBox3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Location = new System.Drawing.Point(285, 17);
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
            this.label1.Location = new System.Drawing.Point(239, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Registrar Estudiante";
            // 
            // EditarEstudianteModel
            // 
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1161, 685);
            this.Controls.Add(this.materialCard1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "EditarEstudianteModel";
            this.Text = "Editar Estudiante";
            ((System.ComponentModel.ISupportInitialize)(this.nudHoraPorDia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSemanaRotacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHorasSemanales)).EndInit();
            this.materialCard1.ResumeLayout(false);
            this.materialCard1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.TextBox btnAsignatura;
        private System.Windows.Forms.TextBox btnEspecialidad;
        private System.Windows.Forms.TextBox btnDiaSemana;
        private System.Windows.Forms.TextBox btnSemestre = new System.Windows.Forms.TextBox();
        private MaterialSkin.Controls.MaterialCard materialCard1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}
