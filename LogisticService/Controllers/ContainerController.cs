using LogisticService.Models;
using LogisticService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LogisticService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContainerController : ControllerBase
    {
        private readonly IRepository<Containers, ContainerRequest> repository;

        public ContainerController(IRepository<Containers, ContainerRequest> repository)
        {
            this.repository = repository;
        }

        [HttpGet("Get")]
        public IActionResult Get(int id)
        {
            return Ok(repository.Get(id));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(repository.GetAll());
        }

        [HttpDelete]
        public IActionResult Delete(Containers container)
        {
            repository.Delete(container);
            return Ok();
        }

        [HttpPost]
        public IActionResult Add(Containers container)
        {
            repository.Add(container);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Containers container)
        {
            repository.Update(container);
            return Ok();
        }
    }
}
