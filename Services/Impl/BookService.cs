using Models;

using books_api.Data.Repositories;
using Services;

namespace books_api.Services.Impl
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;

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
            return await _bookRepository.CreateAsync(book);
        }

        public async Task<Book> UpdateAsync(Guid id, Book book)
        {
            Book existentBook = await FindAsync(id);
            existentBook.SetTitle(book.Title);
            return await _bookRepository.UpdateAsync(existentBook);
        }

        public async Task DeleteAsync(Guid id)
        {
            Book existentBook = await FindAsync(id);
            await _bookRepository.DeleteAsync(existentBook);
        }
    }
}
