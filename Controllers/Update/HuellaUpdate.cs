using Npgsql;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Huellero.Controllers.Update
{
    public class HuellaUpdate
    {
        public async Task<bool> GuardarHuellaEnBD(int idEstudiante, byte[] huella)
        {
            try
            {
                using (var conexion = new NpgsqlConnection("Host=localhost;Username=postgres;Password=Admin;Database=RegisterAttendance;CommandTimeout=30"))
                {
                    await conexion.OpenAsync();
                    string query = "UPDATE estudiantes SET huella = @Huella WHERE id_estudiantes = @Id";

                    using (var cmd = new NpgsqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Huella", huella);
                        cmd.Parameters.AddWithValue("@Id", idEstudiante);

                        int filasAfectadas = await cmd.ExecuteNonQueryAsync();
                        return filasAfectadas > 0; // Si se actualizó al menos una fila, retorna true
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar la huella: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
