using Domain.Models;

namespace Domain.Repositories;

public interface IDomainEventRepository : IBaseRepository<DomainEvent>
{
    public Task<List<DomainEvent>> GetDomainEventsAsync();
    public Task<DomainEvent?> GetDomainEventAsync(int id);
}