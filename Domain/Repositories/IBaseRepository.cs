namespace Domain.Repositories;

public interface IBaseRepository<T> where T : class
{
    public Task AddAsync(T variable);
    public Task AddRangeAsync(IEnumerable<T> variables);
    public Task SaveChangesAsync();
}