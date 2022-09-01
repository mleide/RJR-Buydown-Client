using System.Data.SqlClient;

namespace CDI.RJR.Data
{
    class Database
    {
        readonly string _connectionString;

        public Database(string connectionString) =>
            _connectionString = connectionString;

        public SqlConnection OpenConnection()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}