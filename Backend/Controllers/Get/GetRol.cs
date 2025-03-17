using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;
using Huellero.Backend.DatabaseConnection;

namespace Huellero.Controllers
{
    public class GetRol
    {
        private readonly DatabaseConnection _databaseConnection;

        public GetRol()
        {
            _databaseConnection = new DatabaseConnection();
        }

        public async Task<List<dynamic>> GetRolesAsync()
        {
            List<dynamic> roles = new List<dynamic>();

            try
            {
                using (var connection = await _databaseConnection.GetConnectionAsync())
                {
                    // Consulta para obtener los roles ordenados por descripción
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
                                Descripcion = reader.GetString(1)
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
