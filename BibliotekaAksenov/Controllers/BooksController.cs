using BibliotekaAksenov.DataBaseContext;
using BibliotekaAksenov.Model;
using BibliotekaAksenov.Requests;
using BibliotekaAksenov.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BibliotekaAksenov.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : Controller
{
    private readonly IBooksService _service;
    
    public BooksController(IBooksService service)
    {
        _service = service;
    }

    [HttpGet, Route(nameof(GetBooks))]
    public async Task<ActionResult<IEnumerable<Books>>> GetBooks(string author, string genre, int year, int page, int pageSize)
    {
        return await _service.GetBooks(author, genre, year, page, pageSize);
    }

    [HttpGet, Route(nameof(GetBook))]
    public async Task<ActionResult<Books>> GetBook(int id)
    {
        var book = await _service.GetBook(id);
        if (book == null) 
            return NotFound();
        return book;
    }

    [HttpGet, Route(nameof(GetBookByGenre))]
    public async Task<ActionResult<Books>> GetBookByGenre(string genreName)
    {
        var book = await _service.GetBookByGenre(genreName);
        return book;
    }
    
    [HttpGet, Route(nameof(GetBookByName))]
    public async Task<ActionResult<Books>> GetBookByName(string author, string title)
    {
        var book = await _service.GetBookByName(author, title);
        return book;
    }
    
    [HttpPost, Route(nameof(PostBook))]
    public async Task<IActionResult> PostBook(NewBookData data)
    {
        return await _service.PostBook(data);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutBook(int id, NewBookData data)
    {
        return await _service.PutBook(id, data);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
       return await _service.DeleteBook(id);
    }
}