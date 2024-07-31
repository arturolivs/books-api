using Models;

using books_api.Data.Repositories;
using Services;

namespace books_api.Services.Impl
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;

        }

        public async Task<IEnumerable<Genre>> GetAllAsync()
        {
            return await _genreRepository.GetAllAsync();
        }

        public async Task<Genre> FindAsync(Guid id)
        {
            return await _genreRepository.FindAsync(id);
        }

        public async Task<Genre> CreateAsync(Genre genre)
        {
            return await _genreRepository.CreateAsync(genre);
        }

        public async Task<Genre> UpdateAsync(Guid id, Genre genre)
        {
            Genre existentGenre = await FindAsync(id);
            existentGenre.SetName(genre.Name);

            return await _genreRepository.UpdateAsync(existentGenre);
        }

        public async Task DeleteAsync(Guid id)
        {
            Genre existentGenre = await FindAsync(id);
            await _genreRepository.DeleteAsync(existentGenre);
        }
    }
}
