using LibraryManagerConsole.Core.Data;
using LibraryManagerConsole.Core;
using LibraryManagerConsole.Core.Models;
using LibraryManagerConsole.Core.Validation;
namespace LibraryManagerConsole.Controllers
{
    public class BookController
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IValidation<Book> _validation;

        public BookController(IUnitOfWork unitOfWork, IValidation<Book> validation)
        {
            _unitOfWork = unitOfWork;
            _validation = validation;
        }

        void PressKey()
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

            var validationResult = _validation.IsValid(book);
            if (!validationResult.IsSuccess)
            {
                Console.WriteLine(validationResult.Message);
                PressKey();
                return;
            }

            try
            {
                _unitOfWork.BookRepository.Save(book);
                _unitOfWork.Complete();
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
            var data = _unitOfWork.BookRepository.FindAll();
            if (data.Any())
                foreach (var book in data)
                {
                    Console.WriteLine(book.ToString());
                }
            else
                Console.WriteLine("No book found to update.");
            if (!data.Any()) return;
            Console.WriteLine("~ Update a book ~");
            var tryAgain = true;
            Book? foundBook = null;
            while (tryAgain)
                try
                {
                    var id = ConsoleHandler.ReadIntValue("Input the book ID (0 to leave): ");
                    if (id == 0)
                    {
                        Console.Clear();
                        return;
                    }
                    foundBook = _unitOfWork.BookRepository.Find((book) => book.Id == id).First();
                    tryAgain = false;
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"An error occured while trying to find a book. Error: {exception.Message}");
                    tryAgain = true;
                }
            if (foundBook == null) return;
            Console.WriteLine(foundBook);
            var newTitle = ConsoleHandler.ReadStringValue($"Input the new book title (empty to keep \"{foundBook.Title}\"): ");
            var newAuthor = ConsoleHandler.ReadStringValue($"Input the new book author (empty to keep \"{foundBook.Author}\"): ");
            var newIsbn = ConsoleHandler.ReadStringValue($"Input the new book ISBN (empty to keep \"{foundBook.Isbn}\"): ");
            var newPublicationYear =
                ConsoleHandler.ReadIntValue($"Input the new book publication year (empty to keep \"{foundBook.PublicationYear}\"): ");

            foundBook.Update(
                newTitle.Any() ? newTitle : foundBook.Title,
                newAuthor.Any() ? newAuthor : foundBook.Author,
                newIsbn.Any() ? newIsbn : foundBook.Isbn,
                newPublicationYear != 0 ? newPublicationYear : foundBook.PublicationYear
            );

            _unitOfWork.Complete();
            PressKey();
        }

        void FetchAllBooks()
        {
            Console.Clear();
            Console.WriteLine("~ List of stored books ~");
            var data = _unitOfWork.BookRepository.FindAll();
            if (data.Any())
                foreach (var book in data)
                {
                    Console.WriteLine(book.ToString());
                }
            else
                Console.WriteLine("No book found.");
            PressKey();
        }

        public void Fetch()
        {
            Console.Clear();
            var option = 0;
            while (option != -1)
            {
                ConsoleHandler.ShowFetchMenu();
                option = ConsoleHandler.AskFetchMenuInput();
                switch (option)
                {
                    case 1:
                    {
                        FetchAllBooks();
                        break;
                    }
                    case 2:
                    {
                        FetchBooksByAuthor();
                        break;
                    }
                    default:
                        Console.Clear();
                        option = -1;
                        break;
                }
            }
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
                    var data = _unitOfWork.BookRepository.FindAll();
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
                    book = _unitOfWork.BookRepository.Find((b) => b.Id == id).First();
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
                _unitOfWork.BookRepository.Remove(book);
                _unitOfWork.Complete();
                Console.WriteLine("~ Book removed successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occured while trying to find the book. Error: {e.Message}");

            }

            PressKey();
        }

        void FetchBooksByAuthor()
        {
            Console.Clear();
            Console.WriteLine("~ Find book by author ~");
            var findAuthor = ConsoleHandler.ReadStringValue("Input the book author name: ");
            var booksByAuthor = _unitOfWork.BookRepository.Find((book) =>
                book != null && book.Author.StartsWith(findAuthor, StringComparison.OrdinalIgnoreCase));
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