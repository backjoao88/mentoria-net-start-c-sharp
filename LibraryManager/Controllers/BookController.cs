using LibraryManager.Core;
using LibraryManager.Core.Data;
using LibraryManager.Core.Models;
namespace LibraryManager.Controllers
{
    public class BookController
    {
        public IUnitOfWork UnitOfWork { get; set; }

        public BookController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public void PressKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public void Save()
        {
            Console.Clear();
            Console.WriteLine("~ Save a book ~");
            var id = ConsoleHandler.ReadNonNullIntValue("Input the book ID: ");
            var title = ConsoleHandler.ReadNonNullStringValue("Input the book title: ");
            var author = ConsoleHandler.ReadNonNullStringValue("Input the book author: ");
            var isbn = ConsoleHandler.ReadNonNullStringValue("Input the book ISBN: ");
            var publicationYear = ConsoleHandler.ReadNonNullIntValue("Input the book publication year: ");
            var book = new Book(id, author, title, isbn, publicationYear);
            try
            {
                UnitOfWork.BookData.Save(book);
                UnitOfWork.Complete();
                Console.WriteLine("~ Book added successfully.");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"An error occurred while trying to save to the database. Error: {exception.Message}");
            }
            PressKey();
        }

        public void Update()
        {
            Console.Clear();
            Console.WriteLine("~ List of stored books ~");
            var data = UnitOfWork.BookData.FindAll();
            if (data.Any())
                foreach (var book in data)
                {
                    Console.WriteLine(book.ToString());
                }
            else
                Console.WriteLine("No book found to update.");
            if (!data.Any())
            {
                return;
            }
            Console.WriteLine("~ Update a book ~");
            bool tryAgain = true;
            Book? foundBook = null;
            while (tryAgain)
            {
                try
                {
                    var id = ConsoleHandler.ReadIntValue("Input the book ID (0 to leave): ");
                    if (id == 0)
                    {
                        Console.Clear();
                        return;
                    }
                    foundBook = UnitOfWork.BookData.Find((book) => book.Id == id).First();
                    tryAgain = false;
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"An error occured while trying to find a book. Error: {exception.Message}");
                    tryAgain = true;
                }
            }
            if (foundBook == null)
            {
                return;
            }
            Console.WriteLine(foundBook);
            var newTitle = ConsoleHandler.ReadStringValue($"Input the new book title (empty to keep \"{foundBook.Title}\"): ");
            var newAuthor = ConsoleHandler.ReadStringValue($"Input the new book author (empty to keep \"{foundBook.Author}\"): ");
            var newIsbn = ConsoleHandler.ReadStringValue($"Input the new book ISBN (empty to keep \"{foundBook.Isbn}\"): ");
            var newPublicationYear = ConsoleHandler.ReadIntValue($"Input the new book publication year (empty to keep \"{foundBook.PublicationYear}\"): ");
            foundBook.Title = newTitle.Any() ? newTitle : foundBook.Title;
            foundBook.Author = newAuthor.Any() ? newAuthor : foundBook.Author;
            foundBook.Isbn = newIsbn.Any() ? newIsbn : foundBook.Isbn;
            foundBook.PublicationYear = newPublicationYear != 0 ? newPublicationYear : foundBook.PublicationYear;
            UnitOfWork.Complete();
            PressKey();
        }

        public void FindAll()
        {
            Console.Clear();
            Console.WriteLine("~ List of stored books ~");
            var data = UnitOfWork.BookData.FindAll();
            if (data.Any())
                foreach (var book in data)
                {
                    Console.WriteLine(book.ToString());
                }
            else
                Console.WriteLine("No book found.");
            PressKey();
        }

        public void Remove()
        {
            Console.Clear();
            Console.WriteLine("~ Remove a book ~");
            var tryAgainList = true;
            Book? book = null;
            while (tryAgainList)
                try
                {
                    Console.WriteLine("~ List of stored books ~");
                    var data = UnitOfWork.BookData.FindAll();
                    if (data.Any())
                    {
                        foreach (var b in data)
                        {
                            Console.WriteLine(b.ToString());
                        }
                    }
                    else
                    {
                        Console.WriteLine("No book found.");
                        PressKey();
                        return;
                    }
                    var id = ConsoleHandler.ReadIntValue("Choose the book ID to be removed (0 to leave): ");
                    if (id == 0)
                    {
                        Console.Clear();
                        return;
                    }
                    book = UnitOfWork.BookData.Find((b) => b.Id == id).First();
                    tryAgainList = false;
                }
                catch (Exception exception)
                {
                    Console.WriteLine("An error occured while trying to find the book. Try again.");
                    tryAgainList = true;
                }
            if (book == null)
            {
                Console.WriteLine("~ No book found.");
                return;
            }

            try
            {
                Console.WriteLine($"~ Removing book: {book.ToString()}");
                UnitOfWork.BookData.Remove(book);
                UnitOfWork.Complete();
                Console.WriteLine("~ Book removed successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occured while trying to find the book. Error: {e.Message}");

            }

            PressKey();
        }

        public void FindByAuthor()
        {
            Console.Clear();
            Console.WriteLine("~ Find book by author ~");
            var findAuthor = ConsoleHandler.ReadStringValue("Input the book author name: ");
            var booksByAuthor = UnitOfWork.BookData.Find((book) => book != null && book.Author.StartsWith(findAuthor, StringComparison.OrdinalIgnoreCase));
            Console.Clear();
            Console.WriteLine("~ List of books by author");
            foreach (var book in booksByAuthor)
            {
                Console.WriteLine(book);
            }
            PressKey();
        }

    }
}