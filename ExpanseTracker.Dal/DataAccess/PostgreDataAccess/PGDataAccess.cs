using Dapper;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace ExpanseTracker.Dal.DataAccess.PostgreDataAccess
{
    public class PGDataAccess<T> : IPGDataAccess<T>
    {
        private readonly IConfiguration _configuration;
        private string ConnectionString = "ExpansetrackerDbConnection";


        public PGDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        public async Task<IEnumerable<T>> GetAllDataAsync(string query)
        {
            using (IDbConnection dbConnection = new NpgsqlConnection(_configuration.GetConnectionString(ConnectionString)))
            {
                return await dbConnection.QueryAsync<T>(query);
            };
        }

        public async Task<T> GetDataAsync(string query)
        {
            using (IDbConnection dbConnection = new NpgsqlConnection(_configuration.GetConnectionString(ConnectionString)))
            {
                return await dbConnection.QueryFirstAsync<T>(query);
            }
        }

        public async Task<T> GetDataAsync(string query, DynamicParameters parameters)
        {
            using (IDbConnection dbConnection = new NpgsqlConnection(_configuration.GetConnectionString(ConnectionString)))
            {
                return await dbConnection.QueryFirstAsync<T>(query, parameters);
            }
        }


        public async Task ExecuteQuery(string query, DynamicParameters data)
        {
            using (IDbConnection dbConnection = new NpgsqlConnection(_configuration.GetConnectionString(ConnectionString)))
            {
                await dbConnection.ExecuteAsync(query, data);
            }
        }
    }
}
