using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReadersApi.DataBaseContext;
using ReadersApi.Model;
using ReadersApi.Requests;
using ReadersApi.Services.Interfaces;

namespace ReadersApi.Services;

public class ReadersService : IReadersService
{
    private readonly ReadersContext _context;
    
    public ReadersService(ReadersContext context)
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

    public ReadersContext Context => _context;
}