using BibliotekaAksenov.DataBaseContext;
using BibliotekaAksenov.Model;
using BibliotekaAksenov.Requests;
using BibliotekaAksenov.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BibliotekaAksenov.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GenresController : Controller
{
    private readonly IGenresService _service;

    public GenresController(IGenresService service)
    {
        _service = service;
    }

    [HttpGet, Route(nameof(GetGenres))]
    public async Task<ActionResult<IEnumerable<Genres>>> GetGenres()
    {
        return await _service.GetGenres();
    }

    [HttpPost, Route(nameof(PostGenre))]
    public async Task<ActionResult> PostGenre(string name)
    {
        return await _service.PostGenre(name);
    }
    
    [HttpPost, Route(nameof(EditGenre))]
    public async Task<ActionResult> EditGenre(int id, string name)
    {
        return await _service.EditGenre(id, name);
    }
    
    [HttpDelete, Route(nameof(DeleteGenre))]
    public async Task<ActionResult> DeleteGenre(int genreId)
    {
        return await _service.DeleteGenre(genreId);
    }
}