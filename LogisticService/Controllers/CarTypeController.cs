using LogisticService.Models;
using LogisticService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LogisticService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarTypeController : ControllerBase
    {
        private readonly IRepository<CarType, CarTypeRequest> _repository;

        public CarTypeController(IRepository<CarType, CarTypeRequest> repository)
        {
            _repository = repository;
        }

        [HttpGet("Get")]

        public IActionResult Get(int id)
        {
            return Ok(_repository.Get(id));
        }

        [HttpPost]

        public IActionResult Add(CarType carType)
        {
            _repository.Add(carType);
            return Ok();
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_repository.GetAll());
        }

        [HttpDelete]
        public IActionResult Delete(CarType carType)
        {
            _repository.Delete(carType);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(CarType carType)
        {
            _repository.Update(carType);
            return Ok();
        }
    }
}
