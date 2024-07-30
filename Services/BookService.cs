using Data;
using Models;

using Microsoft.EntityFrameworkCore;

namespace Services
{
    public class BookService : IBookService
    {
        private readonly BookContext _context;

        public BookService(BookContext context)
        {
            _context = context;

        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> FindAsync(Guid id)
        {
            var book = await _context.Books.FindAsync(id) ?? throw new Exception();
            return book;
        }

        public async Task<Book> CreateAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<Book> UpdateAsync(Guid id,Book book)
        {
            Book existentBook = await FindAsync(id);
            existentBook.SetTitle(book.Title);
            await _context.SaveChangesAsync();
            
            return book;
        }

        public async Task DeleteAsync(Guid id)
        {
            Book existentBook = await FindAsync(id);
            _context.Books.Remove(existentBook);
            await _context.SaveChangesAsync();
        }
    }
}
