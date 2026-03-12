using Domain.Models;
using Domain.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class DomainEventRepository : BaseRepository<DomainEvent>, IDomainEventRepository
{
    private readonly AppDbContext _context;
    
    public DomainEventRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }


    public async Task<List<DomainEvent>> GetDomainEventsAsync()
    {
        return await _context.DomainEvents.ToListAsync();
    }

    public async Task<DomainEvent?> GetDomainEventAsync(int id)
    {
        return await _context.DomainEvents.FindAsync(id) ?? null;
    }
}