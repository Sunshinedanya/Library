using BibliotekaAksenov.DataBaseContext;
using BibliotekaAksenov.Model;
using BibliotekaAksenov.Requests;
using BibliotekaAksenov.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BibliotekaAksenov.Services;

public class ReadersService : IReadersService
{
    private readonly LibraryContext _context;
    
    public ReadersService(LibraryContext context)
    {
        _context = context;
    }
    public async Task<ActionResult<IEnumerable<Readers>>> GetReaders(int page, int pageSize)
    {
        var users = _context.Readers;
        var usersPaginated =  users.Skip(((page - 1) * pageSize)).Take(pageSize).ToList();
        return usersPaginated;
    }

    public async Task<ActionResult<Readers>> GetReader(int id)
    {
        return await _context.GetReader(id);
    }

    public async Task<ActionResult<Readers>> PostReader(NewReaderData data)
    {
        var reader = new Readers();
        reader.SetNewData(data);
        
        await _context.Readers.AddAsync(reader);
        await _context.SaveChangesAsync();

        return new OkResult();
    }

    public async Task<IActionResult> PutReader(int id, NewReaderData data)
    {
        var reader = await _context.GetReader(id);
        
        reader.SetNewData(data);
        
        _context.Entry(reader).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return new OkResult();
    }
    
    public async Task<IActionResult> DeleteReader(int id)
    {
        var reader = await _context.GetReader(id);

        _context.Readers.Remove(reader);
        await _context.SaveChangesAsync();

        return new OkResult();
    }

    public LibraryContext Context => _context;
}