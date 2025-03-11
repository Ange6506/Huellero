using Npgsql;
using System;

namespace Huellero.Controllers.Login
{
    public class Login
    {
        private readonly string connectionString = "Host=localhost;Username=postgres;Password=Admin;Database=RegisterAttendance;CommandTimeout=30";

        public static string UsuarioActual { get; private set; } // Variable estática para almacenar el usuario autenticado

        public bool IniciarSesion(string username, string password)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM usuarios WHERE username = @username AND password = @password AND estado = true";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count > 0)
                    {
                        UsuarioActual = username; // Guardar el usuario autenticado
                        return true;
                    }

                    return false;
                }
            }
        }
    }
}
