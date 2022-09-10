using ExpanseTracker.Bll.Repositories.ExpanseRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpanseTracker.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpanseController : ControllerBase
    {
        IExpanseBllRepository _expanseBllRepository;
        public ExpanseController(IExpanseBllRepository expanseBllRepository)
        {
            _expanseBllRepository = expanseBllRepository;
        }

        [HttpGet]
        public IActionResult GetExpanses()
        {
            var data = _expanseBllRepository.GetAllExpanses().Result;

            return Ok(data);
        }

        [HttpGet("/id")]
        public IActionResult GetExpanseById(int id)
        {
            var data = _expanseBllRepository.GetById(id).Result;

            return Ok(data);
        }
    }
}
