using FluentValidation;
using LibraryManagerConsole.Core.Data;
using LibraryManagerConsole.Core.Models;
using LibraryManagerConsole.Core.Validation;

namespace LibraryManagerConsole.Validation.FluentValidation;

public class UserValidation : AbstractValidator<User>, IValidation<User>
{
    private readonly IUserRepository _userRepository;
    public UserValidation(IUserRepository userRepository)
    {
        _userRepository = userRepository;
        RuleFor(u => u.Id).Must(BeUniqueOnDatabase).WithMessage("This ID number is already been used.");
    }
    public ValidationResult IsValid(User entity)
    {
        var validationResult = Validate(entity);
        return validationResult.IsValid
            ? new ValidationResult(true, "")
            : new ValidationResult(false, string.Join("; ", validationResult.Errors));
    }
    private bool BeUniqueOnDatabase(int id)
    {
        var user = _userRepository.Find(u => u.Id == id).SingleOrDefault();
        return user == null;
    }
}