using Application.Features.DomainEvents.Query;
using Application.Features.Orders.Commands.CreateOrder;
using Application.Features.Orders.Queries.GetOrder;
using Application.Features.Orders.Queries.GetOrders;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddOrderDI();
        services.AddDomainEventDI();
        return services;
    }

    public static IServiceCollection AddOrderDI(this IServiceCollection services)
    {
        services.AddScoped<ICreateOrderHandler<CreateOrderCommand>, CreateOrderHandler>();
        services.AddScoped<IGetOrderHandler, GetOrderHandler>();
        services.AddScoped<IGetOrdersHandler, GetOrdersHandler>();
        return services;
    }

    public static IServiceCollection AddDomainEventDI(this IServiceCollection services)
    {
        services.AddScoped<IGetDomainEventsHandler, GetDomainEventsHandler>();
        return services;
    }
}