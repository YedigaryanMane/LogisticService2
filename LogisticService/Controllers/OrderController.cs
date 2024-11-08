using LogisticService.Models;
using LogisticService.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LogisticService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderRepository orderRepository;

        public OrderController(OrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        [HttpPost]

        public IActionResult Add(Order order)
        {
            orderRepository.Add(order);
            return Ok();
        }
    }
}
