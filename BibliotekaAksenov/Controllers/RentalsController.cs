using BibliotekaAksenov.Model;
using BibliotekaAksenov.Requests;
using BibliotekaAksenov.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BibliotekaAksenov.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RentalsController : Controller
{
    private readonly IRentalsService _service;
    
    public RentalsController(IRentalsService service)
    {
        _service = service;
    }
    [HttpPost, Route(nameof(PostBook))]
    public async Task<IActionResult> PostBook(NewRentalData data)
    {
        return await _service.PostBook(data);
    }
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutBook(int id)
    {
        return await _service.PutBook(id);
    }
    
    [HttpGet, Route(nameof(GetReaderHistory))]
    public async Task<ActionResult<IEnumerable<Rentals>>> GetReaderHistory(int readerId)
    {
        return await _service.GetReaderHistory(readerId);
    }
    
    [HttpGet, Route(nameof(GetBookHistory))]
    public async Task<ActionResult<IEnumerable<Rentals>>> GetBookHistory(int bookId)
    {
        return await _service.GetBookHistory(bookId);
    }

    [HttpGet, Route(nameof(GetCurrentRentals))]
    public ActionResult<IEnumerable<Rentals>> GetCurrentRentals()
    {
        return _service.GetCurrentRentals();
    }
}