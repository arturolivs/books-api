using System;
using Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;

    }

    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        return Ok(await _bookService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBook(Guid id)
    {
        var book = await _bookService.FindAsync(id);
        if (book == null)
        {
            return NotFound();
        }

        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook(Book book)
    {
        var createdBook = await _bookService.CreateAsync(book);

        return CreatedAtAction(nameof(GetBooks), new { id = book.Id }, book);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(Guid id, Book book)
    {
        var bookSaved = await _bookService.UpdateAsync(id, book);

        return Ok(book);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> UpdateBook(Guid id)
    {
        await _bookService.DeleteAsync(id);

        return NoContent();
    }
}