using System;
using System.Windows.Forms;

namespace Huellero
{
    public partial class AgregarProgramaForm : Form
    {
        private Label lblPrograma;
        private TextBox txtPrograma;
        private Label lblFechaIngreso;
        private Label lblHoraIngreso;
        private TextBox txtHoraIngreso;
        private Label lblUsuario;
        private TextBox txtUsuario;
        private Label lblEstado;
        private ComboBox cbEstado;

        private void InitializeComponent()
        {
            this.lblPrograma = new System.Windows.Forms.Label();
            this.txtPrograma = new System.Windows.Forms.TextBox();
            this.lblFechaIngreso = new System.Windows.Forms.Label();
            this.lblHoraIngreso = new System.Windows.Forms.Label();
            this.txtHoraIngreso = new System.Windows.Forms.TextBox();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtFechaIngreso = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lblPrograma
            // 
            this.lblPrograma.Location = new System.Drawing.Point(20, 20);
            this.lblPrograma.Name = "lblPrograma";
            this.lblPrograma.Size = new System.Drawing.Size(100, 23);
            this.lblPrograma.TabIndex = 0;
            this.lblPrograma.Text = "Programa";
            // 
            // txtPrograma
            // 
            this.txtPrograma.Location = new System.Drawing.Point(150, 20);
            this.txtPrograma.Name = "txtPrograma";
            this.txtPrograma.Size = new System.Drawing.Size(200, 20);
            this.txtPrograma.TabIndex = 1;
            // 
            // lblFechaIngreso
            // 
            this.lblFechaIngreso.Location = new System.Drawing.Point(20, 60);
            this.lblFechaIngreso.Name = "lblFechaIngreso";
            this.lblFechaIngreso.Size = new System.Drawing.Size(100, 23);
            this.lblFechaIngreso.TabIndex = 2;
            this.lblFechaIngreso.Text = "Fecha Ingreso";
            // 
            // lblHoraIngreso
            // 
            this.lblHoraIngreso.Location = new System.Drawing.Point(20, 100);
            this.lblHoraIngreso.Name = "lblHoraIngreso";
            this.lblHoraIngreso.Size = new System.Drawing.Size(100, 23);
            this.lblHoraIngreso.TabIndex = 4;
            this.lblHoraIngreso.Text = "Hora Ingreso";
            // 
            // txtHoraIngreso
            // 
            this.txtHoraIngreso.Location = new System.Drawing.Point(150, 100);
            this.txtHoraIngreso.Name = "txtHoraIngreso";
            this.txtHoraIngreso.Size = new System.Drawing.Size(200, 20);
            this.txtHoraIngreso.TabIndex = 5;
            // 
            // lblUsuario
            // 
            this.lblUsuario.Location = new System.Drawing.Point(20, 140);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(100, 23);
            this.lblUsuario.TabIndex = 6;
            this.lblUsuario.Text = "Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(150, 140);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(200, 20);
            this.txtUsuario.TabIndex = 7;
            // 
            // lblEstado
            // 
            this.lblEstado.Location = new System.Drawing.Point(20, 180);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(100, 23);
            this.lblEstado.TabIndex = 8;
            this.lblEstado.Text = "Estado";
            // 
            // cbEstado
            // 
            this.cbEstado.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cbEstado.Location = new System.Drawing.Point(150, 180);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(200, 21);
            this.cbEstado.TabIndex = 9;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(150, 220);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(75, 23);
            this.btnAgregar.TabIndex = 10;
            this.btnAgregar.Text = "Agregar";
            // 
            // txtFechaIngreso
            // 
            this.txtFechaIngreso.Location = new System.Drawing.Point(150, 54);
            this.txtFechaIngreso.Name = "txtFechaIngreso";
            this.txtFechaIngreso.Size = new System.Drawing.Size(200, 20);
            this.txtFechaIngreso.TabIndex = 11;
            // 
            // AgregarProgramaForm
            // 
            this.ClientSize = new System.Drawing.Size(400, 280);
            this.Controls.Add(this.txtFechaIngreso);
            this.Controls.Add(this.lblPrograma);
            this.Controls.Add(this.txtPrograma);
            this.Controls.Add(this.lblFechaIngreso);
            this.Controls.Add(this.lblHoraIngreso);
            this.Controls.Add(this.txtHoraIngreso);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.cbEstado);
            this.Controls.Add(this.btnAgregar);
            this.Name = "AgregarProgramaForm";
            this.Text = "Agregar Programa";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private DateTimePicker txtFechaIngreso;
    }
}