using ExpanseTracker.Dal.Repositories.StatisticsRepository;
using ExpanseTracker.Dto.Statistics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpanseTracker.Bll.Repositories.StatisticsRepository
{
    public class StatisticsBllRepository : IStatisticsBllRepository
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public StatisticsBllRepository(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<TotalCountDto> TotalCountBetweenDates(DateTime firstDate, DateTime secondDate)
        {
            try
            {
                var result = await _statisticsRepository.GetTotalCountBetweenDates(firstDate, secondDate);

                return new TotalCountDto { Count = result.Count };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
