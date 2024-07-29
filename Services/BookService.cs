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

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }
    }
}
