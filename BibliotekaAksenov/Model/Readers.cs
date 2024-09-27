using System.ComponentModel.DataAnnotations;

namespace BibliotekaAksenov.Model;

public class Readers
{
    [Key]
    public int id_Reader { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string ContactDetails { get; set; }
    
    public List<Rentals> Rentals { get; set; }
}