using System.ComponentModel.DataAnnotations;

namespace BibliotekaAksenov.Model;

public class Genres
{
    [Key]
    public int id_Genre { get; set; }
    public string Name { get; set; }
    
    public List<Books> Books { get; set; }
}
