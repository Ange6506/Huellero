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
            // Deshabilitar todos los botones por defecto
            btnAgregarUsuario.Enabled = false;
  
            btnAgregarPrograma.Enabled = false;
            btnListAsistencia.Enabled = false;
            btnListPrograma.Enabled = false;
            btnListEstudiante.Enabled = false;
            btnVerificar.Enabled = false;
            btnRegistrar.Visible = false;
            btnFormularioAlumno.Enabled = false;
     

            // Verificar el rol del usuario autenticado
            if (Login.IdRolUsuario == 1) // Administrador
            {
                btnAgregarUsuario.Enabled = true;
                btnAgregarPrograma.Enabled = true;
                btnListPrograma.Enabled = true;
                btnListEstudiante.Enabled = true;
                btnFormularioAlumno.Enabled = true;
            }
            else if (Login.IdRolUsuario == 2) // Usuario normal
            {
                btnListEstudiante.Enabled = true;
                btnListAsistencia.Enabled = true;
                btnListPrograma.Enabled = true;
                btnVerificar.Enabled = true;
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



        private void Cerrar_Sesion_Click(object sender, EventArgs e)
        {
            // Confirmar si el usuario quiere cerrar sesión
            DialogResult result = MessageBox.Show("¿Estás seguro de que deseas cerrar sesión?", "Cerrar Sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Reiniciar variables de sesión
                Login.IdRolUsuario = 0; // Restablecer el rol del usuario autenticado

                // Mostrar el formulario de Login antes de cerrar main
                Login login = new Login();

                // Cerrar el formulario actual
                this.Close();
            }
        
    }

}
}
