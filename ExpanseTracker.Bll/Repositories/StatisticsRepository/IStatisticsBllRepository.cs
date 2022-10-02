using ExpanseTracker.Dto.Statistics;

namespace ExpanseTracker.Bll.Repositories.StatisticsRepository
{
    public interface IStatisticsBllRepository
    {
        /// <summary>
        /// Get the total Count of the Amount Between two spesific Dates
        /// </summary>
        /// <param name="firstDate">First Date</param>
        /// <param name="secondDate">Second Date</param>
        /// <returns>Returns total expanse amount</returns>
        Task<TotalCountDto> TotalCountBetweenDates(DateTime firstDate, DateTime secondDate);
    }
}