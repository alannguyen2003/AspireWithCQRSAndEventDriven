using Domain.Models;
using Domain.Repositories;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class OrderReadModelRepository : BaseRepository<OrderReadModel>, IOrderReadModelRepository
{
    private readonly AppDbContext _context;
    
    public OrderReadModelRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }


    public async Task<List<OrderReadModel>> GetOrderReadModelsAsync()
    {
        return await _context.OrderReadModels.ToListAsync();
    }

    public async Task<OrderReadModel?> GetOrderReadModelAsync(int id)
    {
        return await _context.OrderReadModels.FindAsync(id) ?? null;
    }
}