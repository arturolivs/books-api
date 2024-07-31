using Models;

namespace Services
{
    public interface IGenreService
    {
    Task<IEnumerable<Genre>> GetAllAsync();
    Task<Genre> FindAsync(Guid id);
    Task<Genre> CreateAsync(Genre book);
    Task<Genre> UpdateAsync(Guid id, Genre book);
    Task DeleteAsync(Guid id);
    }
}
