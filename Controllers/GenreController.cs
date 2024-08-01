using Services;
using Microsoft.AspNetCore.Mvc;
using Models;

[ApiController]
[Route("api/[controller]")]
public class GenreController : ControllerBase
{
    private readonly IGenreService _genreService;

    public GenreController(IGenreService genreService)
    {
        _genreService = genreService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _genreService.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> FindGenre(Guid id)
    {
        var genre = await _genreService.FindAsync(id);
        if (genre == null)
        {
            return NotFound();
        }

        return Ok(genre);
    }

    [HttpPost]
    public async Task<IActionResult> Create(Genre genre)
    {
        var createdGenre = await _genreService.CreateAsync(genre);

        return CreatedAtAction(nameof(FindGenre), new { id = genre.Id }, createdGenre);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, Genre genre)
    {
        var genreSaved = await _genreService.UpdateAsync(id, genre);

        return Ok(genreSaved);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _genreService.DeleteAsync(id);

        return NoContent();
    }
}