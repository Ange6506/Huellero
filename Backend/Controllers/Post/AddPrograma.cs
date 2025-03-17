using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using Huellero.Backend.DatabaseConnection; // Ajusta el namespace según corresponda

namespace Huellero.Controllers.Post
{
    public class AddPrograma
    {
        private readonly DatabaseConnection _databaseConnection;

        public AddPrograma()
        {
            _databaseConnection = new DatabaseConnection();
        }

        public async Task<int?> AgregarProgramaAsync(string programa, string fechaIngreso, string horaIngreso, string username, string estadoTexto = "activo")
        {
            if (string.IsNullOrWhiteSpace(programa) || string.IsNullOrWhiteSpace(fechaIngreso) ||
                string.IsNullOrWhiteSpace(horaIngreso) || string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Todos los campos son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            bool estado = estadoTexto.ToLower() == "activo";

            try
            {
                using (var connection = await _databaseConnection.GetConnectionAsync())
                {
                    // Verificamos si la conexión no está abierta
                    if (connection.State != System.Data.ConnectionState.Open)
                    {
                        await connection.OpenAsync();
                    }

                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // 1. Obtener el id_usuario basado en el username
                            string getUserIdQuery = "SELECT id_usuario FROM usuarios WHERE username = @username";
                            int? idUsuario = null;

                            using (var getUserCommand = new NpgsqlCommand(getUserIdQuery, connection, transaction))
                            {
                                getUserCommand.Parameters.AddWithValue("@username", username);
                                var result = await getUserCommand.ExecuteScalarAsync();
                                idUsuario = result as int?;
                            }

                            if (idUsuario == null)
                            {
                                MessageBox.Show("El usuario no existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return null;
                            }

                            // 2. Insertar el programa con el id_usuario
                            string insertQuery = @"
                                INSERT INTO programa (programa, fecha_ingreso, hora_ingreso, usuario, estado) 
                                VALUES (@programa, @fechaIngreso, @horaIngreso, @usuario, @estado) 
                                RETURNING id_programa";

                            using (var command = new NpgsqlCommand(insertQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@programa", programa);
                                command.Parameters.AddWithValue("@fechaIngreso", DateTime.Parse(fechaIngreso));
                                command.Parameters.AddWithValue("@horaIngreso", TimeSpan.Parse(horaIngreso));
                                command.Parameters.AddWithValue("@usuario", idUsuario); // Se inserta el ID, no el username
                                command.Parameters.AddWithValue("@estado", estado);

                                var idPrograma = (int?)await command.ExecuteScalarAsync();

                                if (idPrograma == null)
                                {
                                    throw new Exception("No se pudo obtener el ID del programa registrado.");
                                }

                                await transaction.CommitAsync(); // Confirmar la transacción

                                MessageBox.Show($"Programa registrado con éxito. ID: {idPrograma}",
                                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                return idPrograma;
                            }
                        }
                        catch (Exception ex)
                        {
                            await transaction.RollbackAsync(); // Revertir la transacción en caso de error
                            MessageBox.Show($"Error al registrar el programa: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
    }
}
