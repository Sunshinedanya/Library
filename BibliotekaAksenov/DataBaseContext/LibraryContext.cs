using BibliotekaAksenov.Model;
using Microsoft.EntityFrameworkCore;

namespace BibliotekaAksenov.DataBaseContext;

public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }

    public DbSet<Books> Books { get; set; }
    public DbSet<Readers> Readers { get; set; }
    public DbSet<Genres> Genres { get; set; }
    public DbSet<Rentals> Rentals { get; set; }
}

public static class LibraryContextExtensions
{
    public static async Task<Genres> GetGenre(this LibraryContext context, int genreId)
    {
        var genre = await context.Genres.FindAsync(genreId);
        if (genre is null)
            throw new NullReferenceException();
        return genre;
    }
    
    public static async Task<Genres> GetGenre(this LibraryContext context, string name)
    {
        var genre = await context.Genres.FirstAsync(g => g.Name == name);
        return genre;
    }
    
    public static async ValueTask<Books> GetBook(this LibraryContext context, Genres genre)
    {
        var book = await context.Books.FirstAsync(book => book.Genres == genre);
        return book;
    }
    
    public static async ValueTask<Books> GetBook(this LibraryContext context, int id)
    {
        var book = await context.Books.FindAsync(id);
        if (book is null)
            throw new NullReferenceException();
        return book;
    }
    
    public static async ValueTask<Books> GetBook(this LibraryContext context, string author, string title)
    {
        var book = await context.Books.FirstAsync(book => book.Author == author && book.Title == title);
        return book;
    }

    public static async ValueTask<Readers> GetReader(this LibraryContext context, int id)
    {
        var reader = await context.Readers.FindAsync(id);
        if (reader is null)
            throw new NullReferenceException();
        
        return reader;
    }
    
    public static async ValueTask<Rentals> GetRental(this LibraryContext context, int id)
    {
        var rental = await context.Rentals.FindAsync(id);
        if (rental is null)
            throw new NullReferenceException();
        
        return rental;
    }
}