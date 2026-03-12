namespace Application.Features;

public interface IQuery<T>
{
    public Task<T?> Get(int orderId);
}