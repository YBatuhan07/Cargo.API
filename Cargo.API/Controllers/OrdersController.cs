using Cargo.Service.Abstract;
using Cargo.Service.Dto.Order;
using Microsoft.AspNetCore.Mvc;

namespace Cargo.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrdersController : CustomBaseController
{
    private readonly IOrderService _orderService;

    public OrdersController(IOrderService orderService)
    {
        _orderService = orderService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateOrderRequest request) => 
        CreateActionResult(await _orderService.CreateAsync(request));
}