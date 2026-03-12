using Application.Features.Orders.Commands.CreateOrder;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddOrderDI();
        return services;
    }

    public static IServiceCollection AddOrderDI(this IServiceCollection services)
    {
        services.AddScoped<ICreateOrderHandler<CreateOrderCommand>, CreateOrderHandler>();
        return services;
    }
}