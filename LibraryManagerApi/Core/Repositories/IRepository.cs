namespace LibraryManagerApi.Core.Repositories;

public interface IRepository<TEntity> where TEntity : class
{
    public void Save(TEntity entity);
    public IEnumerable<TEntity> FindAll();
}