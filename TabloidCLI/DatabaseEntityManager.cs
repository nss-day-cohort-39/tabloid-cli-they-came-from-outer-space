using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace TabloidCLI
{
    public class DatabaseEntityManager
    {
        private readonly string _connectionString;
        protected SqlConnection Connection => new SqlConnection(_connectionString);

        public DatabaseEntityManager(string connectionString)
        {
            _connectionString = connectionString;
        }
    }
}
