using BibliotekaAksenov.DataBaseContext;
using BibliotekaAksenov.Model;
using BibliotekaAksenov.Requests;
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

    [HttpGet, Route(nameof(GetBookByGenre))]
    public async Task<ActionResult<Books>> GetBookByGenre(string genreName)
    {
        var genre = await _context.GetGenre(genreName);
        
        var book = await _context.GetBook(genre);
        return book;
    }
    
    [HttpGet, Route(nameof(GetBookByName))]
    public async Task<ActionResult<Books>> GetBookByName(string author, string title)
    {
        var book = await _context.GetBook(author, title);
        return book;
    }
    
    [HttpPost, Route(nameof(PostBook))]
    public async Task<IActionResult> PostBook(NewBookData data)
    {
        var genre = await _context.Genres.FindAsync(data.Genre_id);

        if (genre is null)
            throw new NullReferenceException();
        
        var book = new Books()
        {
            Author = data.Author,
            Description = data.Description,
            Title = data.Description,
            Year = data.Year,
            Genres = genre
        };
        
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutBook(int id, NewBookData data)
    {
        var book = await _context.GetBook(id);

        book.SetNewData(data);
        
        _context.Entry(book).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var book = await _context.GetBook(id);

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();

        return Ok();
    }
}