namespace Application.Features;

public interface IQueries<T>
{
    public Task<List<T>> GetMany();
}