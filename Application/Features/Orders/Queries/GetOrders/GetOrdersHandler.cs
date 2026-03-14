using Domain.Models;
using Domain.Repositories;

namespace Application.Features.Orders.Queries.GetOrders;

public class GetOrdersHandler : IGetOrdersHandler
{
    private readonly IOrderReadModelRepository _orderReadModelRepository;

    public GetOrdersHandler(IOrderReadModelRepository orderReadModelRepository)
    {
        _orderReadModelRepository = orderReadModelRepository;    
    }

    public async Task<List<OrderReadModel>> GetMany()
    {
        return await _orderReadModelRepository.GetOrderReadModelsAsync();
    }
}