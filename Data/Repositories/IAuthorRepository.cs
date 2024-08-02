using Models;

namespace books_api.Data.Repositories
{
    public interface IAuthorRepository : ICrudRepository<Author>
    {
        Task<bool> AuthorInUseAsync(Guid id);
    }
}
