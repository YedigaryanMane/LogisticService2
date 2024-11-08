using LogisticService.Models;
using LogisticService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LogisticService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrashedController : ControllerBase
    {
        private readonly IRepository<Crashed, CrashedRequest> _repository;

        public CrashedController(IRepository<Crashed, CrashedRequest> repository)
        {
            _repository = repository;
        }

        [HttpGet("Get")]

        public IActionResult Get(int id)
        {
            return Ok(_repository.Get(id));
        }

        [HttpPost]

        public IActionResult Add(Crashed crashed)
        {
            _repository.Add(crashed);
            return Ok();
        }

        [HttpDelete]

        public IActionResult Delete(Crashed crashed)
        {
            _repository.Delete(crashed);
            return Ok();
        }

        [HttpPut]

        public IActionResult Update(Crashed crashed)
        {
            _repository.Update(crashed);
            return Ok();
        }

        [HttpGet("GetAll")]

        public IActionResult GetAll()
        {
            return Ok(_repository.GetAll());
        }
    }
}
