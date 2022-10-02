using ExpanseTracker.Api.Models.Statistics.Monthly;
using ExpanseTracker.Bll.Repositories.StatisticsRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpanseTracker.Api.Controllers.StatisticsControllers
{
    [Route("monthly-statistics")]
    [ApiController]
    public class MonthlyStatisticsController : ControllerBase
    {
        private readonly IStatisticsBllRepository _statisticsBllRepository;

        public MonthlyStatisticsController(IStatisticsBllRepository statisticsBllRepository)
        {
            _statisticsBllRepository = statisticsBllRepository; 
        }

        [HttpPost]
        public IActionResult MonthlyTotalExpanse(MonthlyTotalExpanseRequest request) {

            if (ModelState.IsValid)
            {
                var result = _statisticsBllRepository.MonthlyTotalExpanse(request.Month).Result;

                return Ok(result);
            }
            return BadRequest();
        }
    }
}
