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

        /// <summary>
        /// Calculaters yearly expanse amount
        /// </summary>
        /// <param name="year">Requested year parameter</param>
        /// <returns>Decimal Yearly Expanse Amount</returns>
        Task<TotalCountDto> YearlyTotalExpanse(int year);
        /// <summary>
        /// Calculates the total expanse of last 7 days
        /// </summary>
        /// <returns>Decimal weekly expanse amount</returns>
        Task<TotalCountDto> TotalExpanseOfLastSevenDays();
    }
}