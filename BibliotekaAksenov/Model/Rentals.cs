using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotekaAksenov.Model;

public class Rentals
{
    [Key]
    public int id_Rental { get; set; }
    
    [Required, ForeignKey(nameof(Model.Books))]
    public int Book_id { get; set; }
    public Books Books { get; set; }
    
    [Required, ForeignKey(nameof(Model.Readers))]
    public int Reader_id { get; set; }
    public Readers Readers { get; set; }
    
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsReturned { get; set; }
}