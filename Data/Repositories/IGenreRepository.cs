using Models;

namespace books_api.Data.Repositories
{
    public interface IGenreRepository
    {
        Task<IEnumerable<Genre>> GetAllAsync();
        Task<Genre> FindAsync(Guid id);
        Task<Genre> CreateAsync(Genre genre);
        Task<Genre> UpdateAsync(Genre genre);
        Task DeleteAsync(Genre genre);
    }
}
