using Models;

using books_api.Data.Repositories;
using Services;
using books_api.Exceptions;

namespace books_api.Services.Impl
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await _authorRepository.GetAllAsync();
        }

        public async Task<Author> FindAsync(Guid id)
        {
            return await _authorRepository.FindAsync(id);
        }

        public async Task<Author> CreateAsync(Author author)
        {
            return await _authorRepository.CreateAsync(author);
        }

        public async Task<Author> UpdateAsync(Guid id, Author author)
        {
            Author existentAuthor = await FindAsync(id);
            existentAuthor.SetFirstName(author.FirstName);
            existentAuthor.SetLastName(author.LastName);
            existentAuthor.SetBirthDate(author.BirthDate);

            return await _authorRepository.UpdateAsync(existentAuthor);
        }

        public async Task DeleteAsync(Guid id)
        {
            if (await _authorRepository.AuthorInUseAsync(id))
                throw new EntityInUseException($"Author with id: '{id}' is used in some book.");
            Author existentAuthor = await FindAsync(id);

            await _authorRepository.DeleteAsync(existentAuthor);
        }
    }
}
