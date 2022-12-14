using ExpanseTracker.Dal.Repositories.StatisticsRepository;
using ExpanseTracker.Dto.Enums;
using ExpanseTracker.Dto.Statistics;

namespace ExpanseTracker.Bll.Repositories.StatisticsRepository
{
    public class StatisticsBllRepository : IStatisticsBllRepository
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public StatisticsBllRepository(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<TotalCountDto> MonthlyTotalExpanse(MonthEnum month)
        {
            try
            {
                DateTime today = DateTime.Today;

                DateTime firstDate = new DateTime(today.Year, (int)month, 1);
                DateTime lastDate = new DateTime(today.Year, (int)month, DateTime.DaysInMonth(today.Year, (int)month));

                var result = await _statisticsRepository.GetTotalCountBetweenDates(firstDate, lastDate);

                return new TotalCountDto { Count = result.Count };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TotalCountDto> YearlyTotalExpanse(int year)
        {
            DateTime firstDate = new DateTime(year, 1, 1);
            DateTime lastDate = new DateTime(year, 12, 31);

            var result = await _statisticsRepository.GetTotalCountBetweenDates(firstDate, lastDate);

            return new TotalCountDto { Count = result.Count };
        }

        public async Task<TotalCountDto> TotalExpanseOfLastSevenDays()
        {
            var secondDate = DateTime.Today;
            var firstDate = secondDate.AddDays(-7);

            var result = await _statisticsRepository.GetTotalCountBetweenDates(firstDate, secondDate);

            return new TotalCountDto { Count = result.Count };
        }
    }
}
