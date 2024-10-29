using BooksApi.DataBaseContext;

namespace BooksApi.Services.Interfaces;

public interface IService
{
    public BooksContext Context { get; }
}