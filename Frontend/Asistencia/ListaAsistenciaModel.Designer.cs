using System;
using System.Windows.Forms;

namespace Huellero.Frontend.Asistencia
{
    public partial class ListaAsistenciaModel : Form
    {
        private System.Windows.Forms.DataGridView dataGridViewAlumnos;

        private void InitializeComponent()
        {
            this.dataGridViewAlumnos = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Buscador = new System.Windows.Forms.TextBox();
            this.cmbFiltroPrograma = new System.Windows.Forms.ComboBox();
            this.dateFiltro = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.Cerrar_Sesion = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAlumnos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAlumnos
            // 
            this.dataGridViewAlumnos.AllowUserToAddRows = false;
            this.dataGridViewAlumnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAlumnos.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridViewAlumnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAlumnos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5});
            this.dataGridViewAlumnos.Location = new System.Drawing.Point(32, 150);
            this.dataGridViewAlumnos.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridViewAlumnos.Name = "dataGridViewAlumnos";
            this.dataGridViewAlumnos.ReadOnly = true;
            this.dataGridViewAlumnos.Size = new System.Drawing.Size(750, 311);
            this.dataGridViewAlumnos.TabIndex = 0;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Nombre Completo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Nº Cédula";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Fecha y Hora Entrada";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Fecha y Hora Salida";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Programa";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // Buscador
            // 
            this.Buscador.AccessibleName = "";
            this.Buscador.Location = new System.Drawing.Point(536, 71);
            this.Buscador.Name = "Buscador";
            this.Buscador.Size = new System.Drawing.Size(246, 20);
            this.Buscador.TabIndex = 2;
            this.Buscador.Text = "Busca por Nombre o N° Identificacion";
            // 
            // cmbFiltroPrograma
            // 
            this.cmbFiltroPrograma.FormattingEnabled = true;
            this.cmbFiltroPrograma.Location = new System.Drawing.Point(32, 110);
            this.cmbFiltroPrograma.Name = "cmbFiltroPrograma";
            this.cmbFiltroPrograma.Size = new System.Drawing.Size(134, 21);
            this.cmbFiltroPrograma.TabIndex = 3;
            this.cmbFiltroPrograma.Text = "Selecciona el programa";
            // 
            // dateFiltro
            // 
            this.dateFiltro.Location = new System.Drawing.Point(172, 111);
            this.dateFiltro.Name = "dateFiltro";
            this.dateFiltro.Size = new System.Drawing.Size(200, 20);
            this.dateFiltro.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Lista de Asistencia";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(707, 108);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 23);
            this.btnImprimir.TabIndex = 6;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.BtnImprimir_Click);
            // 
            // Cerrar_Sesion
            // 
            this.Cerrar_Sesion.Location = new System.Drawing.Point(661, 484);
            this.Cerrar_Sesion.Name = "Cerrar_Sesion";
            this.Cerrar_Sesion.Size = new System.Drawing.Size(121, 23);
            this.Cerrar_Sesion.TabIndex = 12;
            this.Cerrar_Sesion.Text = "Volver";
            this.Cerrar_Sesion.UseVisualStyleBackColor = true;
            this.Cerrar_Sesion.Click += new System.EventHandler(this.Cerrar_Sesion_Click);
            // 
            // ListaAsistenciaModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 540);
            this.Controls.Add(this.Cerrar_Sesion);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateFiltro);
            this.Controls.Add(this.cmbFiltroPrograma);
            this.Controls.Add(this.Buscador);
            this.Controls.Add(this.dataGridViewAlumnos);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ListaAsistenciaModel";
            this.Text = "Lista de Asistencia";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAlumnos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private TextBox Buscador;
        private ComboBox cmbFiltroPrograma;
        private DateTimePicker dateFiltro;
        private Label label1;
        private Button btnImprimir;
        private Button Cerrar_Sesion;
    }
}
