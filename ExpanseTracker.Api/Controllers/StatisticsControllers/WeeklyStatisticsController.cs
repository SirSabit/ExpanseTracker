using ExpanseTracker.Bll.Repositories.StatisticsRepository;
using Microsoft.AspNetCore.Mvc;

namespace ExpanseTracker.Api.Controllers.StatisticsControllers
{
    [Route("weekly-statistics")]
    [ApiController]
    public class WeeklyStatisticsController : ControllerBase
    {
        IStatisticsBllRepository _statisticsBllRepository;

        public WeeklyStatisticsController(IStatisticsBllRepository statisticsBllRepository)
        {
            _statisticsBllRepository = statisticsBllRepository;
        }

        [HttpGet]
        public IActionResult TotalExpanseOfLastSevenDays()
        {
            if (ModelState.IsValid)
            {
                var result = _statisticsBllRepository.TotalExpanseOfLastSevenDays().Result;

                return Ok(result);
            }
            return BadRequest();
        }
    }
}
