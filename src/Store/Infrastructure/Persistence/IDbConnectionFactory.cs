using System.Data;
using Npgsql;

namespace Store.Infrastructure.Persistence
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
    }

    public class PostgreSqlConnectionFactory : IDbConnectionFactory
    {
        private readonly string _connectionString;

        public PostgreSqlConnectionFactory(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        public IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }
    }
}