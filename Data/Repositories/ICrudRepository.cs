using Models;

namespace books_api.Data.Repositories
{
    public interface ICrudRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> FindAsync(Guid id);
        Task<T> CreateAsync(T t);
        Task<T> UpdateAsync(T t);
        Task DeleteAsync(T t);
    }
}
