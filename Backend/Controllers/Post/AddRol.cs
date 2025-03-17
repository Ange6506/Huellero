using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using Huellero.Backend.DatabaseConnection; // Ajusta el namespace si es necesario

namespace Huellero.Controllers.Post
{
    public class AddRol
    {
        private readonly DatabaseConnection _databaseConnection;

        public AddRol()
        {
            _databaseConnection = new DatabaseConnection();
        }

        public async Task<int?> AgregarRolAsync(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
            {
                MessageBox.Show("La descripción del rol es obligatoria.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

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

                                await transaction.CommitAsync(); // Confirmar la transacción

                                MessageBox.Show($"Rol registrado con éxito. ID: {idRol}",
                                    "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                return idRol;
                            }
                        }
                        catch (Exception ex)
                        {
                            await transaction.RollbackAsync(); // Revertir la transacción en caso de error
                            MessageBox.Show($"Error al registrar el rol: {ex.Message}",
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
