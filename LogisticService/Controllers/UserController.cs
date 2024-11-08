using LogisticService.Models;
using LogisticService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LogisticService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRepository<User, UserRequest> repository;

        public UserController(IRepository<User, UserRequest> repository)
        {
            this.repository = repository;
        }

        [HttpGet("Get")]

        public IActionResult Get(int id)
        {
            return Ok(repository.Get(id));
        }

        [HttpPost]

        public IActionResult Add(User user)
        {
            repository.Add(user);
            return Ok();
        }

        [HttpGet("GetAll")]

        public IActionResult GetAll()
        {
            return Ok(repository.GetAll());
        }

        [HttpPut]

        public IActionResult Update(User user)
        {
            repository.Update(user);
            return Ok();
        }

        [HttpDelete]

        public IActionResult Delete(User user)
        {
            repository.Delete(user);
            return Ok();
        }
    }
}
