using Huellero;
using Huellero.Frontend.Asistencia;
using Huellero.Frontend.Estudiante;
using Huellero.Frontend.Programa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Huellero
{
    public partial class main: Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            frmRegistrar registrar = new frmRegistrar();
            registrar.ShowDialog();
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            frmVerificar verificar = new frmVerificar();
            verificar.ShowDialog();
        }
        private void btnFormularioAlumno_Click(object sender, EventArgs e)
        {
            FormularioAlumno formularioAlumno = new FormularioAlumno();
            formularioAlumno.ShowDialog();
        }

        private void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            AgregarUsuarioForm agregarUsuario = new AgregarUsuarioForm();
            agregarUsuario.ShowDialog();
        }

        private void btnAgregarPrograma_Click(object sender, EventArgs e)
        {
            AgregarProgramaForm agregarUsuario = new AgregarProgramaForm();
            agregarUsuario.ShowDialog();
        }

        private void btnAgregarRol_Click(object sender, EventArgs e)
        {
            AgregarRolForm agregarRol = new AgregarRolForm();
            agregarRol.ShowDialog();

        }

        private void btnListEstudiante_Click(object sender, EventArgs e)
        {

            ListaAlumnosModel lisAlumno = new ListaAlumnosModel();
            lisAlumno.ShowDialog();
        }

        private void BtnListAsistencia_Click(object sender, EventArgs e)
        {

            ListaAsistenciaModel lisAsistencia = new ListaAsistenciaModel();
            lisAsistencia.ShowDialog();
        }

        private void BtnListPrograma_Click(object sender, EventArgs e)
        {
            ListaProgramaModel lisPrograma = new ListaProgramaModel();
            lisPrograma.ShowDialog();
        }

    }
}
