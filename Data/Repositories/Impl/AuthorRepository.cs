using Models;

using Microsoft.EntityFrameworkCore;

namespace books_api.Data.Repositories.Impl
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _context;

        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author> FindAsync(Guid id)
        {
            return await _context.Authors.FindAsync(id) ?? throw new Exception();
        }

        public async Task<Author> CreateAsync(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return author;
        }

        public async Task<Author> UpdateAsync(Author author)
        {
            _context.Entry(author).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return author;
        }

        public async Task DeleteAsync(Author Author)
        {
            _context.Authors.Remove(Author);
            await _context.SaveChangesAsync();
        }
    }
}
