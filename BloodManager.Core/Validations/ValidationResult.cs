namespace BloodManager.Core.Validations;

public class ValidationResult
{
    public ValidationResult(bool success, string errors)
    {
        Success = success;
        Errors = errors;
    }

    public bool Success { get; set; }
    public string Errors { get; set; } = "";
}