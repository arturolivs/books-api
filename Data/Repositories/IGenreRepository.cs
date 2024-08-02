using Models;

namespace books_api.Data.Repositories
{
    public interface IGenreRepository: ICrudRepository<Genre>
    {
        Task<bool> GenreInUseAsync(Guid id);
    }
}
