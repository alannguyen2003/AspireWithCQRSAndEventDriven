using Domain.Models;

namespace Application.Features.DomainEvents.Query;

public interface IGetDomainEventsHandler : IQueries<DomainEvent>
{
    
}