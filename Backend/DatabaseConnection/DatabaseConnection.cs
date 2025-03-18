using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huellero.Backend.DatabaseConnection
{
    class DatabaseConnection
    {
        private readonly string _connectionString = "Host=localhost;Username=postgres;Password=Admin;Database=Register;CommandTimeout=30";

        public async Task<NpgsqlConnection> GetConnectionAsync()
        {
            var connection = new NpgsqlConnection(_connectionString);
            await connection.OpenAsync();
            return connection;
        }
    }
}
