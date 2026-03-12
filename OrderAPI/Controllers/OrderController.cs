using Application.Features.Orders.Commands.CreateOrder;
using Microsoft.AspNetCore.Mvc;

namespace OrderAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class OrderController : ControllerBase
{
    private readonly ICreateOrderHandler<CreateOrderCommand> _createOrderHandler;

    public OrderController(ICreateOrderHandler<CreateOrderCommand> createOrderHandler)
    {
        _createOrderHandler = createOrderHandler;
    }

    [HttpPost("create-order")]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
    {
        var orderId = await _createOrderHandler.HandleAsync(command);
        return Ok(orderId);
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders()
    {
        return Ok();
    }
}