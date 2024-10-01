using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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