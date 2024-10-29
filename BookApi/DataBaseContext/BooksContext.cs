using BooksApi.Model;
using Microsoft.EntityFrameworkCore;

namespace BooksApi.DataBaseContext;

public class BooksContext : DbContext
{
    public BooksContext(DbContextOptions<BooksContext> options) : base(options) { }

    public DbSet<Books> Books { get; set; }
    public DbSet<Genres> Genres { get; set; }
    public DbSet<Rentals> Rentals { get; set; }
}

public static class LibraryContextExtensions
{
    public static async Task<Genres> GetGenre(this BooksContext context, int genreId)
    {
        var genre = await context.Genres.FindAsync(genreId);
        if (genre is null)
            throw new NullReferenceException();
        return genre;
    }
    
    public static async Task<Genres> GetGenre(this BooksContext context, string name)
    {
        var genre = await context.Genres.FirstAsync(g => g.Name == name);
        return genre;
    }
    
    public static async ValueTask<Books> GetBook(this BooksContext context, Genres genre)
    {
        var book = await context.Books.FirstAsync(book => book.Genres == genre);
        return book;
    }
    
    public static async ValueTask<Books> GetBook(this BooksContext context, int id)
    {
        var book = await context.Books.FindAsync(id);
        if (book is null)
            throw new NullReferenceException();
        return book;
    }
    
    public static async ValueTask<Books> GetBook(this BooksContext context, string author, string title)
    {
        var book = await context.Books.FirstAsync(book => book.Author == author && book.Title == title);
        return book;
    }
    
    public static async ValueTask<Rentals> GetRental(this BooksContext context, int id)
    {
        var rental = await context.Rentals.FindAsync(id);
        if (rental is null)
            throw new NullReferenceException();
        
        return rental;
    }
}