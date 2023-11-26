using FluentValidation;
using LibraryManagerApi.Core.Models.InputModels;
using LibraryManagerApi.Core.Validation;
namespace LibraryManagerApi.Validations.Fluent
{
    public class UserValidation : AbstractValidator<UserInputModel>, IValidation<UserInputModel>
    {

        public UserValidation()
        {
            RuleFor(o => o.Name).NotEmpty();
            RuleFor(o => o.Email).NotEmpty();
        }

        public ValidationResult IsValid(UserInputModel entity)
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