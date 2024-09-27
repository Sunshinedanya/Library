using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotekaAksenov.Model;

public class Rentals
{
    [Key]
    public int id_Rental { get; set; }
    
    [Required, ForeignKey(nameof(Books))]
    public int Book_id { get; set; }
    public Books Book { get; set; }
    
    [Required, ForeignKey(nameof(Readers))]
    public int Reader_id { get; set; }
    public Readers Reader { get; set; }
    
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsReturned { get; set; }
}