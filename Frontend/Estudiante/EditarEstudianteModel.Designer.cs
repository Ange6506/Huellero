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
        private System.Windows.Forms.Button btnCancelar;

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
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAsignatura = new System.Windows.Forms.TextBox();
            this.btnEspecialidad = new System.Windows.Forms.TextBox();
            this.btnDiaSemana = new System.Windows.Forms.TextBox();
            this.btnSemestre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudHoraPorDia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSemanaRotacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHorasSemanales)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPrograma
            // 
            this.lblPrograma.AutoSize = true;
            this.lblPrograma.Location = new System.Drawing.Point(67, 101);
            this.lblPrograma.Name = "lblPrograma";
            this.lblPrograma.Size = new System.Drawing.Size(55, 13);
            this.lblPrograma.TabIndex = 0;
            this.lblPrograma.Text = "Programa:";
            // 
            // cmbPrograma
            // 
            this.cmbPrograma.Location = new System.Drawing.Point(70, 118);
            this.cmbPrograma.Name = "cmbPrograma";
            this.cmbPrograma.Size = new System.Drawing.Size(121, 21);
            this.cmbPrograma.TabIndex = 1;
            // 
            // lblAsignatura
            // 
            this.lblAsignatura.AutoSize = true;
            this.lblAsignatura.Location = new System.Drawing.Point(212, 101);
            this.lblAsignatura.Name = "lblAsignatura";
            this.lblAsignatura.Size = new System.Drawing.Size(60, 13);
            this.lblAsignatura.TabIndex = 2;
            this.lblAsignatura.Text = "Asignatura:";
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Location = new System.Drawing.Point(67, 154);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(70, 13);
            this.lblEspecialidad.TabIndex = 4;
            this.lblEspecialidad.Text = "Especialidad:";
            // 
            // lblDiaSemana
            // 
            this.lblDiaSemana.AutoSize = true;
            this.lblDiaSemana.Location = new System.Drawing.Point(212, 154);
            this.lblDiaSemana.Name = "lblDiaSemana";
            this.lblDiaSemana.Size = new System.Drawing.Size(70, 13);
            this.lblDiaSemana.TabIndex = 6;
            this.lblDiaSemana.Text = "Día Semana:";
            // 
            // lblHoraPorDia
            // 
            this.lblHoraPorDia.AutoSize = true;
            this.lblHoraPorDia.Location = new System.Drawing.Point(67, 208);
            this.lblHoraPorDia.Name = "lblHoraPorDia";
            this.lblHoraPorDia.Size = new System.Drawing.Size(77, 13);
            this.lblHoraPorDia.TabIndex = 8;
            this.lblHoraPorDia.Text = "Horas por Día:";
            // 
            // nudHoraPorDia
            // 
            this.nudHoraPorDia.BackColor = System.Drawing.Color.White;
            this.nudHoraPorDia.Location = new System.Drawing.Point(71, 224);
            this.nudHoraPorDia.Name = "nudHoraPorDia";
            this.nudHoraPorDia.Size = new System.Drawing.Size(120, 20);
            this.nudHoraPorDia.TabIndex = 9;
            // 
            // lblSemanaRotacion
            // 
            this.lblSemanaRotacion.AutoSize = true;
            this.lblSemanaRotacion.Location = new System.Drawing.Point(212, 208);
            this.lblSemanaRotacion.Name = "lblSemanaRotacion";
            this.lblSemanaRotacion.Size = new System.Drawing.Size(95, 13);
            this.lblSemanaRotacion.TabIndex = 10;
            this.lblSemanaRotacion.Text = "Semana Rotación:";
            // 
            // nudSemanaRotacion
            // 
            this.nudSemanaRotacion.Location = new System.Drawing.Point(216, 224);
            this.nudSemanaRotacion.Name = "nudSemanaRotacion";
            this.nudSemanaRotacion.Size = new System.Drawing.Size(120, 20);
            this.nudSemanaRotacion.TabIndex = 11;
            // 
            // lblSemestre
            // 
            this.lblSemestre.AutoSize = true;
            this.lblSemestre.Location = new System.Drawing.Point(68, 264);
            this.lblSemestre.Name = "lblSemestre";
            this.lblSemestre.Size = new System.Drawing.Size(110, 13);
            this.lblSemestre.TabIndex = 12;
            this.lblSemestre.Text = "Semestre Académico:";
            // 
            // lblHorasSemanales
            // 
            this.lblHorasSemanales.AutoSize = true;
            this.lblHorasSemanales.Location = new System.Drawing.Point(214, 264);
            this.lblHorasSemanales.Name = "lblHorasSemanales";
            this.lblHorasSemanales.Size = new System.Drawing.Size(93, 13);
            this.lblHorasSemanales.TabIndex = 14;
            this.lblHorasSemanales.Text = "Horas Semanales:";
            // 
            // nudHorasSemanales
            // 
            this.nudHorasSemanales.Location = new System.Drawing.Point(217, 281);
            this.nudHorasSemanales.Name = "nudHorasSemanales";
            this.nudHorasSemanales.Size = new System.Drawing.Size(120, 20);
            this.nudHorasSemanales.TabIndex = 15;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(67, 321);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(68, 13);
            this.lblFechaInicio.TabIndex = 16;
            this.lblFechaInicio.Text = "Fecha Inicio:";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Location = new System.Drawing.Point(70, 337);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(121, 20);
            this.dtpFechaInicio.TabIndex = 17;
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Location = new System.Drawing.Point(215, 321);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(57, 13);
            this.lblFechaFin.TabIndex = 18;
            this.lblFechaFin.Text = "Fecha Fin:";
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Location = new System.Drawing.Point(215, 337);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(122, 20);
            this.dtpFechaFin.TabIndex = 19;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(116, 405);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 20;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(216, 405);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 21;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAsignatura
            // 
            this.btnAsignatura.Location = new System.Drawing.Point(215, 118);
            this.btnAsignatura.Name = "btnAsignatura";
            this.btnAsignatura.Size = new System.Drawing.Size(121, 20);
            this.btnAsignatura.TabIndex = 23;
            // 
            // btnEspecialidad
            // 
            this.btnEspecialidad.Location = new System.Drawing.Point(70, 170);
            this.btnEspecialidad.Name = "btnEspecialidad";
            this.btnEspecialidad.Size = new System.Drawing.Size(120, 20);
            this.btnEspecialidad.TabIndex = 22;
            // 
            // btnDiaSemana
            // 
            this.btnDiaSemana.Location = new System.Drawing.Point(215, 170);
            this.btnDiaSemana.Name = "btnDiaSemana";
            this.btnDiaSemana.Size = new System.Drawing.Size(120, 20);
            this.btnDiaSemana.TabIndex = 24;
            // 
            // btnSemestre
            // 
            this.btnSemestre.Location = new System.Drawing.Point(70, 280);
            this.btnSemestre.Name = "btnSemestre";
            this.btnSemestre.Size = new System.Drawing.Size(120, 20);
            this.btnSemestre.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(85, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 20);
            this.label1.TabIndex = 26;
            this.label1.Text = "Editar Información del Alumno";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // EditarEstudianteModel
            // 
            this.ClientSize = new System.Drawing.Size(395, 472);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDiaSemana);
            this.Controls.Add(this.btnSemestre);
            this.Controls.Add(this.btnAsignatura);
            this.Controls.Add(this.btnEspecialidad);
            this.Controls.Add(this.lblPrograma);
            this.Controls.Add(this.cmbPrograma);
            this.Controls.Add(this.lblAsignatura);
            this.Controls.Add(this.lblEspecialidad);
            this.Controls.Add(this.lblDiaSemana);
            this.Controls.Add(this.lblHoraPorDia);
            this.Controls.Add(this.nudHoraPorDia);
            this.Controls.Add(this.lblSemanaRotacion);
            this.Controls.Add(this.nudSemanaRotacion);
            this.Controls.Add(this.lblSemestre);
            this.Controls.Add(this.lblHorasSemanales);
            this.Controls.Add(this.nudHorasSemanales);
            this.Controls.Add(this.lblFechaInicio);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.lblFechaFin);
            this.Controls.Add(this.dtpFechaFin);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "EditarEstudianteModel";
            this.Text = "Editar Estudiante";
            ((System.ComponentModel.ISupportInitialize)(this.nudHoraPorDia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSemanaRotacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHorasSemanales)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.TextBox btnAsignatura;
        private System.Windows.Forms.TextBox btnEspecialidad;
        private System.Windows.Forms.TextBox btnDiaSemana;
        private System.Windows.Forms.TextBox btnSemestre = new System.Windows.Forms.TextBox();
        private System.Windows.Forms.Label label1;
    }
}
