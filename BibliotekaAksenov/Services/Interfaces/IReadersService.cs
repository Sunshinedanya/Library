using BibliotekaAksenov.Model;
using BibliotekaAksenov.Requests;
using Microsoft.AspNetCore.Mvc;

namespace BibliotekaAksenov.Services.Interfaces;

public interface IReadersService: IService
{
    public  Task<ActionResult<IEnumerable<Readers>>> GetReaders(int page, int pageSize);
    public  Task<ActionResult<Readers>> GetReader(int id);
    public  Task<ActionResult<Readers>> PostReader(NewReaderData data);
    public  Task<IActionResult> PutReader(int id, NewReaderData data);
    public  Task<IActionResult> DeleteReader(int id);
}