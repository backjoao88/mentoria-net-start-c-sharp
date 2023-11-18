using LibraryManager.Core;
using LibraryManager.Core.Data;
using LibraryManager.Core.Models;
using LibraryManager.Core.Validation;
namespace LibraryManager.Controllers
{
    public class BorrowController
    {

        readonly IUnitOfWork _unitOfWork;
        readonly IValidation<Borrow> _validation;

        public BorrowController(IUnitOfWork unitOfWork, IValidation<Borrow> validation)
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
            var data = _unitOfWork.BorrowRepository.FindAll();
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
            Console.WriteLine("~ Save a borrow ~");
            try
            {
                int id = ConsoleHandler.ReadNonNullIntValue("Input the borrow ID: ");
                var usersData = _unitOfWork.UserRepository.FindAll();
                if (usersData.Any())
                {
                    foreach (var user in usersData)
                    {
                        Console.WriteLine(user.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("No user found.");
                    PressKey();
                    return;
                }
                int idUser = ConsoleHandler.ReadNonNullIntValue("Input the user ID: ");
                var booksData = _unitOfWork.BookRepository.FindAll();
                if (booksData.Any())
                {
                    foreach (var book in booksData)
                    {
                        Console.WriteLine(book.ToString());
                    }
                }
                else
                {
                    Console.WriteLine("No book found.");
                    PressKey();
                    return;
                }
                int idBook = ConsoleHandler.ReadNonNullIntValue("Input the book ID: ");
                DateTime start = DateTime.Now;
                Borrow borrow = new Borrow(id, idUser, idBook, start);
                
                var validationResult = _validation.IsValid(borrow);
                if (!validationResult.IsSuccess)
                {
                    Console.WriteLine(validationResult.Message);
                    PressKey();
                    return;
                }
                _unitOfWork.BorrowRepository.Save(borrow);
                _unitOfWork.Complete();
                Console.WriteLine("~ Borrow added successfully.");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"An error occurred while trying to save to the database. Error: {exception.Message}");
            }
            PressKey();
        }
    }
}