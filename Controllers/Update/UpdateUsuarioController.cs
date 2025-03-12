using System;
using System.Data;
using System.Threading.Tasks;
using Npgsql;

namespace Huellero.Controllers.Update
{
    public class UpdateUsuarioController
    {
        private readonly string _connectionString = "Host=localhost;Username=postgres;Password=Admin;Database=RegisterAttendance;CommandTimeout=30";

        public async Task<bool> ActualizarUsuarioAsync(int idUsuario, string username, string password, int idRol, string estado)
        {
            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

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

                        // 🔹 Convertir "Activo" en true y "Inactivo" en false
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
