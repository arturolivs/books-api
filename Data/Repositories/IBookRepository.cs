using Models;

namespace books_api.Data.Repositories
{
    public interface IBookRepository : ICrudRepository<Book>
    {
        Task<bool> ExistsTitleAndAuthorAsync(Book book);
    }
}
