using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Huellero.Controllers.Post
{
    public class AddRol
    {
        private readonly string connectionString = "Host=localhost;Username=postgres;Password=Admin;Database=RegisterAttendance;CommandTimeout=30";

        public async Task<int?> AgregarRolAsync(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
            {
                MessageBox.Show("La descripción del rol es obligatoria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            using (var connection = new NpgsqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Insertar el rol con solo la descripción
                        string insertQuery = @"
                        INSERT INTO rol (descripcion) 
                        VALUES (@descripcion) 
                        RETURNING id_rol";

                        using (var command = new NpgsqlCommand(insertQuery, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@descripcion", descripcion);

                            var idRol = (int?)await command.ExecuteScalarAsync();

                            if (idRol == null)
                            {
                                throw new Exception("No se pudo obtener el ID del rol registrado.");
                            }

                            transaction.Commit(); // Confirmar la transacción

                            MessageBox.Show($"Rol registrado con éxito. ID: {idRol}",
                                "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            return idRol;
                        }
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback(); // Revertir la transacción en caso de error
                        MessageBox.Show($"Error al registrar el rol: {ex.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return null;
                    }
                }
            }
        }
    }
}