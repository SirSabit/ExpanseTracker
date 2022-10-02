using ExpanseTracker.Dto.Enums;
using ExpanseTracker.Dto.Statistics;

namespace ExpanseTracker.Bll.Repositories.StatisticsRepository
{
    public interface IStatisticsBllRepository
    {
        /// <summary>
        /// Calculates monthly expanse amount
        /// </summary>
        /// <param name="month">Requested month parameter</param>
        /// <returns>Decimal Monthly Expanse Amount</returns>
        Task<TotalCountDto> MonthlyTotalExpanse(MonthEnum month);
    }
}