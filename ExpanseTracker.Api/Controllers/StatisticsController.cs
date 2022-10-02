using ExpanseTracker.Api.Models.StatisticModels;
using ExpanseTracker.Bll.Repositories.StatisticsRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpanseTracker.Api.Controllers
{
    [Route("statistics")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsBllRepository _statisticsBllRepository;
        public StatisticsController(IStatisticsBllRepository statisticsBllRepository)
        {
            _statisticsBllRepository = statisticsBllRepository;
        }

        [HttpPost("/total-amount")]
        public IActionResult GetTotalCountBetweenDates(TotalCountBetweenDatesRequestModel request)
        {
            if (ModelState.IsValid)
            {
                var result = _statisticsBllRepository.TotalCountBetweenDates(request.FirstDate, request.SecondDate).Result;

                return Ok(result);
            }
            return BadRequest();
        }
    }
}
