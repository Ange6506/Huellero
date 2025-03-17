using Npgsql;
using System;
using System.Threading.Tasks;
using Huellero.Backend.DatabaseConnection;

namespace Huellero.Controllers.Login
{
    public class Login
    {
        private readonly DatabaseConnection _databaseConnection;
        public static string UsuarioActual { get; private set; } // Usuario autenticado
        public static int IdRolUsuario { get; set; }

        public Login()
        {
            _databaseConnection = new DatabaseConnection();
        }

        public async Task<bool> IniciarSesionAsync(string username, string password)
        {
            try
            {
                using (var connection = await _databaseConnection.GetConnectionAsync())
                {
                    string query = "SELECT id_rol FROM usuarios WHERE username = @username AND password = @password AND estado = true";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        var result = await command.ExecuteScalarAsync();

                        if (result != null)
                        {
                            UsuarioActual = username;
                            IdRolUsuario = Convert.ToInt32(result);
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en el inicio de sesión: {ex.Message}");
            }
            return false;
        }
    }
}
