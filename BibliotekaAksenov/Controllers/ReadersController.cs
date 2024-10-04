using BibliotekaAksenov.DataBaseContext;
using BibliotekaAksenov.Model;
using BibliotekaAksenov.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotekaAksenov.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReadersController : Controller
{
    public ReadersController(LibraryContext context)
    {
        _context = context;
    }

    private readonly LibraryContext _context;
    
    [HttpGet, Route(nameof(GetReaders))]
    public async Task<ActionResult<IEnumerable<Readers>>> GetReaders()
    {
        return await _context.Readers.ToListAsync();
    }

    [HttpGet, Route(nameof(GetReader))]
    public async Task<ActionResult<Readers>> GetReader(int id)
    {
        return await _context.GetReader(id);
    }

    [HttpPost, Route(nameof(PostReader))]
    public async Task<ActionResult<Readers>> PostReader(NewReaderData data)
    {
        var reader = new Readers();
        reader.SetNewData(data);
        
        await _context.Readers.AddAsync(reader);
        await _context.SaveChangesAsync();

        return Ok();
    }

    [HttpPut, Route(nameof(PutReader))]
    public async Task<IActionResult> PutReader(int id, NewReaderData data)
    {
        var reader = await _context.GetReader(id);
        
        reader.SetNewData(data);
        
        _context.Entry(reader).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return Ok();
    }
    
    [HttpDelete, Route(nameof(DeleteReader))]
    public async Task<IActionResult> DeleteReader(int id)
    {
        var reader = await _context.GetReader(id);

        _context.Readers.Remove(reader);
        await _context.SaveChangesAsync();

        return Ok();
    }
}