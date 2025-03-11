using Huellero.Frontend.Login;
using System;
using System.Windows.Forms;

namespace Huellero
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Crear e iniciar el formulario de login
            Login login = new Login();
            if (login.ShowDialog() == DialogResult.OK) // Solo si el login es exitoso
            {
                Application.Run(new main()); // Inicia la aplicación principal
            }
        }
    }
}
