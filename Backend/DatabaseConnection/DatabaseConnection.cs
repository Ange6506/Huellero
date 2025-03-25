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
        private readonly string _connectionString = "Host=10.30.1.238;Port=5432;Database=Register_DB;Username=postgres;Password=Admin";
        public async Task<NpgsqlConnection> GetConnectionAsync()
        {
            var connection = new NpgsqlConnection(_connectionString);
            await connection.OpenAsync();
            return connection;
        }
    }
}
