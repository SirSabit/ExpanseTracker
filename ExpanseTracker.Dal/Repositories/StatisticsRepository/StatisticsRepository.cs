﻿using Dapper;
using ExpanseTracker.Dal.DataAccess.PostgreDataAccess;
using ExpanseTracker.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpanseTracker.Dal.Repositories.StatisticsRepository
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly string _tableName = "public.\"Expanses\"";
        private readonly IPGDataAccess<StatisticEntity> _pGDataAccess;
        public StatisticsRepository(IPGDataAccess<StatisticEntity> pGDataAccess)
        {
            _pGDataAccess = pGDataAccess;
        }

        public async Task<StatisticEntity> GetTotalCountBetweenDates(DateTime firstDate, DateTime secondDate)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("FirstDate", firstDate);
            parameters.Add("SecondDate", secondDate);

            StringBuilder query = new StringBuilder();
            query.Append($"SELECT SUM(\"ExpanseAmount\") AS \"Count\" FROM {_tableName} ");
            query.Append($"WHERE \"ExpanseDate\" >= :FirstDate ");
            query.Append($"AND \"ExpanseDate\" < :SecondDate ; ");

            return await _pGDataAccess.GetDataAsync(query.ToString(), parameters);
        }
    }
}
