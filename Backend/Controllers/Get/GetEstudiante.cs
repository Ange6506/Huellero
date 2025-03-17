using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using Huellero.Backend.DatabaseConnection;

namespace Huellero.Controllers
{
    public class GetEstudiante
    {
        private readonly DatabaseConnection _databaseConnection;

        public GetEstudiante()
        {
            _databaseConnection = new DatabaseConnection();
        }

        public async Task<IEnumerable<EstudianteDTO>> ObtenerEstudiantesAsync()
        {
            try
            {
                using (var connection = await _databaseConnection.GetConnectionAsync())
                {
                    var sql = @"
                        SELECT e.id_estudiantes AS IdEstudiante,
                               e.nombre_del_estudiante AS NombreCompleto,
                               e.identificacion,
                               p.programa,
                               sa.fecha_inicio AS FechaInicio,
                               sa.fecha_terminacion AS FechaFinal,
                               sa.asignatura,
                               sa.especialidad AS Especialidad,
                               sa.dias_semana AS DiasSemana,
                               sa.horas_por_dia AS HorasPorDia,
                               sa.semanas_de_rotacion AS SemanasDeRotacion,
                               sa.numero_horas_semanales AS NumeroHorasSemanales,
                               sa.semestre_academico AS SemestreAcademico
                        FROM estudiantes e
                        JOIN est_x_semestre exs ON e.id_estudiantes = exs.id_estudiante
                        JOIN semestre_academico sa ON exs.id_semestre = sa.id_semestre
                        JOIN programa p ON sa.id_programa = p.id_programa";

                    var estudiantes = await connection.QueryAsync<EstudianteDTO>(sql);

                    // 🛠️ Depurar datos en la consola
                    foreach (var estudiante in estudiantes)
                    {
                        Console.WriteLine($"ID: {estudiante.IdEstudiante}, Nombre: {estudiante.NombreCompleto}, " +
                                          $"Especialidad: {estudiante.Especialidad}, Días: {estudiante.DiasSemana}, " +
                                          $"Horas por día: {estudiante.HorasPorDia}, Rotación: {estudiante.SemanasDeRotacion}, " +
                                          $"Horas semanales: {estudiante.NumeroHorasSemanales}");
                    }

                    return estudiantes;
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener estudiantes: {ex.Message}");
            }
        }

        // Clase DTO dentro de GetEstudiante
        public class EstudianteDTO
        {
            public int IdEstudiante { get; set; }
            public string NombreCompleto { get; set; }
            public string Identificacion { get; set; }
            public string Programa { get; set; }
            public DateTime FechaInicio { get; set; }
            public DateTime FechaFinal { get; set; }
            public string Asignatura { get; set; }
            public string Especialidad { get; set; }
            public string DiasSemana { get; set; }
            public int HorasPorDia { get; set; }
            public int SemanasDeRotacion { get; set; }
            public int NumeroHorasSemanales { get; set; }
            public string SemestreAcademico { get; set; }
        }
    }
}
