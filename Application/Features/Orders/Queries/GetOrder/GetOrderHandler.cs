using Domain.Models;
using Domain.Repositories;

namespace Application.Features.Orders.Queries.GetOrder;

public class GetOrderHandler : IGetOrderHandler
{
    private readonly IOrderReadModelRepository _orderReadModelRepository;

    public GetOrderHandler(IOrderReadModelRepository orderReadModelRepository)
    {
        _orderReadModelRepository = orderReadModelRepository;
    }
    
    public async Task<OrderReadModel?> Get(int id)
    {
        return await _orderReadModelRepository.GetOrderReadModelAsync(id);
    }
}