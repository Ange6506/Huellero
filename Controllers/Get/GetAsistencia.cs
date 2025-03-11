using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Npgsql;

namespace Huellero.Controllers.Get
{
    public class GetAsistencia
    {
        private readonly string _connectionString = "Host=localhost;Username=postgres;Password=Admin;Database=RegisterAttendance;CommandTimeout=30";

        public async Task<List<dynamic>> GetAsistenciaAsync()
        {
            List<dynamic> asistencias = new List<dynamic>();

            try
            {
                using (var connection = new NpgsqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    string query = @"
                        SELECT p.programa, a.fecha_hora_entrada, a.fecha_hora_salida, 
                               e.identificacion, e.nombre_del_estudiante 
                        FROM public.asistencia a
                        JOIN public.est_x_semestre es ON a.id_est_x_semestre = es.id_est_x_semestre
                        JOIN public.estudiantes e ON es.id_estudiante = e.id_estudiantes
                        JOIN public.semestre_academico sa ON es.id_semestre = sa.id_semestre
                        JOIN public.programa p ON sa.id_programa = p.id_programa 
                        ORDER BY a.fecha_hora_entrada DESC";

                    using (var command = new NpgsqlCommand(query, connection))
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var asistencia = new
                            {
                                Programa = reader.GetString(0),
                                FechaHoraEntrada = reader.GetDateTime(1).ToString("yyyy-MM-dd HH:mm:ss"),
                                FechaHoraSalida = reader.IsDBNull(2) ? "No registrada" : reader.GetDateTime(2).ToString("yyyy-MM-dd HH:mm:ss"),
                                Cedula = reader.GetString(3),
                                NombreCompleto = reader.GetString(4)
                            };
                            asistencias.Add(asistencia);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener asistencias: {ex.Message}");
            }

            return asistencias;
        }
    }
}
