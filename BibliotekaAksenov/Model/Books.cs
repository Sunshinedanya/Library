using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BibliotekaAksenov.Requests;

namespace BibliotekaAksenov.Model;

public class Books
{
    [Key] 
    public int id_Book { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }

    [Required, ForeignKey(nameof(Genres))]
    public int Genre_id { get; set; }
    public Genres Genres { get; set; }
    
    public int Year { get; set; }
    public string Description { get; set; }
    public int AvailableCopies { get; set; }
    
    public List<Rentals> Rentals { get; set; }
}

public static class ExtensionBooks
{
    public static void SetNewData(this Books book, NewBookData data)
    {
        book.Title = data.Title;
        book.Author = data.Author;
        book.Year = data.Year;
        book.Description = data.Description;
    }
}
