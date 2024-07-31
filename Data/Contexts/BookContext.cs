using Microsoft.EntityFrameworkCore;
using Models;

namespace books_api.Data.Contexts
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }
    }
}
