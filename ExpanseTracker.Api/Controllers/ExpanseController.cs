using ExpanseTracker.Api.Models;
using ExpanseTracker.Bll.Repositories.ExpanseRepositories;
using ExpanseTracker.Dto;
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
            var data = _expanseBllRepository.GetAllExpanses();

            data.Wait();

            if (data.IsCompletedSuccessfully)
                return Ok(data.Result);

            return BadRequest(data.Result);
        }

        [HttpGet("/id")]
        public IActionResult GetExpanseById(int id)
        {
            var data = _expanseBllRepository.GetById(id);

            data.Wait();

            if (data.IsCompletedSuccessfully)
                return Ok(data.Result);

            return BadRequest(data.Result);
        }

        [HttpPost]
        public IActionResult Insert(ExpanseInsertModel model)
        {
            var entity = new ExpanseDto()
            {
                ExpanseAmount = model.ExpanseAmount,
                ExpanseDate = model.ExpanseDate,
                ExpanseName = model.ExpanseName
            };

            var insert = _expanseBllRepository.Insert(entity);

            insert.Wait();

            if (insert.IsCompletedSuccessfully)
                return Ok();

            return BadRequest(insert);
        }

        [HttpPut]
        public IActionResult Update(ExpanseUpdateModel model)
        {
            var entity = new ExpanseDto()
            {
                ID = model.ID,
                ExpanseAmount = model.ExpanseAmount,
                ExpanseDate = model.ExpanseDate,
                ExpanseName = model.ExpanseName
            };

            var update = _expanseBllRepository.Update(entity);

            update.Wait();

            if (update.IsCompletedSuccessfully)
                return Ok();

            return BadRequest(update);
        }

        [HttpDelete("/id")]
        public IActionResult Delete(int id)
        {
            var entity = new ExpanseDto()
            {
                ID = id
            };

            var delete = _expanseBllRepository.Delete(entity);

            delete.Wait();

            if (delete.IsCompletedSuccessfully)
                return Ok();

            return BadRequest(delete);
        }
    }
}
