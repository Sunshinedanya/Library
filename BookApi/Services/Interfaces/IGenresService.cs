using BooksApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Services.Interfaces;

public interface IGenresService: IService
{
    public Task<ActionResult<IEnumerable<Genres>>> GetGenres();
    public Task<ActionResult> PostGenre(string name);
    public Task<ActionResult> EditGenre(int id, string name);
    public Task<ActionResult> DeleteGenre(int genreId);
}