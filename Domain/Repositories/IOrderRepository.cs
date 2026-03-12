using Domain.Models;

namespace Domain.Repositories;

public interface IOrderRepository : IBaseRepository<Order>
{
    public Task<List<Order>> GetOrdersAsync();
    public Task<Order?> GetOrderAsync(int id);
}