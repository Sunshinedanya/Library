using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BooksApi.Requests;
using BooksApi.DataBaseContext;

namespace BooksApi.Model;

public class Rentals
{
    public static async ValueTask<Rentals> Create(BooksContext context,NewRentalData data)
    {
        var rental = new Rentals();

        rental.Books = await context.GetBook(data.Book_id);
        rental.StartDate = data.StartDate;
        
        return rental;
    }

    public void EndRental()
    {
        IsReturned = true;
        EndDate = DateTime.Today;
    }
    
    [Key]
    public int id_Rental { get; set; }
    
    [Required, ForeignKey(nameof(Model.Books))]
    public int Book_id { get; set; }
    public Books Books { get; set; }
    
    [Required]
    public int Reader_id { get; set; }
    
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool IsReturned { get; set; }
}