using Application.Features.Orders.Commands.CreateOrder;
using Application.Features.Orders.Queries.GetOrder;
using Microsoft.AspNetCore.Mvc;

namespace OrderAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class OrderController : ControllerBase
{
    private readonly ICreateOrderHandler<CreateOrderCommand> _createOrderHandler;
    private readonly IGetOrderHandler _getOrderHandler;

    public OrderController(ICreateOrderHandler<CreateOrderCommand> createOrderHandler,
        IGetOrderHandler getOrderHandler)
    {
        _createOrderHandler = createOrderHandler;
        _getOrderHandler = getOrderHandler;
    }

    [HttpPost("create-order")]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
    {
        var orderId = await _createOrderHandler.HandleAsync(command);
        return Ok(orderId);
    }

    [HttpGet]
    public async Task<IActionResult> GetOrders([FromQuery] int orderId)
    {
        return Ok(await _getOrderHandler.Get(orderId));
    }
}