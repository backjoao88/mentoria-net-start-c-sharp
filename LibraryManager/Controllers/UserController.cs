using LibraryManager.Core;
using LibraryManager.Core.Models;
namespace LibraryManager.Controllers
{
    public class UserController
    {
        IUnitOfWork UnitOfWork { get; }
        public UserController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
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
            Console.WriteLine("~ Save an user ~");
            try
            {
                int id = ConsoleHandler.ReadNonNullIntValue("Input the user ID: ");
                string name = ConsoleHandler.ReadNonNullStringValue("Input the user name: ");
                string email = ConsoleHandler.ReadNonNullStringValue("Input the user e-mail: ");
                User user = new User(id, name, email);
                UnitOfWork.UserRepository.Save(user);
                UnitOfWork.Complete();
                Console.WriteLine("~ User added successfully.");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"An error occurred while trying to save to the database. Error: {exception.Message}");
            }
            PressKey();
        }

        public void Fetch()
        {
            Console.Clear();
            Console.WriteLine("~ List of stored users ~");
            var data = UnitOfWork.UserRepository.FindAll();
            if (data.Any())
                foreach (var user in data)
                {
                    Console.WriteLine(user.ToString());
                }
            else
                Console.WriteLine("No user found.");
            PressKey(); 
        }
    }
}