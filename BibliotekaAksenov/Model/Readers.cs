using System.ComponentModel.DataAnnotations;
using BibliotekaAksenov.Requests;

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

public static class ExtensionReaders
{
    public static void SetNewData(this Readers book, NewReaderData data)
    {
        book.FirstName = data.FirstName;
        book.LastName = data.LastName;
        book.DateOfBirth = data.DateOfBirth;
        book.ContactDetails = data.ContactDetails;
    }
}