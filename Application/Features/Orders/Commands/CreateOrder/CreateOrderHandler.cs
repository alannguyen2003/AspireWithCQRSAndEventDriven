using System.Text.Json;
using Domain.Models;
using Domain.Repositories;

namespace Application.Features.Orders.Commands.CreateOrder;

public class CreateOrderHandler : ICreateOrderHandler<CreateOrderCommand>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IDomainEventRepository _domainEventRepository;

    public CreateOrderHandler(IOrderRepository orderRepository, IDomainEventRepository domainEventRepository)
    {
        _orderRepository = orderRepository;
        _domainEventRepository = domainEventRepository;
    }

    public async Task<int> HandleAsync(CreateOrderCommand command)
    {
        var order = new Order()
        {
            CustomerName = command.CustomerName,
            TotalPrice = command.TotalPrice,
            CreatedAt = DateTime.UtcNow
        };
        await _orderRepository.AddAsync(order);

        var domainEvent = new DomainEvent()
        {
            EventType = "OrderCreated",
            AggregateId = order.Id,
            Payload = JsonSerializer.Serialize(order),
            CreatedAt = DateTime.UtcNow,
            Processed = false
        };
        await _domainEventRepository.AddAsync(domainEvent);
        
        await _domainEventRepository.SaveChangesAsync();
        return order.Id;
    }
}