using DevFreela.Core.Repositories;

namespace DevFreela.Infrastructure.Persistence;

public class EfRepository<T> : IRepository<T> where T: class
{
    
    protected readonly EfDbContext _dbContext;

    public EfRepository(EfDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Save(T data)
    {
        _dbContext.Set<T>().Add(data);
    }

    public List<T> FindAll()
    {
        return _dbContext.Set<T>().ToList();
    }
}