using BibliotekaAksenov.DataBaseContext;
using BibliotekaAksenov.Model;
using BibliotekaAksenov.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotekaAksenov.Services;

public class GenresService : IGenresService
{
    private readonly LibraryContext _context;
    public LibraryContext Context => _context;

    public GenresService(LibraryContext context)
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