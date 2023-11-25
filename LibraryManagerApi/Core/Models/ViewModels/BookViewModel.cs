namespace LibraryManagerApi.Core.Models.ViewModels;

public class BookViewModel
{
    public string Title { get; set; } = "";
    public string Author { get; set; } = "";
    public string Isbn { get; set; } = "";
    public int PublicationYear { get; set; }

    public BookViewModel(string title, string author, string isbn, int publicationYear)
    {
        Title = title;
        Author = author;
        Isbn = isbn;
        PublicationYear = publicationYear;
    }
}