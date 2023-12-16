namespace BloodManager.Core.Validations;

public interface IValidation<T> where T : class
{
    Task<ValidationResult> IsValidAsync(T data);
}