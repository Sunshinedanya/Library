using BooksApi.Model;
using BooksApi.Requests;
using Microsoft.AspNetCore.Mvc;

namespace BooksApi.Services.Interfaces;

public interface IRentalsService : IService
{
    public Task<IActionResult> PostBook(NewRentalData data);
    public Task<IActionResult> PutBook(int id);
    //public Task<ActionResult<IEnumerable<Rentals>>> GetReaderHistory(int readerId);
    public Task<ActionResult<IEnumerable<Rentals>>> GetBookHistory(int bookId);
    public ActionResult<IEnumerable<Rentals>> GetCurrentRentals();
}