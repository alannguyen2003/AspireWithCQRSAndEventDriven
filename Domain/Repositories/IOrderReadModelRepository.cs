using Domain.Models;

namespace Domain.Repositories;

public interface IOrderReadModelRepository : IBaseRepository<OrderReadModel>
{
    public Task<List<OrderReadModel>> GetOrderReadModelsAsync();
    public Task<OrderReadModel?> GetOrderReadModelAsync(int id);
}