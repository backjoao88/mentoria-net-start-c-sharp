using FluentValidation;
using LibraryManagerApi.Core.Entities;
using LibraryManagerApi.Core.Models.InputModels;
using LibraryManagerApi.Core.Repositories;
using LibraryManagerApi.Core.Validation;
using ValidationResult = LibraryManagerApi.Core.Validation.ValidationResult;
namespace LibraryManagerApi.Validations.Fluent
{
    public class LoanValidation : AbstractValidator<LoanInputModel>, IValidation<LoanInputModel>
    {

        readonly IBookRepository _bookRepository;
        readonly IUserRepository _userRepository;

        public LoanValidation(IBookRepository bookRepository, IUserRepository userRepository)
        {
            _bookRepository = bookRepository;
            _userRepository = userRepository;
            RuleFor(o => o.IdBook).NotEmpty();
            RuleFor(o => o.IdUser).NotEmpty();
            RuleFor(o => o.IdBook).Must(ExistsBookOnDatabase).WithMessage("This book doesn't exist.");
            RuleFor(o => o.IdUser).Must(ExistsUserOnDatabase).WithMessage("This user doesn't exist.");
        }

        bool ExistsUserOnDatabase(int id)
        {
            return _userRepository.FindById(id) != null;
        }

        bool ExistsBookOnDatabase(int id)
        {
            return _bookRepository.FindById(id) != null;
        }

        public ValidationResult IsValid(LoanInputModel entity)
        {
            var validationResult = Validate(entity);
            if (validationResult.IsValid)
            {
                return new ValidationResult(true, "");
            }
            return new ValidationResult(false, string.Join("; ", validationResult.Errors.ToList()));
        }
    }
}