namespace Application.Features.Orders.Commands;

public interface IHandler<T>
{
    public Task<int> HandleAsync(T command);
}