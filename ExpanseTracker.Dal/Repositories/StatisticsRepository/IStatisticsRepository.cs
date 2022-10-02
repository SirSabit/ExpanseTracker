using ExpanseTracker.Entities;

namespace ExpanseTracker.Dal.Repositories.StatisticsRepository
{
    public interface IStatisticsRepository
    {
        Task<StatisticEntity> GetTotalCountBetweenDates(DateTime firstDate, DateTime secondDate);
    }
}