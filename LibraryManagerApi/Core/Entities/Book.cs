namespace LibraryManagerApi.Core.Entities;

public class Book
{
    public int Id { get; private set; }
    public string Title { get; private set; } = null!;
    public string Author { get; private set; } = null!;
    public string Isbn { get; private set; } = null!;
    public int PublicationYear { get; private set; }
    public bool IsDeleted { get; private set;  }
    public int Quantity { get; private set; }
    public int MinQuantityAllowed { get; private set; }
    
    public Book()
    {
    }

    public Book(string title, string author, string isbn, int publicationYear)
    {
        Title = title;
        Author = author;
        Isbn = isbn;
        PublicationYear = publicationYear;
    }

    public void Update(string title, string author, string isbn, int publicationYear)
    {
        Title = title;
        Author = author;
        Isbn = isbn;
        PublicationYear = publicationYear;
    }
    
    public void Delete()
    {
        IsDeleted = true;
    }

    public void Increase(int quantity)
    {
        Quantity += quantity;
    }

    public void Decrease(int quantity)
    {
        var futureQuantity = Quantity - quantity;
        if (futureQuantity < MinQuantityAllowed)
        {
            throw new Exception("Min quantity allowed reached.");
        }
        Quantity -= quantity;
    }
    
}