namespace BibliotekaAksenov.Requests;

public class CreateNewBook
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public string Description { get; set; }
    public int Genre_id { get; set; }
}