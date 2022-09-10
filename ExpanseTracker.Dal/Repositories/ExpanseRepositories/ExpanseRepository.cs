using Dapper;
using ExpanseTracker.Dal.DataAccess.PostgreDataAccess;
using ExpanseTracker.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpanseTracker.Dal.Repositories.ExpanseRepositories
{
    public class ExpanseRepository : IExpanseRepository
    {
        private readonly IPGDataAccess<ExpanseEntity> _dataAccess;

        private readonly string TableName = "Expanses";
        public ExpanseRepository(IPGDataAccess<ExpanseEntity> dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task InsertExpanseAsync(ExpanseEntity entity)
        {
            StringBuilder query = new StringBuilder();
            query.Append($"INSERT INTO public.\"{TableName}\"(");
            query.Append($"\"ExpanseName\", \"ExpanseAmount\", \"ExpanseDate\", \"IsDeleted\")");
            query.Append($"VALUES (@Expanse_Name, @Expanse_Amount, @Expanse_Date, @Is_Deleted);");

            var data = PrepareDynamicParameters(entity);

            await _dataAccess.ExecuteQuery(query.ToString(), data);
        }

        public async Task UpdateExpanseAsync(ExpanseEntity entity)
        {
            StringBuilder query = new StringBuilder();
            query.Append($"UPDATE public.\"{TableName}\"");
            query.Append($"SET \"ExpanseName\"=@Expanse_Name, \"ExpanseAmount\"=@Expanse_Amount, \"ExpanseDate\"= @Expanse_Date, \"IsDeleted\"=@Is_Deleted");
            query.Append($"WHERE \"ID\"= @Id;");

            var data = PrepareDynamicParameters(entity);

            await _dataAccess.ExecuteQuery(query.ToString(), data);
        }

        public async Task DeleteExpanseAsync(ExpanseEntity entity)
        {
            StringBuilder query = new StringBuilder();
            query.Append($"UPDATE public.\"{TableName}\"");
            query.Append($"SET \"IsDeleted\"=@Is_Deleted");
            query.Append($"WHERE \"ID\"= @Id;");

            var data = PrepareDynamicParameters(entity);

            await _dataAccess.ExecuteQuery(query.ToString(), data);
        }

        public async Task<ExpanseEntity> GetExpanseByIdAsync(int id)
        {
            StringBuilder query = new StringBuilder();
            query.Append($"SELECT * from public.\"{TableName}\"");
            query.Append($"WHERE \"ID\" = {id} AND \"IsDeleted\" = false");

            return await _dataAccess.GetDataAsync(query.ToString());
        }

        public async Task<IEnumerable<ExpanseEntity>> GetAllExpansesAsync()
        {
            StringBuilder query = new StringBuilder();
            query.Append($"SELECT * from public.\"{TableName}\"");
            query.Append($"WHERE \"IsDeleted\" = false");

            return await _dataAccess.GetAllDataAsync(query.ToString());
        }

        private DynamicParameters PrepareDynamicParameters(ExpanseEntity entity)
        {
            DynamicParameters data = new DynamicParameters();
            data.Add("Id", entity.ID, System.Data.DbType.Int32);
            data.Add("Expanse_Name", entity.ExpanseName, System.Data.DbType.String);
            data.Add("Expanse_Amount", entity.ExpanseAmount, System.Data.DbType.Decimal);
            data.Add("Expanse_Date", entity.ExpanseDate, System.Data.DbType.Date);
            data.Add("Is_Deleted", entity.IsDeleted, System.Data.DbType.Boolean);

            return data;
        }
    }
}
