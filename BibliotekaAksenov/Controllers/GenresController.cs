using BibliotekaAksenov.DataBaseContext;
using BibliotekaAksenov.Model;
using BibliotekaAksenov.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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
    public async Task<ActionResult> PostGenre(string name)
    {
        var genre = new Genres
        {
            Name = name
        };
        await _context.Genres.AddAsync(genre);
        await _context.SaveChangesAsync();

        return Ok();
    }
    
    [HttpPost, Route(nameof(EditGenre))]
    public async Task<ActionResult> EditGenre(int id, string name)
    {
        var genre = await _context.GetGenre(id);

        genre.Name = name;
         
        await _context.SaveChangesAsync();
        return Ok();
    }
    
    [HttpDelete, Route(nameof(DeleteGenre))]
    public async Task<ActionResult> DeleteGenre(int genreId)
    {
        var genre = await _context.GetGenre(genreId);
        
        _context.Genres.Remove(genre);
        await _context.SaveChangesAsync();

        return Ok();
    }
}