using Npgsql;
using System;
using System.Threading.Tasks;
using Dapper;
using Huellero.Backend.DatabaseConnection; // Asegúrate de que el namespace sea correcto

namespace Huellero.Controllers
{
    internal class UpdateEstudiante
    {
        private readonly DatabaseConnection _databaseConnection;

        public UpdateEstudiante()
        {
            _databaseConnection = new DatabaseConnection();
        }

        public async Task<bool> EditarEstudianteAsync(int idEstudiante, string programa, string semestreAcademico,
                                                      string asignatura, string especialidad, string diaSemana,
                                                      int semanaRotacion, int horaPorDia, int numeroHorasSemanales,
                                                      DateTime fechaInicio, DateTime fechaFinal)
        {
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
                            var sql = @"
                            -- Actualizamos la relación del estudiante con el programa
                            UPDATE semestre_academico
                            SET id_programa = (SELECT id_programa FROM programa WHERE programa = @Programa)
                            WHERE id_semestre = (SELECT id_semestre FROM est_x_semestre WHERE id_estudiante = @IdEstudiante);

                            -- Actualizamos la información del semestre académico
                            UPDATE semestre_academico
                            SET asignatura = @Asignatura,
                                especialidad = @Especialidad,
                                dias_semana = @DiaSemana,
                                horas_por_dia = @HoraPorDia,
                                semanas_de_rotacion = @SemanaRotacion,
                                numero_horas_semanales = @NumeroHorasSemanales,
                                fecha_inicio = @FechaInicio,
                                fecha_terminacion = @FechaFinal
                            WHERE id_semestre = (SELECT id_semestre FROM est_x_semestre WHERE id_estudiante = @IdEstudiante);";

                            var rowsAffected = await connection.ExecuteAsync(sql, new
                            {
                                IdEstudiante = idEstudiante,
                                Programa = programa,
                                Asignatura = asignatura,
                                Especialidad = especialidad,
                                DiaSemana = diaSemana,
                                HoraPorDia = horaPorDia,
                                SemanaRotacion = semanaRotacion,
                                NumeroHorasSemanales = numeroHorasSemanales,
                                FechaInicio = fechaInicio,
                                FechaFinal = fechaFinal
                            }, transaction);

                            await transaction.CommitAsync();

                            Console.WriteLine($"Filas afectadas: {rowsAffected}");
                            return rowsAffected > 0;
                        }
                        catch (Exception ex)
                        {
                            await transaction.RollbackAsync();
                            Console.WriteLine($"Error en EditarEstudianteAsync (rollback ejecutado): {ex.Message}");
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error en la conexión o ejecución de EditarEstudianteAsync: {ex.Message}");
                return false;
            }
        }
    }
}
