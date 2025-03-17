using System;
using System.Data;
using System.Threading.Tasks;
using Npgsql;
using Huellero.Backend.DatabaseConnection; // Asegúrate de que el namespace sea correcto

namespace Huellero.Controllers.Update
{
    public class UpdateUsuarioController
    {
        public async Task<bool> ActualizarUsuarioAsync(int idUsuario, string username, string password, int idRol, string estado)
        {
            try
            {
                using (var connection = await new DatabaseConnection().GetConnectionAsync())
                {
                    if (connection.State != ConnectionState.Open)
                    {
                        await connection.OpenAsync();
                    }

                    string query = @"
                        UPDATE usuarios 
                        SET username = @Username, 
                            password = @Password, 
                            id_rol = @IdRol, 
                            estado = @Estado
                        WHERE id_usuario = @IdUsuario";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@IdUsuario", idUsuario);
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@IdRol", idRol);

                        // Convertir "activo" en true y "inactivo" en false
                        bool estadoBooleano = estado.ToLower() == "activo";
                        command.Parameters.AddWithValue("@Estado", estadoBooleano);

                        int rowsAffected = await command.ExecuteNonQueryAsync();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar usuario: {ex.Message}");
                return false;
            }
        }
    }
}
