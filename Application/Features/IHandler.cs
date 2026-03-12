namespace Application.Features;

public interface IHandler<T>
{
    public Task<int> HandleAsync(T command);
}