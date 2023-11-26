namespace LibraryManagerApi.Core.Entities;

public class Book
{
    public Guid Id { get; private set; }
    public string Title { get; private set; } = null!;
    public string Author { get; private set; } = null!;
    public string Isbn { get; private set; } = null!;
    public int PublicationYear { get; private set; }
    public bool IsDeleted { get; private set; }

    public Book()
    {
    }

    public Book(Guid id, string title, string author, string isbn, int publicationYear)
    {
        Id = id;
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
    
}