using BibliotekaAksenov.DataBaseContext;
using BibliotekaAksenov.Model;
using BibliotekaAksenov.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotekaAksenov.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RentalsController : Controller
{
    private readonly LibraryContext _context;
    
    public RentalsController(LibraryContext context)
    {
        _context = context;
    }
    [HttpPost, Route(nameof(PostBook))]
    public async Task<IActionResult> PostBook(NewRentalData data)
    {
        var rental = await Rentals.Create(_context, data);
       
        await _context.Rentals.AddAsync(rental);
        await _context.SaveChangesAsync();

        return Ok();
    }
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutBook(int id)
    {
        var rental = await _context.GetRental(id);

        rental.EndRental();
        
        _context.Entry(rental).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return Ok();
    }
    
    [HttpGet, Route(nameof(GetReaderHistory))]
    public async Task<ActionResult<IEnumerable<Rentals>>> GetReaderHistory(int readerId)
    {
        var reader = await _context.GetReader(readerId);
        return reader.Rentals;
    }
    
    [HttpGet, Route(nameof(GetBookHistory))]
    public async Task<ActionResult<IEnumerable<Rentals>>> GetBookHistory(int bookId)
    {
        var book = await _context.GetBook(bookId);
        return book.Rentals;
    }

    [HttpGet, Route(nameof(GetCurrentRentals))]
    public ActionResult<IEnumerable<Rentals>> GetCurrentRentals()
    {
        return _context.Rentals.Where(rent => rent.IsReturned == false).ToList();
    }
}