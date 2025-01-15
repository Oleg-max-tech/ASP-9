using Microsoft.AspNetCore.Mvc;
using MovieAppWithAuthors;

[Route("api/authors")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    public IActionResult GetAllAuthors()
    {
        var authors = _authorService.GetAllAuthors();
        return Ok(authors);
    }

    [HttpGet("{id}")]
    public IActionResult GetAuthorById(int id)
    {
        var author = _authorService.GetAuthorById(id);
        if (author == null) return NotFound("Author not found.");
        return Ok(author);
    }

    [HttpPost]
    public IActionResult AddAuthor([FromBody] AuthorDto authorDto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var author = _authorService.AddAuthor(authorDto);
        return CreatedAtAction(nameof(GetAuthorById), new { id = author.Id }, author);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAuthor(int id)
    {
        _authorService.DeleteAuthor(id);
        return NoContent();
    }
}
