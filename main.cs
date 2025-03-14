using Huellero;
using Huellero.Frontend.Asistencia;
using Huellero.Frontend.Estudiante;
using Huellero.Frontend.Programa;
using Huellero.Controllers.Login; // Importar la clase Login
using System;
using System.Windows.Forms;

namespace Huellero
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
            ConfigurarInterfazPorRol(); // Llamar la función al cargar el formulario
        }

        private void ConfigurarInterfazPorRol()
        {
            // Ocultar todos los botones por defecto
            btnAgregarUsuario.Visible = false;
            btnAgregarRol.Visible = false;
            btnAgregarPrograma.Visible = false;
            btnListAsistencia.Visible = false;
            btnListPrograma.Visible = false;
            btnListEstudiante.Visible = false;
            btnVerificar.Visible = false;
            btnRegistrar.Visible = false;
            btnFormularioAlumno.Visible = false;
            // Verificar el rol del usuario autenticado
            if (Login.IdRolUsuario == 1) // Administrador
            {
                btnAgregarUsuario.Visible = true;
                btnAgregarRol.Visible = true;
                btnAgregarPrograma.Visible = true;
                btnListPrograma.Visible = true;
                btnListEstudiante.Visible = true;
                btnFormularioAlumno.Visible = true;


            }
            else if (Login.IdRolUsuario == 2) // Usuario normal
            {
                btnListEstudiante.Visible = true;
                btnListAsistencia.Visible = true;
                btnListPrograma.Visible = true;
                btnVerificar.Visible = true;

            }
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
            AgregarProgramaForm agregarPrograma = new AgregarProgramaForm();
            agregarPrograma.ShowDialog();
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
