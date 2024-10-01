using BibliotekaAksenov.DataBaseContext;
using BibliotekaAksenov.Model;
using BibliotekaAksenov.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotekaAksenov.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenresController : Controller
{
    private readonly LibraryContext _context;

    public GenresController(LibraryContext context)
    {
        _context = context;
    }

    [HttpGet, Route(nameof(GetGenres))]
    public async Task<ActionResult<IEnumerable<Genres>>> GetGenres()
    {
        return await _context.Genres.ToListAsync();
    }

    [HttpPost, Route(nameof(PostGenre))]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> PostGenre(string name)
    {
        var genre = new Genres()
        {
            Name = name
        };
        await _context.Genres.AddAsync(genre);
        await _context.SaveChangesAsync();

        return Ok();
    }

    // [HttpPut("{id}")]
    // //[Authorize(Roles = "Admin")]
    // public async Task<IActionResult> PutBook(int id, Books book)
    // {
    //     if (id != book.id_Book) return BadRequest();
    //
    //     _context.Entry(book).State = EntityState.Modified;
    //     await _context.SaveChangesAsync();
    //
    //     return NoContent();
    // }
    //
    // [HttpDelete("{id}")]
    // //[Authorize(Roles = "Admin")]
    // public async Task<IActionResult> DeleteBook(int id)
    // {
    //     var book = await _context.Books.FindAsync(id);
    //     if (book == null) return NotFound();
    //
    //     _context.Books.Remove(book);
    //     await _context.SaveChangesAsync();
    //
    //     return NoContent();
    // }
}