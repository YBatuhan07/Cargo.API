using Cargo.Service.Abstract;
using Cargo.Service.Dto.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cargo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderRequest request)
        {
            return Ok(await _orderService.CreateAsync(request));
        }

    }
}