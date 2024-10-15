using BibliotekaAksenov.Model;
using BibliotekaAksenov.Requests;
using BibliotekaAksenov.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BibliotekaAksenov.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReadersController : Controller
{
    private readonly IReadersService _service;
    public ReadersController(IReadersService service)
    {
        _service = service;
    }
    
    [HttpGet, Route(nameof(GetReaders))]
    public async Task<ActionResult<IEnumerable<Readers>>> GetReaders(int page, int pageSize)
    {
        return await _service.GetReaders(page, pageSize);
    }

    [HttpGet, Route(nameof(GetReader))]
    public async Task<ActionResult<Readers>> GetReader(int id)
    {
        return await _service.GetReader(id);
    }

    [HttpPost, Route(nameof(PostReader))]
    public async Task<ActionResult<Readers>> PostReader(NewReaderData data)
    {
        return await _service.PostReader(data);
    }

    [HttpPut, Route(nameof(PutReader))]
    public async Task<IActionResult> PutReader(int id, NewReaderData data)
    {
        return await _service.PutReader(id, data);
    }
    
    [HttpDelete, Route(nameof(DeleteReader))]
    public async Task<IActionResult> DeleteReader(int id)
    {
        return await _service.DeleteReader(id);
    }
}