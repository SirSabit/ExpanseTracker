using ExpanseTracker.Api.Models.Statistics.Monthly;
using ExpanseTracker.Api.Models.Statistics.Yearly;
using ExpanseTracker.Bll.Repositories.StatisticsRepository;
using Microsoft.AspNetCore.Mvc;

namespace ExpanseTracker.Api.Controllers.StatisticsControllers
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

        [HttpPost("/yearly-total-expanse")]
        public IActionResult YearlyTotalExpanse(YearlyTotalExpanseRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = _statisticsBllRepository.YearlyTotalExpanse(request.Year);

                return Ok(result.Result);
            }
            return BadRequest();
        }

        [HttpPost("/monthly-total-expanse")]
        public IActionResult MonthlyTotalExpanse(MonthlyTotalExpanseRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = _statisticsBllRepository.MonthlyTotalExpanse(request.Month).Result;

                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("/weekly-total-expanse")]
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
