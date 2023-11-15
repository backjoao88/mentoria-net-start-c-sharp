namespace LibraryManager.Core.Validations
{
    public class ValidationError
    {
        public string Message { get; private set; }
        
        public ValidationError(string message)
        {
            Message = message;
        }
    }
}