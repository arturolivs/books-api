using Models;

namespace books_api.Services
{
    public interface IBaseService<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> FindAsync(Guid id);
        Task<T> CreateAsync(T obj);
        Task<T> UpdateAsync(Guid id, T obj);
        Task DeleteAsync(Guid id);
    }
}
