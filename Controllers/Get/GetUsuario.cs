using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Npgsql;

namespace Huellero.Controllers.Get
{
    public class GetUsuarios
    {
        private readonly string _connectionString = "Host=localhost;Username=postgres;Password=Admin;Database=RegisterAttendance;CommandTimeout=30";

        public async Task<List<dynamic>> GetUsuariosAsync()
        {
            var usuarios = new List<dynamic>();

            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string query = @"
                        SELECT u.id_usuario, u.username, u.password, r.descripcion AS nombre_rol, u.estado
                        FROM usuarios u
                        INNER JOIN rol r ON u.id_rol = r.id_rol"; // 🔹 Hacemos JOIN para traer el nombre del rol

                    using (var command = new NpgsqlCommand(query, connection))
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            usuarios.Add(new
                            {
                                IdUsuario = reader.GetInt32(0),
                                Username = reader.GetString(1),
                                Password = reader.GetString(2),
                                NombreRol = reader.GetString(3),  // 🔹 Ahora obtenemos el nombre del rol
                                Estado = reader.GetBoolean(4)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener usuarios: {ex.Message}");
            }

            return usuarios;
        }
    }
}
