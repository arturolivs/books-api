using Services;
using Microsoft.AspNetCore.Mvc;
using Models;

[ApiController]
[Route("api/[controller]")]
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
        return Ok(await _authorService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> FindAuthor(Guid id)
    {
        var author = await _authorService.FindAsync(id);
        if (author == null)
        {
            return NotFound();
        }

        return Ok(author);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Author author)
    {
        var createdAuthor = await _authorService.CreateAsync(author);

        return CreatedAtAction(nameof(FindAuthor), new { id = author.Id }, createdAuthor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, Author author)
    {
        var AuthorSaved = await _authorService.UpdateAsync(id, author);

        return Ok(AuthorSaved);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _authorService.DeleteAsync(id);

        return NoContent();
    }
}