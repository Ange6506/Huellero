using Npgsql;
using System;

namespace Huellero.Controllers.Login
{
    public class Login
    {
        private readonly string connectionString = "Host=localhost;Username=postgres;Password=Admin;Database=RegisterAttendance;CommandTimeout=30";

        public static string UsuarioActual { get; private set; } // Usuario autenticado
public static int IdRolUsuario { get; set; }

        public bool IniciarSesion(string username, string password)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT id_rol FROM usuarios WHERE username = @username AND password = @password AND estado = true";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    var result = command.ExecuteScalar();

                    if (result != null) // Si hay resultado, el usuario existe y está activo
                    {
                        UsuarioActual = username;
                        IdRolUsuario = Convert.ToInt32(result); // Guardar el ID del rol
                        return true;
                    }

                    return false;
                }
            }
        }
    }
}
