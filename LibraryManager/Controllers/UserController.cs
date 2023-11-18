using LibraryManager.Core;
using LibraryManager.Core.Models;
using LibraryManager.Core.Validation;
using Microsoft.AspNetCore.Identity;

namespace LibraryManager.Controllers
{
    public class UserController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidation<User> _validation;
        public UserController(IUnitOfWork unitOfWork, IValidation<User> validation)
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
            Console.WriteLine("~ Save an user ~");
            try
            {
                int id = ConsoleHandler.ReadNonNullIntValue("Input the user ID: ");
                string name = ConsoleHandler.ReadNonNullStringValue("Input the user name: ");
                string email = ConsoleHandler.ReadNonNullStringValue("Input the user e-mail: ");
                User user = new User(id, name, email);
                var validationResult = _validation.IsValid(user);
                if (!validationResult.IsSuccess)
                {
                    Console.WriteLine(validationResult.Message);
                    PressKey();
                    return;
                }
                
                _unitOfWork.UserRepository.Save(user);
                _unitOfWork.Complete();
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
            var data = _unitOfWork.UserRepository.FindAll();
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