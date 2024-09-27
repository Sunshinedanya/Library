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