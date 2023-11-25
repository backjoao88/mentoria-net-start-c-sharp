using LibraryManagerConsole.Core.Models;
using LibraryManagerConsole.Core.Validation;
namespace LibraryManagerConsole.Validation.MyValidation
{
    public class MyBookValidation : IValidation<Book>
    {
        public ValidationResult IsValid(Book entity)
        {
            if (entity.Id == 0)
            {
                return new ValidationResult(false, "ID cannot be zero (0).");
            }
            if (String.IsNullOrEmpty(entity.Author))
            {
                return new ValidationResult(false, "Author cannot be empty.");
            }
            if (String.IsNullOrEmpty(entity.Isbn))
            {
                return new ValidationResult(false, "ISBN cannot be empty.");
            }
            if (String.IsNullOrEmpty(entity.Title))
            {
                return new ValidationResult(false, "Title cannot be empty.");
            }
            if (entity.PublicationYear == 0)
            {
                return new ValidationResult(false, "Publication year cannot be zero (0). ");
            }
            return new ValidationResult(true, "");
        }
    }
}