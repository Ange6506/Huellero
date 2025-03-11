using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;

namespace Huellero.Controllers
{
    public class GetPrograma
    {
        public string connectionString = "Host=localhost;Username=postgres;Password=Admin;Database=RegisterAttendance;CommandTimeout=30";

        public async Task<List<dynamic>> GetProgramasAsync()
        {
            List<dynamic> programas = new List<dynamic>();

            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    try
                    {
                        await connection.OpenAsync();
                        MessageBox.Show("Conexión exitosa.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error de conexión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return programas;
                    }

                    // Consulta actualizada para obtener el username en lugar del id_usuario
                    string query = @"
                        SELECT p.id_programa, p.programa, p.fecha_ingreso, p.hora_ingreso, 
                               COALESCE(u.username, 'Desconocido') AS username, p.estado
                        FROM public.programa p
                        LEFT JOIN public.usuarios u ON p.usuario = u.id_usuario
                        ORDER BY p.programa";

                    using (var command = new NpgsqlCommand(query, connection))
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (!reader.HasRows)
                        {
                            MessageBox.Show("No se encontraron programas.");
                        }

                        while (await reader.ReadAsync())
                        {
                            var programa = new
                            {
                                IdPrograma = reader.GetInt32(0),
                                NombrePrograma = reader.GetString(1),
                                FechaIngreso = reader.GetDateTime(2).ToString("yyyy-MM-dd"),
                                HoraIngreso = reader.IsDBNull(3) ? null : ((TimeSpan)reader.GetValue(3)).ToString(@"hh\:mm\:ss"),
                                Usuario = reader.GetString(4), // Ahora se obtiene el username
                                Estado = reader.IsDBNull(5) ? null : reader.GetBoolean(5).ToString()
                            };
                            programas.Add(programa);
                        }
                    }
                }
            }
            catch (NpgsqlException npgsqlEx)
            {
                MessageBox.Show($"Error de PostgreSQL: {npgsqlEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error general: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return programas;
        }
    }
}
