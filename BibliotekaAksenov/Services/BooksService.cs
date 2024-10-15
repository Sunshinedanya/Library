using BibliotekaAksenov.DataBaseContext;
using BibliotekaAksenov.Model;
using BibliotekaAksenov.Requests;
using BibliotekaAksenov.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotekaAksenov.Services;

public class BooksService : IBooksService
{
    private readonly LibraryContext _context;

    public BooksService(LibraryContext context)
    {
        _context = context;
    }
    
    public async Task<ActionResult<IEnumerable<Books>>> GetBooks
        ( string author
        , string genre
        , int year
        , int page
        , int pageSize)
    {
        var books = _context.Books
            .Where(b => b.Author == author)
            .Where(b => b.Year == year)
            .Skip((page - 1) * pageSize)
            .Take(pageSize).ToList();

        return books;
    }

    public async Task<ActionResult<Books>> GetBook(int id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null) 
            return new NotFoundResult();
        return book;
    }

    public async Task<ActionResult<Books>> GetBookByGenre(string genreName)
    {
        var genre = await _context.GetGenre(genreName);
        
        var book = await _context.GetBook(genre);
        return book;
    }
    
    public async Task<ActionResult<Books>> GetBookByName(string author, string title)
    {
        var book = await _context.GetBook(author, title);
        return book;
    }
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

        return new OkResult();
    }

    public async Task<IActionResult> PutBook(int id, NewBookData data)
    {
        var book = await _context.GetBook(id);

        book.SetNewData(data);
        
        _context.Entry(book).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return new OkResult();
    }

    public async Task<IActionResult> DeleteBook(int id)
    {
        var book = await _context.GetBook(id);

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();

        return new OkResult();
    }

    public LibraryContext Context => _context;
}