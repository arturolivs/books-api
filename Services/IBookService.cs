using Models;

namespace Services
{
    public interface IBookService
    {
    Task<IEnumerable<Book>> GetAllAsync();
    Task<Book> FindAsync(Guid id);
    Task<Book> CreateAsync(Book book);
    Task<Book> UpdateAsync(Guid id, Book book);
    Task DeleteAsync(Guid id);
    }
}
