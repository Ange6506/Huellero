using System;
using System.Windows.Forms;

namespace Huellero
{
    partial class FormularioAlumno
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtIdentificacion;
        private System.Windows.Forms.ComboBox comboBoxPrograma;
        private System.Windows.Forms.DateTimePicker dateTimePickerInicio;
        private System.Windows.Forms.DateTimePicker dateTimePickerFin;
        private System.Windows.Forms.Button btnRegistrarHuella;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblHuellaStatus;
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
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtIdentificacion = new System.Windows.Forms.TextBox();
            this.comboBoxPrograma = new System.Windows.Forms.ComboBox();
            this.dateTimePickerInicio = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerFin = new System.Windows.Forms.DateTimePicker();
            this.btnRegistrarHuella = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.lblHuellaStatus = new System.Windows.Forms.Label();
            this.txtAsignatura = new System.Windows.Forms.TextBox();
            this.txtEspecialidad = new System.Windows.Forms.TextBox();
            this.txtDiasSemana = new System.Windows.Forms.TextBox();
            this.txtHorasDia = new System.Windows.Forms.TextBox();
            this.txtSemanasRotacion = new System.Windows.Forms.TextBox();
            this.txtHorasSemanales = new System.Windows.Forms.TextBox();
            this.txtSemestre = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(50, 30);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 20);
            this.txtNombre.TabIndex = 0;
            // 
            // txtIdentificacion
            // 
            this.txtIdentificacion.Location = new System.Drawing.Point(50, 60);
            this.txtIdentificacion.Name = "txtIdentificacion";
            this.txtIdentificacion.Size = new System.Drawing.Size(200, 20);
            this.txtIdentificacion.TabIndex = 1;
            // 
            // comboBoxPrograma
            // 
            this.comboBoxPrograma.Location = new System.Drawing.Point(50, 90);
            this.comboBoxPrograma.Name = "comboBoxPrograma";
            this.comboBoxPrograma.Size = new System.Drawing.Size(200, 21);
            this.comboBoxPrograma.TabIndex = 2;
            // 
            // dateTimePickerInicio
            // 
            this.dateTimePickerInicio.Location = new System.Drawing.Point(50, 120);
            this.dateTimePickerInicio.Name = "dateTimePickerInicio";
            this.dateTimePickerInicio.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerInicio.TabIndex = 3;
            // 
            // dateTimePickerFin
            // 
            this.dateTimePickerFin.Location = new System.Drawing.Point(50, 150);
            this.dateTimePickerFin.Name = "dateTimePickerFin";
            this.dateTimePickerFin.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerFin.TabIndex = 4;
            // 
            // btnRegistrarHuella
            // 
            this.btnRegistrarHuella.Location = new System.Drawing.Point(50, 390);
            this.btnRegistrarHuella.Name = "btnRegistrarHuella";
            this.btnRegistrarHuella.Size = new System.Drawing.Size(200, 30);
            this.btnRegistrarHuella.TabIndex = 12;
            this.btnRegistrarHuella.Text = "Registrar Huella";
            this.btnRegistrarHuella.Click += new System.EventHandler(this.btnRegistrarHuella_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(50, 430);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(200, 30);
            this.btnGuardar.TabIndex = 13;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click_1);
            // 
            // lblHuellaStatus
            // 
            this.lblHuellaStatus.Location = new System.Drawing.Point(50, 470);
            this.lblHuellaStatus.Name = "lblHuellaStatus";
            this.lblHuellaStatus.Size = new System.Drawing.Size(200, 20);
            this.lblHuellaStatus.TabIndex = 14;
            this.lblHuellaStatus.Text = "Estado de la Huella: No registrada";
            // 
            // txtAsignatura
            // 
            this.txtAsignatura.Location = new System.Drawing.Point(50, 180);
            this.txtAsignatura.Name = "txtAsignatura";
            this.txtAsignatura.Size = new System.Drawing.Size(200, 20);
            this.txtAsignatura.TabIndex = 5;
            // 
            // txtEspecialidad
            // 
            this.txtEspecialidad.Location = new System.Drawing.Point(50, 210);
            this.txtEspecialidad.Name = "txtEspecialidad";
            this.txtEspecialidad.Size = new System.Drawing.Size(200, 20);
            this.txtEspecialidad.TabIndex = 6;
            // 
            // txtDiasSemana
            // 
            this.txtDiasSemana.Location = new System.Drawing.Point(50, 240);
            this.txtDiasSemana.Name = "txtDiasSemana";
            this.txtDiasSemana.Size = new System.Drawing.Size(200, 20);
            this.txtDiasSemana.TabIndex = 7;
            // 
            // txtHorasDia
            // 
            this.txtHorasDia.Location = new System.Drawing.Point(50, 270);
            this.txtHorasDia.Name = "txtHorasDia";
            this.txtHorasDia.Size = new System.Drawing.Size(200, 20);
            this.txtHorasDia.TabIndex = 8;
            // 
            // txtSemanasRotacion
            // 
            this.txtSemanasRotacion.Location = new System.Drawing.Point(50, 300);
            this.txtSemanasRotacion.Name = "txtSemanasRotacion";
            this.txtSemanasRotacion.Size = new System.Drawing.Size(200, 20);
            this.txtSemanasRotacion.TabIndex = 9;
            // 
            // txtHorasSemanales
            // 
            this.txtHorasSemanales.Location = new System.Drawing.Point(50, 330);
            this.txtHorasSemanales.Name = "txtHorasSemanales";
            this.txtHorasSemanales.Size = new System.Drawing.Size(200, 20);
            this.txtHorasSemanales.TabIndex = 10;
            // 
            // txtSemestre
            // 
            this.txtSemestre.Location = new System.Drawing.Point(50, 360);
            this.txtSemestre.Name = "txtSemestre";
            this.txtSemestre.Size = new System.Drawing.Size(200, 20);
            this.txtSemestre.TabIndex = 11;
            // 
            // FormularioAlumno
            // 
            this.ClientSize = new System.Drawing.Size(318, 509);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.txtIdentificacion);
            this.Controls.Add(this.comboBoxPrograma);
            this.Controls.Add(this.dateTimePickerInicio);
            this.Controls.Add(this.dateTimePickerFin);
            this.Controls.Add(this.txtAsignatura);
            this.Controls.Add(this.txtEspecialidad);
            this.Controls.Add(this.txtDiasSemana);
            this.Controls.Add(this.txtHorasDia);
            this.Controls.Add(this.txtSemanasRotacion);
            this.Controls.Add(this.txtHorasSemanales);
            this.Controls.Add(this.txtSemestre);
            this.Controls.Add(this.btnRegistrarHuella);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.lblHuellaStatus);
            this.Name = "FormularioAlumno";
            this.Text = "Registro de Alumno";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
