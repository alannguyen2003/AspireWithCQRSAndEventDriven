using Application.Features.DomainEvents.Query;
using Application.Features.Orders.Commands.CreateOrder;
using Application.Features.Orders.Queries.GetOrder;
using Application.Features.Orders.Queries.GetOrders;
using Microsoft.AspNetCore.Mvc;

namespace OrderAPI.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class OrderController : ControllerBase
{
    private readonly ICreateOrderHandler<CreateOrderCommand> _createOrderHandler;
    private readonly IGetOrderHandler _getOrderHandler;
    private readonly IGetOrdersHandler _getOrdersHandler;
    private readonly IGetDomainEventsHandler _getDomainEventsHandler;

    public OrderController(ICreateOrderHandler<CreateOrderCommand> createOrderHandler,
        IGetOrderHandler getOrderHandler,
        IGetOrdersHandler getOrdersHandler,
        IGetDomainEventsHandler getDomainEventsHandler)
    {
        _createOrderHandler = createOrderHandler;
        _getOrderHandler = getOrderHandler;
        _getOrdersHandler = getOrdersHandler;
        _getDomainEventsHandler = getDomainEventsHandler;
    }

    [HttpPost("create-order")]
    public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
    {
        var orderId = await _createOrderHandler.HandleAsync(command);
        return Ok(orderId);
    }

    [HttpGet]
    public async Task<IActionResult> GetOrder([FromQuery] int orderId)
    {
        return Ok(await _getOrderHandler.Get(orderId));
    }

    [HttpGet("orders")]
    public async Task<IActionResult> GetOrders()
    {
        return Ok(await _getOrdersHandler.GetMany());
    }

    [HttpGet("domain-events")]
    public async Task<IActionResult> GetDomainEvents()
    {
        return Ok(await _getDomainEventsHandler.GetMany());
    }
}