namespace LibraryManager.Core.Validations
{
    public interface IValidation<in TEntity> where TEntity : class
    {
        public bool IsValid(TEntity entity);
    }
}