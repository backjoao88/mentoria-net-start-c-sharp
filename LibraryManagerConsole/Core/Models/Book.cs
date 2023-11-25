namespace LibraryManagerConsole.Core.Models
{
    public class Book
    {
        public int Id { get; private set; }
        public string Author { get; private set; }
        public string Title { get; private set; }
        public string Isbn { get; private set; }
        public int PublicationYear { get; private set; }
        
        public List<Borrow> Borrows { get; private set; }
        
        public Book(int id, string author, string title, string isbn, int publicationYear)
        {
            Id = id;
            Author = author;
            Title = title;
            Isbn = isbn;
            PublicationYear = publicationYear;
        }

        public void Update(string author, string title, string isbn, int publicationYear)
        {
            this.Author = author;
            this.Title = title;
            this.Isbn = isbn;
            this.PublicationYear = publicationYear;
        }
        
        public override string ToString()
        {
            return $"Id: {Id}, Author: {Author}, Title: {Title}, Isbn: {Isbn}, PublicationYear: {PublicationYear}";
        }

    }
}