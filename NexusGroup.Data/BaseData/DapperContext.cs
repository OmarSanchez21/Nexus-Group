
using System.Data;
using System.Data.SqlClient;


namespace NexusGroup.Data.BaseData
{
    public interface IDapperContext
    {
        IDbConnection CreateConnection();
    }
    internal class DapperContext : IDapperContext
    {
        private readonly string _connectionString;
        public DapperContext(string connection)
        {
            _connectionString = connection;
        }
        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
