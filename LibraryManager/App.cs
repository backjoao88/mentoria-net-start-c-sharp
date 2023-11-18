using LibraryManager.Controllers;
using LibraryManager.Core.Data;
using LibraryManager.Core.Models;
using LibraryManager.Database;
using LibraryManager.Database.Data;
using LibraryManager.Validation.FluentValidation;
using LibraryManager.Validation.MyValidation;
namespace LibraryManager
{
    public abstract class App
    {
        public static void Main(string[] args)
        {
            {
                var loadInitialData = "S";
                // do
                // {
                //     Console.WriteLine("~ Load initial data (S/N)");
                //     loadInitialData = ConsoleHandler.ReadStringValue();
                // } while (loadInitialData != "S" && loadInitialData != "N");
                if (loadInitialData == "S")
                {
                    using var dbUow = new EfUnitOfWork(new EfContext());
                    dbUow.BookRepository.Save(new Book(1, "Sun Tzu", "A arte da guerra", "8594318596", 2019));
                    dbUow.BookRepository.Save(
                        new Book(2, "Mans Mosesson", "Tim - The official autobiography of Avicii", "0751579009", 2021));
                    dbUow.BookRepository.Save(new Book(3, "Carl Sagan", "Pálido ponto azul", "8535931937  ", 2019));
                    dbUow.UserRepository.Save(new User(1, "João", "joao@gmail.com"));
                    dbUow.BorrowRepository.Save(new Borrow(1, 1, 1, new DateTime()));
                    dbUow.Complete();
                }
                Console.Clear();
            }

            var option = 0;
            while (option != -1)
            {
                ConsoleHandler.ShowLibraryManagerMenu();
                option = ConsoleHandler.AskInput();
                switch (option)
                {
                    case 1:
                    {
                        using var dbUow = new EfUnitOfWork(new EfContext());
                        var bookValidator = new BookValidation(dbUow.BookRepository);
                        var bookController = new BookController(dbUow, bookValidator);
                        bookController.Save();
                        break;
                    }
                    case 2:
                    {
                        using var dbUow = new EfUnitOfWork(new EfContext());
                        var bookValidator = new MyBookValidation();
                        var bookController = new BookController(dbUow, bookValidator);
                        bookController.Remove();
                        break;
                    }
                    case 3:
                    {
                        using var dbUow = new EfUnitOfWork(new EfContext());
                        var bookValidator = new MyBookValidation();
                        var bookController = new BookController(dbUow, bookValidator);
                        bookController.Update();
                        break;
                    }
                    case 4:
                    {
                        using var dbUow = new EfUnitOfWork(new EfContext());
                        var userValidator = new UserValidation(dbUow.UserRepository);
                        var userController = new UserController(dbUow, userValidator);
                        userController.Save();
                        break;
                    }
                    case 5:
                    {
                        using var dbUow = new EfUnitOfWork(new EfContext());
                        var borrowValidator = new BorrowValidation(dbUow.BorrowRepository, dbUow.BookRepository, dbUow.UserRepository);
                        var borrowController = new BorrowController(dbUow, borrowValidator);
                        borrowController.Save();
                        break;
                    }
                    case 6:
                    {
                        using var dbUow = new EfUnitOfWork(new EfContext());
                        var bookValidator = new MyBookValidation();
                        var bookController = new BookController(dbUow, bookValidator);
                        bookController.Fetch();
                        break;
                    }
                    case 7:
                    {
                        using var dbUow = new EfUnitOfWork(new EfContext());
                        var borrowValidator = new BorrowValidation(dbUow.BorrowRepository, dbUow.BookRepository, dbUow.UserRepository);
                        var borrowController = new BorrowController(dbUow, borrowValidator);
                        borrowController.Fetch();
                        break;
                    }
                    case 8:
                    {
                        using var dbUow = new EfUnitOfWork(new EfContext());
                        var userValidator = new UserValidation(dbUow.UserRepository);
                        var userController = new UserController(dbUow, userValidator);
                        userController.Fetch();
                        break;
                    }
                    case 99:
                        option = -1;
                        Console.WriteLine(">> Leaving app..");
                        break;
                    default:
                        option = -1;
                        break;
                }
            }
        }
    }
}