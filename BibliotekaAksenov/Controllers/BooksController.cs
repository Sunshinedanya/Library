using BibliotekaAksenov.DataBaseContext;
using BibliotekaAksenov.Model;
using BibliotekaAksenov.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotekaAksenov.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : Controller
{
    private readonly LibraryContext _context;

    public BooksController(LibraryContext context)
    {
        _context = context;
    }

    [HttpGet, Route(nameof(GetBooks))]
    public async Task<ActionResult<IEnumerable<Books>>> GetBooks()
    {
        return await _context.Books.ToListAsync();
    }

    [HttpGet, Route(nameof(GetBook))]
    public async Task<ActionResult<Books>> GetBook(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null) 
            return NotFound();
        return book;
    }

    [HttpPost, Route(nameof(PostBook))]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> PostBook(CreateNewBook data)
    {
        var book = new Books()
        {
            Author = data.Author,
            Description = data.Description,
            Title = data.Description,
            Year = data.Year,
            Genre_id = data.Genre_id
        };
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpPut("{id}")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> PutBook(int id, Books book)
    {
        if (id != book.id_Book) return BadRequest();

        _context.Entry(book).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null) return NotFound();

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}