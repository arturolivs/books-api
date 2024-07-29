using Models;

namespace Services
{
    public interface IBookService
    {
    Task<IEnumerable<Book>> GetAllBooksAsync();
    }
}
