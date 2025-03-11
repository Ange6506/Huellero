using Npgsql;
using System.Threading.Tasks;
using System;
using Dapper;

namespace Huellero.Controllers
{
    internal class UpdateEstudiante
    {
        private readonly string connectionString = "Host=localhost;Username=postgres;Password=Admin;Database=RegisterAttendance;CommandTimeout=30";

        public UpdateEstudiante()
        {
            // Constructor vacío
        }

        public async Task<bool> EditarEstudianteAsync(int idEstudiante, string programa, string semestreAcademico,
                                                      string asignatura, string especialidad, string diaSemana,
                                                      int semanaRotacion, int horaPorDia, int numeroHorasSemanales,
                                                      DateTime fechaInicio, DateTime fechaFinal)
        {
            try
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    await connection.OpenAsync();

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

                            await transaction.CommitAsync(); // Confirmar cambios

                            Console.WriteLine($"Filas afectadas: {rowsAffected}");
                            return rowsAffected > 0;
                        }
                        catch (Exception ex)
                        {
                            await transaction.RollbackAsync(); // Deshacer cambios si hay error
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
