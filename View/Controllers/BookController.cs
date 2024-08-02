using Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using books_api.View.ViewModels;
using books_api.Dto;

[ApiController]
[Route("api/v1/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var books = await _bookService.GetAllAsync();

        var bookViewModels = books.Select(book => new BookViewModel
        (
            book.Id,
            book.Title,
            book.PublicationYear,
            book.Description,
            book.Genre,
            book.Author
        )).ToList();

        return Ok(bookViewModels);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> FindBook(Guid id)
    {
        var book = await _bookService.FindAsync(id);

        var bookViewModel = new BookViewModel
        (
            book.Id,
            book.Title,
            book.PublicationYear,
            book.Description,
            book.Genre,
            book.Author
        );

        return Ok(bookViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(BookDto bookDto)
    {
        Book book = new Book(bookDto.Title, bookDto.Description, bookDto.PublicationYear, bookDto.GenreId, bookDto.AuthorId);
        
        var createdBook = await _bookService.CreateAsync(book);

        var bookViewModel = new BookViewModel
        (
            createdBook.Id,
            createdBook.Title,
            createdBook.PublicationYear,
            createdBook.Description,
            createdBook.Genre,
            createdBook.Author
        );


        return CreatedAtAction(nameof(FindBook), new { id = bookViewModel.Id }, bookViewModel);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, BookDto updateBookDto)
    {
        Book book = new Book(updateBookDto.Title, updateBookDto.Description, updateBookDto.PublicationYear, updateBookDto.GenreId, updateBookDto.AuthorId); 
        var bookSaved = await _bookService.UpdateAsync(id, book);

        var bookViewModel = new BookViewModel
        (
            book.Id,
            book.Title,
            book.PublicationYear,
            book.Description,
            book.Genre,
            book.Author
        );

        return Ok(bookViewModel);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _bookService.DeleteAsync(id);

        return NoContent();
    }
}