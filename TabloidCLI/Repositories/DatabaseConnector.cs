using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace TabloidCLI.Repositories
{
    public class DatabaseConnector
    {
        private readonly string _connectionString;
        protected SqlConnection Connection => new SqlConnection(_connectionString);

        public DatabaseConnector(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
