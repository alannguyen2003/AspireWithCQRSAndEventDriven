using Domain.Repositories;
using Infrastructure.Persistence;

namespace Infrastructure.Repositories;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task AddAsync(T variable)
    {
        await _context.Set<T>().AddAsync(variable);
    }

    public async Task AddRangeAsync(IEnumerable<T> variables)
    {
        await _context.Set<T>().AddRangeAsync(variables);
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}