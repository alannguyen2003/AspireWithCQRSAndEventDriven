using System.Text.Json;
using Domain.Models;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace OrderAPI.Workers;

public class EventProcessor : BackgroundService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public EventProcessor(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _serviceScopeFactory.CreateScope();
            var database = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            var events = await database.DomainEvents
                .Where(e => !e.Processed)
                .ToListAsync();

            foreach (var e in events)
            {
                if (e.EventType == "OrderCreated")
                {
                    var order = JsonSerializer.Deserialize<Order>(e.Payload);

                    var readModel = new OrderReadModel()
                    {
                        OrderId = order.Id,
                        CustomerName = order.CustomerName,
                        TotalPrice = order.TotalPrice,
                        CreatedAt = order.CreatedAt,
                    };

                    await database.OrderReadModels.AddAsync(readModel);
                }

                e.Processed = true;
            }

            await database.SaveChangesAsync();
            await Task.Delay(2000);
        }
    }
}