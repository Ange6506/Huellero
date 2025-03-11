using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Huellero
{
    public partial class frmRegistrar : Form
    {
        private DPFP.Template Template;
        public string connectionString = "Host=localhost;Username=postgres;Password=Admin;Database=RegisterAttendance;CommandTimeout=30";

        public frmRegistrar()
        {
            InitializeComponent();
        }

        // Evento de captura de huella
        public void btnRegistrarHuella_Click(object sender, EventArgs e)
        {
            CapturaHuella captura = new CapturaHuella();
            captura.OnTemplate += this.OnTemplate;
            captura.ShowDialog();
        }

        // Método para manejar la plantilla de huella capturada
        public void OnTemplate(DPFP.Template template)
        {
            this.Invoke(new Function(delegate ()
            {
                Template = template;
                btnAgregar.Enabled = (Template != null);
                if (Template != null)
                {
                    MessageBox.Show("La plantilla de huella está lista para la verificación.");
                    txtHuella.Text = "Huella capturada correctamente";
                }
                else
                {
                    MessageBox.Show("La plantilla de huella no es válida.");
                }
            }));
        }

        // Evento de agregar la huella y el nombre del estudiante a la base de datos
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Template != null)
            {
                try
                {
                    // Obtener el nombre del estudiante desde el TextBox
                    string Nombre = txtNombre.Text; // Suponiendo que txtNombreEstudiante es el TextBox donde se ingresa el nombre

                    if (string.IsNullOrEmpty(Nombre))
                    {
                        MessageBox.Show("Por favor ingrese el nombre del estudiante.");
                        return;
                    }

                    // Conectar a la base de datos PostgreSQL
                    using (var conn = new NpgsqlConnection(connectionString))
                    {
                        conn.Open();
                        MessageBox.Show("Conexión exitosa a la base de datos.");

                        // Mensaje adicional en consola
                        Console.WriteLine("Conexión exitosa a la base de datos.");

                        // Aquí debes insertar la huella o almacenar la información que quieras
                        string sql = "INSERT INTO public.estudiantes (nombre_del_estudiante, huella) " +
                                     "VALUES (@nombre_del_estudiante, @huella)";
                        using (var cmd = new NpgsqlCommand(sql, conn))
                        {
                            // Convierte la plantilla de la huella a un formato que puedas almacenar, como un array de bytes
                            byte[] huellaBytes = Template.Bytes;

                            // Agregar los parámetros a la consulta SQL
                            cmd.Parameters.AddWithValue("@huella", huellaBytes);
                            cmd.Parameters.AddWithValue("@nombre_del_estudiante", Nombre); // Usamos el valor del TextBox, no el control

                            // Ejecutar el comando
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("La huella fue registrada en la base de datos.");
                    }
                }
                catch (Exception ex)
                {
                    // En caso de error, mostrar el mensaje en la consola
                    Console.WriteLine($"Error al conectar a la base de datos: {ex.Message}"); // Mensaje de error en la consola
                    MessageBox.Show($"Error al conectar a la base de datos: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("No se ha capturado ninguna huella.");
            }
        }
    }
}
