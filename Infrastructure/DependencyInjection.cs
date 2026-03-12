using Domain.Repositories;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("DemoAspireWithCQRS")));        
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IOrderReadModelRepository, OrderReadModelRepository>();
        services.AddScoped<IDomainEventRepository, DomainEventRepository>();
        return services;
    }

    public static IServiceCollection AddWorkers(this IServiceCollection services)
    {
        return services;
    }
}