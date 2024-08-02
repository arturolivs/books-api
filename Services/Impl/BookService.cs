using Models;

using books_api.Data.Repositories;
using Services;
using books_api.Exceptions;

namespace books_api.Services.Impl
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IGenreRepository _genreRepository;

        public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository, IGenreRepository genreRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _genreRepository = genreRepository;
        }
        private async Task ValidateBook(Book book)
        {
            await _genreRepository.FindAsync(book.GenreId);
            await _authorRepository.FindAsync(book.AuthorId);

            if (await _bookRepository.ExistsTitleAndAuthorAsync(book))
                throw new TitleAndAuthorException($"Book with Author id: '{book.AuthorId}' and title: '{book.Title}' already exists.");
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _bookRepository.GetAllAsync();
        }

        public async Task<Book> FindAsync(Guid id)
        {
            return await _bookRepository.FindAsync(id);
        }

        public async Task<Book> CreateAsync(Book book)
        {
            await ValidateBook(book);
            return await _bookRepository.CreateAsync(book);
        }

        public async Task<Book> UpdateAsync(Guid id, Book book)
        {
            await ValidateBook(book);
            Book existentBook = await FindAsync(id);
            existentBook.SetTitle(book.Title);
            existentBook.SetPublicationYear(book.PublicationYear);
            existentBook.SetDescription(book.Description);

            return await _bookRepository.UpdateAsync(existentBook);
        }

        public async Task DeleteAsync(Guid id)
        {
            Book existentBook = await FindAsync(id);
            await _bookRepository.DeleteAsync(existentBook);
        }
    }
}
