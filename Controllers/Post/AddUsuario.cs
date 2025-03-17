using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Huellero.Controllers
{
    public class AddUsuario
    {
        private readonly string connectionString = "Host=localhost;Username=postgres;Password=Admin;Database=RegisterAttendance;CommandTimeout=30";

        public async Task<int?> AgregarUsuarioAsync(int idRol, string username, string password, string estadoTexto = "activo")
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            bool estado = estadoTexto.ToLower() == "activo";

            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string insertQuery = @"
                            INSERT INTO usuarios (id_rol, username, password, estado) 
                            VALUES (@idRol, @username, @password, @estado) 
                            RETURNING id_usuario";

                        int? idUsuario;
                        using (var command = new NpgsqlCommand(insertQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@idRol", idRol);
                            command.Parameters.AddWithValue("@username", username);
                            command.Parameters.AddWithValue("@password", password);
                            command.Parameters.AddWithValue("@estado", estado);

                            idUsuario = (int?)await command.ExecuteScalarAsync();
                        }

                        if (idUsuario == null)
                        {
                            throw new Exception("No se pudo obtener el ID del usuario registrado.");
                        }

                        transaction.Commit();

                        MessageBox.Show($"Usuario registrado con éxito. ID: {idUsuario}",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        return idUsuario;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Error al registrar el usuario: {ex.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }
            }
        }
    }
}
