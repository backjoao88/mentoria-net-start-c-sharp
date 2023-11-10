namespace LibraryManager.Core.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Isbn { get; set; }
        public int PublicationYear { get; set; }
        
        public Book(int id, string author, string title, string isbn, int publicationYear)
        {
            Id = id;
            Author = author;
            Title = title;
            Isbn = isbn;
            PublicationYear = publicationYear;
        }
        
        public override string ToString()
        {
            return $"Id: {Id}, Author: {Author}, Title: {Title}, Isbn: {Isbn}, PublicationYear: {PublicationYear}";
        }

    }
}