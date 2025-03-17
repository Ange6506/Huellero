using System;
using System.Windows.Forms;

namespace Huellero
{
    partial class FormularioAlumno
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox comboBoxPrograma;
        private System.Windows.Forms.DateTimePicker dateTimePickerInicio;
        private System.Windows.Forms.DateTimePicker dateTimePickerFin;
        private System.Windows.Forms.Button btnRegistrarHuella;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtAsignatura;
        private System.Windows.Forms.TextBox txtEspecialidad;
        private System.Windows.Forms.TextBox txtDiasSemana;
        private System.Windows.Forms.TextBox txtHorasDia;
        private System.Windows.Forms.TextBox txtSemanasRotacion;
        private System.Windows.Forms.TextBox txtHorasSemanales;
        private System.Windows.Forms.TextBox txtSemestre;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormularioAlumno));
            this.comboBoxPrograma = new System.Windows.Forms.ComboBox();
            this.dateTimePickerInicio = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFin = new System.Windows.Forms.DateTimePicker();
            this.btnRegistrarHuella = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtAsignatura = new System.Windows.Forms.TextBox();
            this.txtEspecialidad = new System.Windows.Forms.TextBox();
            this.txtDiasSemana = new System.Windows.Forms.TextBox();
            this.txtHorasDia = new System.Windows.Forms.TextBox();
            this.txtSemanasRotacion = new System.Windows.Forms.TextBox();
            this.txtHorasSemanales = new System.Windows.Forms.TextBox();
            this.txtSemestre = new System.Windows.Forms.TextBox();
            this.materialCard1 = new MaterialSkin.Controls.MaterialCard();
            this.txtIdentificacion = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.Asignatura = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.Semestre_academico = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Hora_dia = new System.Windows.Forms.Label();
            this.dia_semana = new System.Windows.Forms.Label();
            this.Especialidad = new System.Windows.Forms.Label();
            this.fecha_final = new System.Windows.Forms.Label();
            this.fecha_inicial = new System.Windows.Forms.Label();
            this.Programa = new System.Windows.Forms.Label();
            this.Identificacion = new System.Windows.Forms.Label();
            this.lblNombre_Estudiante = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.materialCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxPrograma
            // 
            this.comboBoxPrograma.Location = new System.Drawing.Point(55, 288);
            this.comboBoxPrograma.Name = "comboBoxPrograma";
            this.comboBoxPrograma.Size = new System.Drawing.Size(234, 21);
            this.comboBoxPrograma.TabIndex = 2;
            // 
            // dateTimePickerInicio
            // 
            this.dateTimePickerInicio.Location = new System.Drawing.Point(58, 354);
            this.dateTimePickerInicio.Name = "dateTimePickerInicio";
            this.dateTimePickerInicio.Size = new System.Drawing.Size(231, 20);
            this.dateTimePickerInicio.TabIndex = 3;
            // 
            // dateTimePickerFin
            // 
            this.dateTimePickerFin.Location = new System.Drawing.Point(59, 423);
            this.dateTimePickerFin.Name = "dateTimePickerFin";
            this.dateTimePickerFin.Size = new System.Drawing.Size(230, 20);
            this.dateTimePickerFin.TabIndex = 4;
            // 
            // btnRegistrarHuella
            // 
            this.btnRegistrarHuella.Location = new System.Drawing.Point(212, 546);
            this.btnRegistrarHuella.Name = "btnRegistrarHuella";
            this.btnRegistrarHuella.Size = new System.Drawing.Size(200, 30);
            this.btnRegistrarHuella.TabIndex = 12;
            this.btnRegistrarHuella.Text = "Registrar Huella";
            this.btnRegistrarHuella.Click += new System.EventHandler(this.btnRegistrarHuella_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(212, 595);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(200, 30);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click_1);
            // 
            // txtAsignatura
            // 
            this.txtAsignatura.Location = new System.Drawing.Point(59, 491);
            this.txtAsignatura.Name = "txtAsignatura";
            this.txtAsignatura.Size = new System.Drawing.Size(230, 20);
            this.txtAsignatura.TabIndex = 5;
            // 
            // txtEspecialidad
            // 
            this.txtEspecialidad.Location = new System.Drawing.Point(349, 170);
            this.txtEspecialidad.Name = "txtEspecialidad";
            this.txtEspecialidad.Size = new System.Drawing.Size(234, 20);
            this.txtEspecialidad.TabIndex = 6;
            // 
            // txtDiasSemana
            // 
            this.txtDiasSemana.Location = new System.Drawing.Point(349, 230);
            this.txtDiasSemana.Name = "txtDiasSemana";
            this.txtDiasSemana.Size = new System.Drawing.Size(234, 20);
            this.txtDiasSemana.TabIndex = 7;
            // 
            // txtHorasDia
            // 
            this.txtHorasDia.Location = new System.Drawing.Point(349, 289);
            this.txtHorasDia.Name = "txtHorasDia";
            this.txtHorasDia.Size = new System.Drawing.Size(234, 20);
            this.txtHorasDia.TabIndex = 8;
            // 
            // txtSemanasRotacion
            // 
            this.txtSemanasRotacion.Location = new System.Drawing.Point(351, 354);
            this.txtSemanasRotacion.Name = "txtSemanasRotacion";
            this.txtSemanasRotacion.Size = new System.Drawing.Size(234, 20);
            this.txtSemanasRotacion.TabIndex = 9;
            // 
            // txtHorasSemanales
            // 
            this.txtHorasSemanales.Location = new System.Drawing.Point(353, 423);
            this.txtHorasSemanales.Name = "txtHorasSemanales";
            this.txtHorasSemanales.Size = new System.Drawing.Size(234, 20);
            this.txtHorasSemanales.TabIndex = 10;
            // 
            // txtSemestre
            // 
            this.txtSemestre.Location = new System.Drawing.Point(354, 490);
            this.txtSemestre.Name = "txtSemestre";
            this.txtSemestre.Size = new System.Drawing.Size(234, 20);
            this.txtSemestre.TabIndex = 11;
            // 
            // materialCard1
            // 
            this.materialCard1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialCard1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.materialCard1.Controls.Add(this.txtIdentificacion);
            this.materialCard1.Controls.Add(this.txtNombre);
            this.materialCard1.Controls.Add(this.Asignatura);
            this.materialCard1.Controls.Add(this.pictureBox3);
            this.materialCard1.Controls.Add(this.Semestre_academico);
            this.materialCard1.Controls.Add(this.btnGuardar);
            this.materialCard1.Controls.Add(this.btnRegistrarHuella);
            this.materialCard1.Controls.Add(this.txtSemestre);
            this.materialCard1.Controls.Add(this.label3);
            this.materialCard1.Controls.Add(this.txtHorasSemanales);
            this.materialCard1.Controls.Add(this.label2);
            this.materialCard1.Controls.Add(this.txtSemanasRotacion);
            this.materialCard1.Controls.Add(this.Hora_dia);
            this.materialCard1.Controls.Add(this.txtHorasDia);
            this.materialCard1.Controls.Add(this.dia_semana);
            this.materialCard1.Controls.Add(this.txtDiasSemana);
            this.materialCard1.Controls.Add(this.Especialidad);
            this.materialCard1.Controls.Add(this.txtEspecialidad);
            this.materialCard1.Controls.Add(this.txtAsignatura);
            this.materialCard1.Controls.Add(this.fecha_final);
            this.materialCard1.Controls.Add(this.dateTimePickerFin);
            this.materialCard1.Controls.Add(this.fecha_inicial);
            this.materialCard1.Controls.Add(this.dateTimePickerInicio);
            this.materialCard1.Controls.Add(this.Programa);
            this.materialCard1.Controls.Add(this.comboBoxPrograma);
            this.materialCard1.Controls.Add(this.Identificacion);
            this.materialCard1.Controls.Add(this.lblNombre_Estudiante);
            this.materialCard1.Controls.Add(this.pictureBox1);
            this.materialCard1.Controls.Add(this.label1);
            this.materialCard1.Depth = 0;
            this.materialCard1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialCard1.Location = new System.Drawing.Point(266, 62);
            this.materialCard1.Margin = new System.Windows.Forms.Padding(14);
            this.materialCard1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialCard1.Name = "materialCard1";
            this.materialCard1.Padding = new System.Windows.Forms.Padding(14);
            this.materialCard1.Size = new System.Drawing.Size(637, 642);
            this.materialCard1.TabIndex = 15;
            // 
            // txtIdentificacion
            // 
            this.txtIdentificacion.Location = new System.Drawing.Point(55, 230);
            this.txtIdentificacion.Name = "txtIdentificacion";
            this.txtIdentificacion.Size = new System.Drawing.Size(234, 20);
            this.txtIdentificacion.TabIndex = 35;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(55, 170);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(234, 20);
            this.txtNombre.TabIndex = 34;
            // 
            // Asignatura
            // 
            this.Asignatura.AutoSize = true;
            this.Asignatura.Location = new System.Drawing.Point(55, 465);
            this.Asignatura.Name = "Asignatura";
            this.Asignatura.Size = new System.Drawing.Size(57, 13);
            this.Asignatura.TabIndex = 33;
            this.Asignatura.Text = "Asignatura";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.BackgroundImage")));
            this.pictureBox3.Location = new System.Drawing.Point(594, 9);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(37, 31);
            this.pictureBox3.TabIndex = 32;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.PictureBox3_Click);
            // 
            // Semestre_academico
            // 
            this.Semestre_academico.AutoSize = true;
            this.Semestre_academico.Location = new System.Drawing.Point(349, 465);
            this.Semestre_academico.Name = "Semestre_academico";
            this.Semestre_academico.Size = new System.Drawing.Size(106, 13);
            this.Semestre_academico.TabIndex = 15;
            this.Semestre_academico.Text = "Semestre academico";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(348, 395);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Numero de horas semanales";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(348, 329);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Semana de rotación";
            // 
            // Hora_dia
            // 
            this.Hora_dia.AutoSize = true;
            this.Hora_dia.Location = new System.Drawing.Point(345, 263);
            this.Hora_dia.Name = "Hora_dia";
            this.Hora_dia.Size = new System.Drawing.Size(72, 13);
            this.Hora_dia.TabIndex = 12;
            this.Hora_dia.Text = "Horas por Dia";
            // 
            // dia_semana
            // 
            this.dia_semana.AutoSize = true;
            this.dia_semana.Location = new System.Drawing.Point(344, 207);
            this.dia_semana.Name = "dia_semana";
            this.dia_semana.Size = new System.Drawing.Size(94, 13);
            this.dia_semana.TabIndex = 11;
            this.dia_semana.Text = "Dias de la semana";
            // 
            // Especialidad
            // 
            this.Especialidad.AutoSize = true;
            this.Especialidad.Location = new System.Drawing.Point(344, 146);
            this.Especialidad.Name = "Especialidad";
            this.Especialidad.Size = new System.Drawing.Size(67, 13);
            this.Especialidad.TabIndex = 10;
            this.Especialidad.Text = "Especialidad";
            // 
            // fecha_final
            // 
            this.fecha_final.AutoSize = true;
            this.fecha_final.Location = new System.Drawing.Point(55, 395);
            this.fecha_final.Name = "fecha_final";
            this.fecha_final.Size = new System.Drawing.Size(62, 13);
            this.fecha_final.TabIndex = 8;
            this.fecha_final.Text = "Fecha Final";
            // 
            // fecha_inicial
            // 
            this.fecha_inicial.AutoSize = true;
            this.fecha_inicial.Location = new System.Drawing.Point(55, 329);
            this.fecha_inicial.Name = "fecha_inicial";
            this.fecha_inicial.Size = new System.Drawing.Size(67, 13);
            this.fecha_inicial.TabIndex = 7;
            this.fecha_inicial.Text = "Fecha Inicial";
            // 
            // Programa
            // 
            this.Programa.AutoSize = true;
            this.Programa.Location = new System.Drawing.Point(52, 263);
            this.Programa.Name = "Programa";
            this.Programa.Size = new System.Drawing.Size(52, 13);
            this.Programa.TabIndex = 6;
            this.Programa.Text = "Programa";
            // 
            // Identificacion
            // 
            this.Identificacion.AutoSize = true;
            this.Identificacion.Location = new System.Drawing.Point(52, 207);
            this.Identificacion.Name = "Identificacion";
            this.Identificacion.Size = new System.Drawing.Size(70, 13);
            this.Identificacion.TabIndex = 5;
            this.Identificacion.Text = "Identificacion";
            // 
            // lblNombre_Estudiante
            // 
            this.lblNombre_Estudiante.AutoSize = true;
            this.lblNombre_Estudiante.Location = new System.Drawing.Point(52, 146);
            this.lblNombre_Estudiante.Name = "lblNombre_Estudiante";
            this.lblNombre_Estudiante.Size = new System.Drawing.Size(114, 13);
            this.lblNombre_Estudiante.TabIndex = 4;
            this.lblNombre_Estudiante.Text = "Nombre del Estudiante";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Location = new System.Drawing.Point(285, 40);
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
            this.label1.Location = new System.Drawing.Point(239, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Registrar Estudiante";
            // 
            // FormularioAlumno
            // 
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1115, 742);
            this.Controls.Add(this.materialCard1);
            this.Name = "FormularioAlumno";
            this.Text = "Registro de Alumno";
            this.materialCard1.ResumeLayout(false);
            this.materialCard1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private MaterialSkin.Controls.MaterialCard materialCard1;
        private Label Identificacion;
        private Label lblNombre_Estudiante;
        private PictureBox pictureBox1;
        private Label label1;
        private Label Programa;
        private Label fecha_inicial;
        private Label fecha_final;
        private Label Especialidad;
        private Label label3;
        private Label label2;
        private Label Hora_dia;
        private Label dia_semana;
        private Label Semestre_academico;
        private PictureBox pictureBox3;
        private Label Asignatura;
        private TextBox txtIdentificacion;
        private TextBox txtNombre;
    }
}
