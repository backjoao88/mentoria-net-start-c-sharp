using LibraryManager.Core.Models;
using LibraryManager.Core.Validations;
namespace LibraryManager.Validation.MyValidation
{
    public class MyBookValidation : IValidation<Book>
    {
        public bool IsValid(Book entity)
        {
            if (entity.Id == 0)
            {
                throw new Exception("ID cannot be empty.");
            }
            if (String.IsNullOrEmpty(entity.Author))
            {
                throw new Exception("Author name cannot be empty.");
            }
            if (String.IsNullOrEmpty(entity.Isbn))
            {
                throw new Exception("ISBN cannot be empty.");
            }
            if (String.IsNullOrEmpty(entity.Title))
            {
                throw new Exception("Title cannot be empty");
            }
            if (entity.PublicationYear == 0)
            {
                throw new Exception("Publication year cannot be zero (0).");
            }
            return true;
        }
    }
}