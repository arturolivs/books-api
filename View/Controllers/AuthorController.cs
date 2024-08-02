using Services;
using Microsoft.AspNetCore.Mvc;
using Models;
using books_api.View.ViewModels;
using static System.Reflection.Metadata.BlobBuilder;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var authors = await _authorService.GetAllAsync();

        var bookViewModels = authors.Select(author => new AuthorViewModel
        (
            author.Id,
            author.FirstName,
            author.LastName,
            author.BirthDate
        )).ToList();

        return Ok(bookViewModels);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> FindAuthor(Guid id)
    {
        var author = await _authorService.FindAsync(id);

        var authorViewModel =  new AuthorViewModel
        (
            author.Id,
            author.FirstName,
            author.LastName,
            author.BirthDate
        );

        return Ok(authorViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Author author)
    {
        var createdAuthor = await _authorService.CreateAsync(author);

        var authorViewModel = new AuthorViewModel
        (
            author.Id,
            author.FirstName,
            author.LastName,
            author.BirthDate
        );

        return CreatedAtAction(nameof(FindAuthor), new { id = authorViewModel.Id }, authorViewModel);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, Author author)
    {
        var AuthorSaved = await _authorService.UpdateAsync(id, author);

        var authorViewModel = new AuthorViewModel
        (
            AuthorSaved.Id,
            AuthorSaved.FirstName,
            AuthorSaved.LastName,
            AuthorSaved.BirthDate
        );

        return Ok(authorViewModel);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _authorService.DeleteAsync(id);

        return NoContent();
    }
}