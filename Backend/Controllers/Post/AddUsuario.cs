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
                            // Verificar si el usuario ya existe por username
                            string checkQuery = "SELECT id_usuario FROM usuarios WHERE username = @username";
                            using (var checkCommand = new NpgsqlCommand(checkQuery, connection, transaction))
                            {
                                checkCommand.Parameters.AddWithValue("@username", username);
                                var existingUserId = await checkCommand.ExecuteScalarAsync();
                                if (existingUserId != null)
                                {
                                    MessageBox.Show("El usuario ya existe en el sistema.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    await transaction.RollbackAsync();
                                    return null;
                                }
                            }

                            // Obtener el último id_usuario
                            string getLastIdQuery = "SELECT COALESCE(MAX(id_usuario), 0) FROM usuarios";
                            int lastId;
                            using (var getLastIdCommand = new NpgsqlCommand(getLastIdQuery, connection, transaction))
                            {
                                lastId = (int)await getLastIdCommand.ExecuteScalarAsync();
                            }

                            int newId = lastId + 1;

                            // Insertar nuevo usuario con el nuevo id_usuario
                            string insertQuery = @"INSERT INTO usuarios (id_usuario, id_rol, username, password, estado) 
                                                   VALUES (@idUsuario, @idRol, @username, @password, @estado)";

                            using (var command = new NpgsqlCommand(insertQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@idUsuario", newId);
                                command.Parameters.AddWithValue("@idRol", idRol);
                                command.Parameters.AddWithValue("@username", username);
                                command.Parameters.AddWithValue("@password", password);
                                command.Parameters.AddWithValue("@estado", estado);

                                await command.ExecuteNonQueryAsync();
                            }

                            await transaction.CommitAsync();

                            MessageBox.Show($"Usuario registrado con éxito. ID: {newId}",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            return newId;
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
