using FluentValidation;
using LibraryManagerApi.Core.Entities;
using LibraryManagerApi.Core.Models.InputModels;
using LibraryManagerApi.Core.Validation;

namespace LibraryManagerApi.Validations.Fluent;

public class BookValidation : AbstractValidator<BookInputModel>, IValidation<BookInputModel>
{
    public BookValidation()
    {
        RuleFor(o => o.Title).NotEmpty();
        RuleFor(o => o.Isbn).NotEmpty();
        RuleFor(o => o.Author).NotEmpty();
        RuleFor(o => o.PublicationYear).NotEqual(0);
    }


    public ValidationResult IsValid(BookInputModel entity)
    {
        var validationResult = Validate(entity);
        if (validationResult.IsValid)
        {
            return new ValidationResult(true, "");
        }

        return new ValidationResult(false, string.Join("; ", validationResult.Errors.ToList()));
    }
}