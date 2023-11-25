using LibraryManagerApi.Core.Repositories;

namespace LibraryManagerApi.Persistence.Ef;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected DatabaseContext Context { get; }
    public Repository(DatabaseContext context)
    {
        Context = context;
    }

    public void Save(TEntity entity)
    {
        Context.Set<TEntity>().Add(entity);
    }

    public IEnumerable<TEntity> FindAll()
    {
        return Context.Set<TEntity>().ToList();
    }
}