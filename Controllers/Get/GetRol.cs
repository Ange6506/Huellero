using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;

namespace Huellero.Controllers
{
    public class GetRol
    {
        public string connectionString = "Host=localhost;Username=postgres;Password=Admin;Database=RegisterAttendance;CommandTimeout=30";

        public async Task<List<dynamic>> GetRolesAsync()
        {
            List<dynamic> roles = new List<dynamic>();

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
                        return roles; // Devuelve la lista vacía si la conexión falla
                    }

                    // Consulta corregida
                    string query = @"SELECT id_rol, descripcion FROM public.rol ORDER BY descripcion";

                    using (var command = new NpgsqlCommand(query, connection))
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (!reader.HasRows)
                        {
                            MessageBox.Show("No se encontraron roles.");
                        }

                        while (await reader.ReadAsync())
                        {
                            var rol = new
                            {
                                IdRol = reader.GetInt32(0),
                                Descripcion = reader.GetString(1) // Cambio de NombreRol a Descripcion
                            };
                            roles.Add(rol);
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

            return roles;
        }
    }
}
