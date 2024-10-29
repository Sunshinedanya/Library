using Microsoft.EntityFrameworkCore;
using ReadersApi.Model;

namespace ReadersApi.DataBaseContext;

public class ReadersContext : DbContext
{
    public ReadersContext(DbContextOptions<ReadersContext> options) : base(options) { }

    public DbSet<Readers> Readers { get; set; }
}

public static class LibraryContextExtensions
{
    public static async ValueTask<Readers> GetReader(this ReadersContext context, int id)
    {
        var reader = await context.Readers.FindAsync(id);
        if (reader is null)
            throw new NullReferenceException();
        
        return reader;
    }
}