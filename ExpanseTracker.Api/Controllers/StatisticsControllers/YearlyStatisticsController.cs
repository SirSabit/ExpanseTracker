using ExpanseTracker.Api.Models.Statistics.Yearly;
using ExpanseTracker.Bll.Repositories.StatisticsRepository;
using Microsoft.AspNetCore.Mvc;

namespace ExpanseTracker.Api.Controllers.StatisticsControllers
{
    [Route("yearly-statistics")]
    [ApiController]
    public class YearlyStatisticsController : ControllerBase
    {
        private readonly IStatisticsBllRepository _statisticsBllRepository;

        public YearlyStatisticsController(IStatisticsBllRepository statisticsBllRepository)
        {
            _statisticsBllRepository = statisticsBllRepository;
        }

        [HttpPost("/total-expanse")]
        public IActionResult YearlyTotalExpanse(YearlyTotalExpanseRequest request)
        {
            if (ModelState.IsValid)
            {
                var result = _statisticsBllRepository.YearlyTotalExpanse(request.Year);

                return Ok(result.Result);
            }
            return BadRequest();
        }

    }
}
