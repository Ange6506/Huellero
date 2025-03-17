using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using Huellero.Backend.DatabaseConnection; // Asegúrate de que el namespace sea correcto

namespace Huellero.Controllers.Update
{
    public class UpdatePrograma
    {
        /// <summary>
        /// Actualiza un programa existente en la base de datos.
        /// </summary>
        /// <param name="idPrograma">El identificador del programa a actualizar.</param>
        /// <param name="programa">El nombre del programa.</param>
        /// <param name="fechaIngreso">La fecha de ingreso en formato "yyyy-MM-dd".</param>
        /// <param name="horaIngreso">La hora de ingreso en formato "HH:mm:ss".</param>
        /// <param name="username">El username del usuario que actualiza el programa.</param>
        /// <param name="estadoTexto">Texto que indica el estado ("activo" o "inactivo").</param>
        /// <returns>true si la actualización fue exitosa; false en caso contrario.</returns>
        public async Task<bool> UpdateProgramaAsync(int idPrograma, string programa, string fechaIngreso, string horaIngreso, string username, string estadoTexto = "activo")
        {
            if (idPrograma <= 0 || string.IsNullOrWhiteSpace(programa) || string.IsNullOrWhiteSpace(fechaIngreso) ||
                string.IsNullOrWhiteSpace(horaIngreso) || string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Todos los campos son obligatorios, incluido el ID del programa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            bool estado = estadoTexto.ToLower() == "activo";

            try
            {
                using (var connection = await new DatabaseConnection().GetConnectionAsync())
                {
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
                                return false;
                            }

                            // 2. Actualizar el programa con el id_usuario obtenido
                            string updateQuery = @"
                                UPDATE programa
                                SET programa = @programa,
                                    fecha_ingreso = @fechaIngreso,
                                    hora_ingreso = @horaIngreso,
                                    usuario = @usuario,
                                    estado = @estado
                                WHERE id_programa = @idPrograma";

                            using (var command = new NpgsqlCommand(updateQuery, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@programa", programa);
                                command.Parameters.AddWithValue("@fechaIngreso", DateTime.Parse(fechaIngreso));
                                command.Parameters.AddWithValue("@horaIngreso", TimeSpan.Parse(horaIngreso));
                                command.Parameters.AddWithValue("@usuario", idUsuario); // Se inserta el ID, no el username
                                command.Parameters.AddWithValue("@estado", estado);
                                command.Parameters.AddWithValue("@idPrograma", idPrograma);

                                int rowsAffected = await command.ExecuteNonQueryAsync();

                                if (rowsAffected <= 0)
                                {
                                    throw new Exception("No se pudo actualizar el programa.");
                                }

                                await transaction.CommitAsync();

                                MessageBox.Show("Programa actualizado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return true;
                            }
                        }
                        catch (Exception ex)
                        {
                            await transaction.RollbackAsync();
                            MessageBox.Show($"Error al actualizar el programa: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la conexión o ejecución: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
