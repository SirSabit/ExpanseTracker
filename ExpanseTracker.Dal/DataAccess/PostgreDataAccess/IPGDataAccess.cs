using Dapper;

namespace ExpanseTracker.Dal.DataAccess.PostgreDataAccess
{
    public interface IPGDataAccess<T>
    {
        /// <summary>
        /// Single insert/update/delete process
        /// </summary>
        /// <param name="query">Sql query</param>
        /// <param name="data">Dynamic parameters that needs to be inserted/updated/deleted</param>
        /// <returns>Doesn't return anything</returns>
        Task ExecuteQuery(string query, DynamicParameters data);
        /// <summary>
        /// Makes a query request to db
        /// </summary>
        /// <typeparam name="T">Generic class equals to the table that you want to get</typeparam>
        /// <param name="query">Sql query</param>
        /// <returns>Returns a sequence of data T</returns>
        Task<IEnumerable<T>> GetAllDataAsync(string query);
        /// <summary>
        /// Makes a queryfirst request to db
        /// </summary>
        /// <param name="query">Sql query</param>
        /// <returns>Returns a single row query</returns>
        Task<T> GetDataAsync(string query);
    }
}