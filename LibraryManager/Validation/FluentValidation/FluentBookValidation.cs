using FluentValidation;
using LibraryManager.Core.Models;
using LibraryManager.Core.Validations;
namespace LibraryManager.Validation.FluentValidation
{
    public class FluentBookValidation : AbstractValidator<Book>, IValidation<Book>
    {

        public FluentBookValidation()
        {
            RuleFor(x => x.Title).NotEmpty().Length(10, 20);
            RuleFor(x => x.Author).NotEmpty();
            RuleFor(x => x.PublicationYear).Must(BeAValidPublicationYear).NotEmpty().WithMessage("Specify a valid publication year.");
            RuleFor(x => x.Isbn).NotEmpty().Length(5, 10);
        }
        
        bool BeAValidPublicationYear(int publicationYear)
        {
            if (publicationYear < 0)
            {
                return false;
            }
            return true;
        }

        public bool IsValid(Book entity)
        {
            if (!Validate(entity).IsValid)
            {
                return false;
            }
            return true;
        }
    }
}