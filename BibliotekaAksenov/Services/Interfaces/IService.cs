using BibliotekaAksenov.DataBaseContext;

namespace BibliotekaAksenov.Services.Interfaces;

public interface IService
{
    public LibraryContext Context { get; }
}