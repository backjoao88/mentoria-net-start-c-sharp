using LibraryManager.Core;
using LibraryManager.Core.Models;
namespace LibraryManager.Controllers
{
    public class BorrowController
    {
        
        IUnitOfWork UnitOfWork { get; }

        public BorrowController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
        
        void PressKey()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public void Fetch()
        {
            Console.Clear();
            int option = 0;
            while (option != -1)
            {
                ConsoleHandler.ShowFetchBorrowMenu();
                option = ConsoleHandler.AskFetchMenuInput();
                switch (option)
                {
                    case 1:
                    {
                        FetchAllBorrows();
                        break;
                    }
                    default:
                        Console.Clear();
                        option = -1;
                        break;
                }
            }
        }
        void FetchAllBorrows()
        {
            Console.Clear();
            Console.WriteLine("~ List of stored borrows ~");
            var data = UnitOfWork.BorrowRepository.FindAll();
            if (data.Any())
                foreach (var borrow in data)
                {
                    Console.WriteLine(borrow.ToString());
                }
            else
                Console.WriteLine("No borrow found.");
            PressKey();
        }

        public void Save()
        {
            Console.Clear();
            Console.WriteLine("~ Save an user ~");
            try
            {
                int id = ConsoleHandler.ReadNonNullIntValue("Input the borrow ID: ");
                int idUser = ConsoleHandler.ReadNonNullIntValue("Input the user ID: ");
                int idBook = ConsoleHandler.ReadNonNullIntValue("Input the book ID: ");
                DateTime start = DateTime.Now;
                DateTime end = DateTime.Now.AddDays(5); // mudar
                Borrow borrow = new Borrow(id, idUser, idBook, start, end);
                UnitOfWork.BorrowRepository.Save(borrow);
                UnitOfWork.Complete();
                Console.WriteLine("~ User added successfully.");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"An error occurred while trying to save to the database. Error: {exception.Message}");
            }
            PressKey();
        }
    }
}