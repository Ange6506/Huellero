using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using Huellero.Backend.DatabaseConnection; // Ajusta el namespace según corresponda

namespace Huellero.Controllers
{
    public class AddUsuario
    {
        private readonly DatabaseConnection _databaseConnection;

        public AddUsuario()
        {
            _databaseConnection = new DatabaseConnection();
        }

        public async Task<int?> AgregarUsuarioAsync(int idRol, string username, string password, string estadoTexto = "activo")
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            bool estado = estadoTexto.ToLower() == "activo";

            try
            {
                using (var connection = await _databaseConnection.GetConnectionAsync())
                {
                    if (connection.State != System.Data.ConnectionState.Open)
                    {
                        await connection.OpenAsync();
                    }

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

                            await transaction.CommitAsync();

                            MessageBox.Show($"Usuario registrado con éxito. ID: {idUsuario}",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            return idUsuario;
                        }
                        catch (Exception ex)
                        {
                            await transaction.RollbackAsync();
                            MessageBox.Show($"Error al registrar el usuario: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
