using BooksApi.DataBaseContext;
using BooksApi.Model;
using BooksApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ReadersApi.Services;

public class GenresService : IGenresService
{
    private readonly BooksContext _context;
    public BooksContext Context => _context;

    public GenresService(BooksContext context)
    {
        _context = context;
    }

    public async Task<ActionResult<IEnumerable<Genres>>> GetGenres()
    {
        return await _context.Genres.ToListAsync();
    }

    public async Task<ActionResult> PostGenre(string name)
    {
        var genre = new Genres
        {
            Name = name
        };
        await _context.Genres.AddAsync(genre);
        await _context.SaveChangesAsync();

        return new OkResult();
    }
    
    public async Task<ActionResult> EditGenre(int id, string name)
    {
        var genre = await _context.GetGenre(id);

        genre.Name = name;
         
        await _context.SaveChangesAsync();
        return new OkResult();
    }
    
    public async Task<ActionResult> DeleteGenre(int genreId)
    {
        var genre = await _context.GetGenre(genreId);
        
        _context.Genres.Remove(genre);
        await _context.SaveChangesAsync();

        return new OkResult();
    }
}