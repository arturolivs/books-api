using Models;

using books_api.Data.Repositories;
using Services;
using books_api.Data.Repositories.Impl;
using books_api.Exceptions;

namespace books_api.Services.Impl
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IBookRepository _bookRepository;

        public GenreService(IGenreRepository genreRepository, IBookRepository bookRepository)
        {
            _genreRepository = genreRepository;
            _bookRepository = bookRepository;
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
            if (await _genreRepository.GenreInUseAsync(id))
                throw new EntityInUseException($"Genre with id: '{id}' is used in some book.");

            Genre existentGenre = await FindAsync(id);
            await _genreRepository.DeleteAsync(existentGenre);
        }
    }
}
