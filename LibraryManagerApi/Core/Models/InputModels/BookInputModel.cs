namespace LibraryManagerApi.Core.Models.InputModels;
public class BookInputModel
{
    public string Title { get; set; } = "";
    public string Author { get; set; } = "";
    public string Isbn { get; set; } = "";
    public int PublicationYear { get; set; }

    public BookInputModel(string title, string author, string isbn, int publicationYear)
    {
        Title = title;
        Author = author;
        Isbn = isbn;
        PublicationYear = publicationYear;
    }
}