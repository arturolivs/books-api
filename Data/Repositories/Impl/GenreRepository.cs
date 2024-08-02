using Models;

using Microsoft.EntityFrameworkCore;
using books_api.Exceptions;

namespace books_api.Data.Repositories.Impl
{
    public class GenreRepository : IGenreRepository
    {
        private readonly AppDbContext _context;

        public GenreRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await _context.Genres.ToListAsync();
        }

        public async Task<Genre> FindAsync(Guid id)
        {
            return await _context.Genres.FindAsync(id) ?? throw new EntityNotFoundException($"Genre with id: '{id}' not found.");
        }

        public async Task<Genre> CreateAsync(Genre genre)
        {
            _context.Genres.Add(genre);
            await _context.SaveChangesAsync();

            return genre;
        }

        public async Task<Genre> UpdateAsync(Genre genre)
        {
            _context.Entry(genre).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return genre;
        }

        public async Task DeleteAsync(Genre genre)
        {
            _context.Genres.Remove(genre);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> GenreInUseAsync(Guid id)
        {
            return await _context.Books.AnyAsync(b => b.GenreId == id);
        }
    }
}
