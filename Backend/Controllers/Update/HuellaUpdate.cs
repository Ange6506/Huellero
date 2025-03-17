using Npgsql;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Huellero.Backend.DatabaseConnection; // Asegúrate de que el namespace sea correcto

namespace Huellero.Controllers.Update
{
    public class HuellaUpdate
    {
        private readonly DatabaseConnection _databaseConnection;

        public HuellaUpdate()
        {
            _databaseConnection = new DatabaseConnection();
        }

        public async Task<bool> GuardarHuellaEnBD(int idEstudiante, byte[] huella)
        {
            try
            {
                using (var conexion = await _databaseConnection.GetConnectionAsync())
                {
                    if (conexion.State != System.Data.ConnectionState.Open)
                    {
                        await conexion.OpenAsync();
                    }

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
