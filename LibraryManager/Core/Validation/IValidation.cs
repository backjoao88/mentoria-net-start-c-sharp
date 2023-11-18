namespace LibraryManager.Core.Validation
{
    public interface IValidation<in TEntity> where TEntity : class
    {
        public ValidationResult IsValid(TEntity entity);
    }
}