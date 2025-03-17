using System;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using Huellero.Backend.DatabaseConnection;

namespace Huellero.Controllers
{
    public class AddEstudiante
    {
        private readonly DatabaseConnection _databaseConnection;

        public AddEstudiante()
        {
            _databaseConnection = new DatabaseConnection();
        }

        public async Task<(bool success, string message)> AddEstudianteAsync(
     byte[] huella, string nombreDelEstudiante, string identificacion, string programa,
     string asignatura, string especialidad, DateTime fechaInicio, DateTime fechaTerminacion,
     string diasSemana, int horasPorDia, int semanasDeRotacion, int numeroHorasSemanales, string semestreAcademico)
        {
            using (var connection = await _databaseConnection.GetConnectionAsync())
            {
                if (connection.State != ConnectionState.Open)
                {
                    await connection.OpenAsync();
                }

                var existe = await connection.ExecuteScalarAsync<int>(
                    "SELECT COUNT(*) FROM estudiantes WHERE encode(huella, 'hex') = encode(@Huella, 'hex') OR identificacion = @Identificacion",
                    new { Huella = huella, Identificacion = identificacion });

                if (existe > 0)
                {
                    return (false, "El estudiante ya está registrado con esa huella o identificación.");
                }

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var estudianteId = await connection.ExecuteScalarAsync<int>(
                            "INSERT INTO estudiantes (huella, nombre_del_estudiante, identificacion) VALUES (@Huella, @NombreDelEstudiante, @Identificacion) RETURNING id_estudiantes",
                            new { Huella = huella, NombreDelEstudiante = nombreDelEstudiante, Identificacion = identificacion },
                            transaction);

                        var programaId = await connection.ExecuteScalarAsync<int?>(
                            "SELECT id_programa FROM programa WHERE programa = @Programa",
                            new { Programa = programa });

                        if (programaId == null)
                        {
                            await transaction.RollbackAsync();
                            return (false, "Programa no encontrado.");
                        }

                        var semestreId = await connection.ExecuteScalarAsync<int>(
                            "INSERT INTO semestre_academico (id_programa, asignatura, especialidad, fecha_inicio, fecha_terminacion, dias_semana, horas_por_dia, semanas_de_rotacion, numero_horas_semanales, semestre_academico) " +
                            "VALUES (@ProgramaId, @Asignatura, @Especialidad, @FechaInicio, @FechaTerminacion, @DiasSemana, @HorasPorDia, @SemanasDeRotacion, @NumeroHorasSemanales, @SemestreAcademico) RETURNING id_semestre",
                            new
                            {
                                ProgramaId = programaId,
                                Asignatura = asignatura,
                                Especialidad = especialidad,
                                FechaInicio = fechaInicio,
                                FechaTerminacion = fechaTerminacion,
                                DiasSemana = diasSemana,
                                HorasPorDia = horasPorDia,
                                SemanasDeRotacion = semanasDeRotacion,
                                NumeroHorasSemanales = numeroHorasSemanales,
                                SemestreAcademico = semestreAcademico
                            },
                            transaction);

                        await connection.ExecuteAsync(
                            "INSERT INTO est_x_semestre (id_estudiante, id_semestre) VALUES (@EstudianteId, @SemestreId)",
                            new { EstudianteId = estudianteId, SemestreId = semestreId },
                            transaction);

                        await transaction.CommitAsync();
                        return (true, "Estudiante registrado exitosamente.");
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        return (false, $"Error en la inserción: {ex.Message}");
                    }
                
    }
}
        }
    }
}