using FluentValidation;
using LibraryManager.Core.Data;
using LibraryManager.Core.Models;
using LibraryManager.Core.Validation;
namespace LibraryManager.Validation.FluentValidation
{
    public class BorrowValidation : AbstractValidator<Borrow>, IValidation<Borrow>
    {
        private readonly IBorrowRepository _borrowRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;

        public BorrowValidation(IBorrowRepository borrowRepository, IBookRepository bookRepository, IUserRepository userRepository)
        {
            _borrowRepository = borrowRepository;
            _bookRepository = bookRepository;
            _userRepository = userRepository;
            RuleFor(b => b.Id).Must(BeUniqueOnDatabase).WithMessage("This ID number is already been used.");
            RuleFor(o => o.IdBook).Must(ExistsBookOnDatabase).WithMessage("This book ID doesn't exist.");
            RuleFor(o => o.IdUser).Must(ExistsUserOnDatabase).WithMessage("This user ID doesn't exist.");
        }

        bool ExistsUserOnDatabase(int id)
        {
            var user = _userRepository.Find(u => u.Id == id).SingleOrDefault();
            return user != null;
        }

        bool ExistsBookOnDatabase(int id)
        {
            var book = _bookRepository.Find(o => o.Id == id).SingleOrDefault();
            return book != null;
        }

        bool BeUniqueOnDatabase(int id)
        {
            var borrow = _borrowRepository.Find(o => o.Id == id).SingleOrDefault();
            return borrow == null;
        }
        
        public ValidationResult IsValid(Borrow entity)
        {
            var fluentValidation = Validate(entity);
            return fluentValidation.IsValid
                ? new ValidationResult(true, "")
                : new ValidationResult(false, string.Join(" ", fluentValidation.Errors));
        }
    }
}