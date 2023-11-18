using FluentValidation;
using LibraryManager.Core.Data;
using LibraryManager.Core.Models;
using LibraryManager.Core.Validation;
namespace LibraryManager.Validation.FluentValidation
{
    public class BorrowValidation : AbstractValidator<Borrow>, IValidation<Borrow>
    {
        readonly IBorrowRepository _borrowRepository;
        readonly IBookRepository _bookRepository;
        readonly IUserRepository _userRepository;

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
            if (user == null)
            {
                return false;
            }
            return true;
        }

        bool ExistsBookOnDatabase(int id)
        {
            var book = _bookRepository.Find(o => o.Id == id).SingleOrDefault();
            if (book == null)
            {
                return false;
            }
            return true;
        }

        bool BeUniqueOnDatabase(int id)
        {
            var borrow = _borrowRepository.Find(o => o.Id == id).SingleOrDefault();
            if (borrow == null)
            {
                return true;
            }
            return false;
        }


        public ValidationResult IsValid(Borrow entity)
        {
            var fluentValidation = Validate(entity);
            if (!fluentValidation.IsValid)
            {
                return new ValidationResult(false, string.Join(" ", fluentValidation.Errors));
            }
            return new ValidationResult(true, "");
        }
    }
}