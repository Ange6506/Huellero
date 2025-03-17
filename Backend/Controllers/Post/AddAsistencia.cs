using System;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Npgsql;
using DPFP;
using DPFP.Verification;
using Huellero.Backend.DatabaseConnection;

namespace Huellero.Controllers.Post
{
    public class AddAsistenciaController : ControllerBase
    {
        private readonly DatabaseConnection _databaseConnection;
        private readonly Verification _verificator = new Verification();

        public AddAsistenciaController()
        {
            _databaseConnection = new DatabaseConnection();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsistencia([FromBody] dynamic data)
        {
            byte[] huellaBytes = data?.huella;
            if (huellaBytes == null || huellaBytes.Length == 0)
            {
                return BadRequest(new { message = "Huella es requerida." });
            }

            try
            {
                using (var connection = await _databaseConnection.GetConnectionAsync())
                {
                    string sql = "SELECT id_estudiantes, huella FROM estudiantes";
                    using (var cmd = new NpgsqlCommand(sql, connection))
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            int idEstudiante = reader.GetInt32(0);
                            byte[] huellaDB = (byte[])reader["huella"];

                            using (MemoryStream ms = new MemoryStream(huellaDB))
                            {
                                DPFP.Template templateDB = new DPFP.Template(ms);
                                DPFP.FeatureSet featureSet = new DPFP.FeatureSet();
                                featureSet.DeSerialize(huellaBytes);

                                Verification.Result result = new Verification.Result();
                                _verificator.Verify(featureSet, templateDB, ref result);

                                if (result.Verified)
                                {
                                    reader.Close();
                                    return await RegistrarAsistencia(idEstudiante, connection);
                                }
                            }
                        }
                    }
                }
                return BadRequest(new { message = "Huella no reconocida." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error en el servidor.", error = ex.Message });
            }
        }

        private async Task<IActionResult> RegistrarAsistencia(int idEstudiante, NpgsqlConnection connection)
        {
            try
            {
                string sqlSemestre = "SELECT id_est_x_semestre FROM est_x_semestre WHERE id_estudiante = @id";
                int? idEstXSemestre = null;

                using (var cmdSemestre = new NpgsqlCommand(sqlSemestre, connection))
                {
                    cmdSemestre.Parameters.AddWithValue("id", idEstudiante);
                    idEstXSemestre = (int?)await cmdSemestre.ExecuteScalarAsync();
                }

                if (!idEstXSemestre.HasValue)
                {
                    return BadRequest(new { message = "Estudiante no está registrado en un semestre." });
                }

                string sqlAsistencia = "SELECT id_asistencia, fecha_hora_entrada FROM asistencia WHERE id_est_x_semestre = @id AND fecha_hora_salida IS NULL LIMIT 1";
                int? idAsistencia = null;
                DateTime? fechaEntrada = null;

                using (var cmdAsistencia = new NpgsqlCommand(sqlAsistencia, connection))
                {
                    cmdAsistencia.Parameters.AddWithValue("id", idEstXSemestre);
                    using (var reader = await cmdAsistencia.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            idAsistencia = reader.GetInt32(0);
                            fechaEntrada = reader.GetDateTime(1);
                        }
                    }
                }

                if (idAsistencia.HasValue)
                {
                    if (fechaEntrada.HasValue && (DateTime.UtcNow - fechaEntrada.Value).TotalMinutes < 3)
                    {
                        return BadRequest(new { message = "Debe esperar al menos 3 minutos antes de registrar la salida." });
                    }

                    string sqlUpdate = "UPDATE asistencia SET fecha_hora_salida = NOW() WHERE id_asistencia = @id RETURNING fecha_hora_salida";
                    DateTime fechaSalida;

                    using (var cmdUpdate = new NpgsqlCommand(sqlUpdate, connection))
                    {
                        cmdUpdate.Parameters.AddWithValue("id", idAsistencia.Value);
                        fechaSalida = (DateTime)await cmdUpdate.ExecuteScalarAsync();
                    }

                    return Ok(new
                    {
                        message = "Salida registrada exitosamente.",
                        id_asistencia = idAsistencia,
                        fecha_hora_entrada = fechaEntrada,
                        fecha_hora_salida = fechaSalida
                    });
                }
                else
                {
                    string sqlInsert = "INSERT INTO asistencia (fecha_hora_entrada, id_est_x_semestre) VALUES (NOW(), @id) RETURNING id_asistencia, fecha_hora_entrada";
                    using (var cmdInsert = new NpgsqlCommand(sqlInsert, connection))
                    {
                        cmdInsert.Parameters.AddWithValue("id", idEstXSemestre);
                        using (var reader = await cmdInsert.ExecuteReaderAsync())
                        {
                            await reader.ReadAsync();
                            return Created("", new
                            {
                                message = "Entrada registrada exitosamente.",
                                id_asistencia = reader.GetInt32(0),
                                fecha_hora_entrada = reader.GetDateTime(1)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error al registrar asistencia.", error = ex.Message });
            }
        }
    }
}
