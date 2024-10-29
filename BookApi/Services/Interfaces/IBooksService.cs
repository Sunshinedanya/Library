using BooksApi.Requests;
using BooksApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Services.Interfaces;

public interface IBooksService : IService
{
    public Task<ActionResult<IEnumerable<Books>>> GetBooks(string author, string genre, int year, int page, int pageSize);
    public Task<ActionResult<Books>> GetBook(int id);
    public Task<ActionResult<Books>> GetBookByGenre(string genreName);
    public Task<ActionResult<Books>> GetBookByName(string author, string title);
    public Task<IActionResult> PostBook(NewBookData data);
    public Task<IActionResult> PutBook(int id, NewBookData data);
    public Task<IActionResult> DeleteBook(int id);
}