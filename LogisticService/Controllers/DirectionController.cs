using LogisticService.Models;
using LogisticService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LogisticService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectionController : ControllerBase
    {
        private readonly IRepository<Direction, CrashedRequest> repository;

        public DirectionController(IRepository<Direction, CrashedRequest> repository)
        {
            this.repository = repository;
        }

        [HttpGet("Get")]
        public IActionResult Get(int id)
        {
            return Ok(repository.Get(id));
        }

        [HttpPost]
        public IActionResult Add(Direction direction)
        {
            repository.Add(direction);
            return Ok();
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(repository.GetAll());
        }

        [HttpPut]
        public IActionResult Update(Direction direction)
        {
            repository.Update(direction);
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(Direction direction)
        {
            repository.Delete(direction);
            return Ok();
        }
    }
}
