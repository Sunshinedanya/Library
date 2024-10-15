using BibliotekaAksenov.DataBaseContext;
using BibliotekaAksenov.Model;
using BibliotekaAksenov.Requests;
using BibliotekaAksenov.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotekaAksenov.Services;

public class RentalsService : IRentalsService
{
    private readonly LibraryContext _context;
    public LibraryContext Context => _context;
    
    public RentalsService(LibraryContext context)
    {
        _context = context;
    }
    public async Task<IActionResult> PostBook(NewRentalData data)
    {
        var rental = await Rentals.Create(_context, data);
       
        await _context.Rentals.AddAsync(rental);
        await _context.SaveChangesAsync();

        return new OkResult();
    }
    public async Task<IActionResult> PutBook(int id)
    {
        var rental = await _context.GetRental(id);

        rental.EndRental();
        
        _context.Entry(rental).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return new OkResult();
    }
    
    public async Task<ActionResult<IEnumerable<Rentals>>> GetReaderHistory(int readerId)
    {
        var reader = await _context.GetReader(readerId);
        return reader.Rentals;
    }
    
    public async Task<ActionResult<IEnumerable<Rentals>>> GetBookHistory(int bookId)
    {
        var book = await _context.GetBook(bookId);
        return book.Rentals;
    }

    public ActionResult<IEnumerable<Rentals>> GetCurrentRentals()
    {
        return _context.Rentals.Where(rent => rent.IsReturned == false).ToList();
    }
}