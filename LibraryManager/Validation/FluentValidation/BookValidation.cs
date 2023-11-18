using FluentValidation;
using LibraryManager.Core.Data;
using LibraryManager.Core.Models;
using LibraryManager.Core.Validation;
using LibraryManager.Database.Data;
namespace LibraryManager.Validation.FluentValidation
{
    public class BookValidation : AbstractValidator<Book>, IValidation<Book>
    {
        private readonly IBookRepository _bookRepository;
        public BookValidation(IBookRepository bookRepository)
        {
            this._bookRepository = bookRepository;
            RuleFor(x => x.Title).NotEmpty().Length(10, 20);
            RuleFor(x => x.Author).NotEmpty();
            RuleFor(x => x.PublicationYear).Must(BeAValidPublicationYear).NotEmpty().WithMessage("Specify a valid publication year.");
            RuleFor(x => x.Isbn).NotEmpty().Length(5, 10);
            RuleFor(x => x.Id).Must(BeUniqueOnDatabase).WithMessage("This ID number is already been used.");
        }

        bool BeUniqueOnDatabase(int id)
        {
            var book = _bookRepository.Find(b => b.Id == id).SingleOrDefault();
            return book == null;
        }

        bool BeAValidPublicationYear(int publicationYear)
        {
            return publicationYear > 0;
        }

        public ValidationResult IsValid(Book entity)
        {
            var fluentValidation = Validate(entity);
            return fluentValidation.IsValid 
                ? new ValidationResult(true, "") 
                : new ValidationResult(false, string.Join(" ", fluentValidation.Errors));
        }
    }
}