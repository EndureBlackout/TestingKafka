using MessageAPI.Interfaces;
using MessageAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace MessageAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IOrderService _orderService;

        public OrderController(ILogger<OrderController> logger, IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> SubmitOrder(Order order)
        {
            var result = await _orderService.SubmitOrder(order);

            return Ok(result);
        }
    }
}
