namespace LibraryManagerConsole.Core.Validation
{
    public class ValidationResult
    {
        public bool IsSuccess { get; set; } = false;
        public string Message { get; set; } = "";

        public ValidationResult(bool isSuccess, string message)
        {
            IsSuccess = isSuccess;
            Message = message;
        }
    }
}