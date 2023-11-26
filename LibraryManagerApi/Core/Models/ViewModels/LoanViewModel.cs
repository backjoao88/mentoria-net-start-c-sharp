using LibraryManagerApi.Core.Entities;
namespace LibraryManagerApi.Core.Models.ViewModels;

public class LoanViewModel
{
    public Guid Id { get; set; }
    public Guid IdUser { get; set; }

    public User User { get; set; } = null!;
    public Guid IdBook { get; set; }

    public Book Book { get; set; } = null!;
    public DateTime Start { get; set; }
    public DateTime End { get; set; }
    public DateTime Devolution { get; set; }

    public LoanViewModel(Guid idUser, Guid idBook, DateTime start, DateTime end, DateTime devolution)
    {
        IdUser = idUser;
        IdBook = idBook;
        Start = start;
        End = end;
        Devolution = devolution;
    }
}