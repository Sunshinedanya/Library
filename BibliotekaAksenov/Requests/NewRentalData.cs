namespace BibliotekaAksenov.Requests;

public class NewRentalData
{
    public int Book_id { get; set; }
    
    public int Reader_id { get; set; }
    
    public DateTime StartDate { get; set; }
}