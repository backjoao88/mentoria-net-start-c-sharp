using LibraryManager.Controllers;
using LibraryManager.Core.Data;
using LibraryManager.Core.Models;
using LibraryManager.Database;
using LibraryManager.Database.Data;
namespace LibraryManager
{
    public abstract class App
    {
        public static void Main(string[] args)
        {
            {
                var loadInitialData = "N";
                do
                {
                    Console.WriteLine("~ Load initial data (S/N)");
                    loadInitialData = ConsoleHandler.ReadStringValue();
                } while (!"S".Equals(loadInitialData, StringComparison.OrdinalIgnoreCase) && !"N".Equals(loadInitialData, StringComparison.OrdinalIgnoreCase));
                if ("S".Equals(loadInitialData, StringComparison.OrdinalIgnoreCase))
                {
                    using var dbUow = new EfUnitOfWork(new EfContext());
                    dbUow.BookData.Save(new Book(1, "Sun Tzu", "A arte da guerra", "8594318596", 2019));
                    dbUow.BookData.Save(
                        new Book(2, "Mans Mosesson", "Tim - The official autobiography of Avicii", "0751579009", 2021));
                    dbUow.BookData.Save(new Book(3, "Carl Sagan", "Pálido ponto azul", "8535931937  ", 2019));
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
                        var bookController = new BookController(dbUow);
                        bookController.Save();
                        break;
                    }
                    case 2:
                    {
                        using var dbUow = new EfUnitOfWork(new EfContext());
                        var bookController = new BookController(dbUow);
                        bookController.FindAll();
                        break;
                    }
                    case 3:
                    {
                        using var dbUow = new EfUnitOfWork(new EfContext());
                        var bookController = new BookController(dbUow);
                        bookController.Remove();
                        break;
                    }
                    case 4:
                    {

                        using var uow = new EfUnitOfWork(new EfContext());
                        var bookController = new BookController(uow);
                        bookController.Update();
                        break;
                    }
                    case 5:
                    {
                        using var uow = new EfUnitOfWork(new EfContext());
                        var bookController = new BookController(uow);
                        bookController.FindByAuthor();
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