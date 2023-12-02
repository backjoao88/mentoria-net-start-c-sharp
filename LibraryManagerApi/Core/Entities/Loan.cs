using Bogus.DataSets;
namespace LibraryManagerApi.Core.Entities;

public class Loan
{
    public int Id { get; private set; }
    public int IdBook { get; private set; }
    public Book Book { get; private set; } = null!;
    public int IdUser { get; private set; }
    public User User { get; private set; } = null!;
    public DateTime Start { get; private set; }
    public DateTime End { get; private set; }
    public DateTime? Devolution { get; private set; }
    public bool IsDeleted { get; private set; } = false;

    public Loan()
    {
    }

    public Loan(int idBook, Book book, int idUser, User user, DateTime start, DateTime end, DateTime devolution)
    {
        IdBook = idBook;
        Book = book;
        IdUser = idUser;
        User = user;
        Start = start;
        End = end;
        Devolution = devolution;
        IsDeleted = false;
    }
    
    public void Update(DateTime start, DateTime end, DateTime devolution)
    {
        Start = start;
        End = end;
        Devolution = devolution;
    }

    public void Return()
    {
        Devolution = DateTime.Now;
    }
    
}