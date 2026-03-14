using Domain.Models;
using Domain.Repositories;

namespace Application.Features.DomainEvents.Query;

public class GetDomainEventsHandler : IGetDomainEventsHandler
{
    private readonly IDomainEventRepository _domainEventRepository;

    public GetDomainEventsHandler(IDomainEventRepository domainEventRepository)
    {
        _domainEventRepository = domainEventRepository;
    }
    
    public async Task<List<DomainEvent>> GetMany()
    {
        return await _domainEventRepository.GetDomainEventsAsync();
    }
}