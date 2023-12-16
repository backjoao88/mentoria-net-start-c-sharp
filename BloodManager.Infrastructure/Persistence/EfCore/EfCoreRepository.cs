using System.Linq.Expressions;
using BloodManager.Core;
using BloodManager.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BloodManager.Infrastructure.Persistence.EfCore;

public class EfCoreRepository<T> : IRepository<T> where T : BaseEntity
{
    public EfCoreRepository(EfCoreContext efCoreContext)
    {
        _efCoreContext = efCoreContext;
    }

    protected readonly EfCoreContext _efCoreContext;

    public void Save(T data)
    {
        _efCoreContext.Set<T>().Add(data);
    }

    public async Task SaveAsync(T data)
    {
        await _efCoreContext.Set<T>().AddAsync(data);
    }

    public T? Remove(T data)
    {
        var entity = FindById(data);
        if (entity is null)
        {
            return null;
        }
        entity.Delete();
        return entity;
    }

    public async Task<T?> RemoveAsync(T data)
    {
        var entity = await FindByIdAsync(data);
        if (entity is null)
        {
            return null;
        }
        entity.Delete();
        return entity;
    }

    public async Task<List<T>> FindAllAsync()
    {
        return await _efCoreContext.Set<T>().Where(o => !o.IsDeleted).ToListAsync();
    }

    public List<T> FindAll()
    {
        return _efCoreContext.Set<T>().Where(o => !o.IsDeleted).ToList();
    }

    public async Task<T?> FindByIdAsync(T data)
    {
        return await _efCoreContext.Set<T>().Where(o => !o.IsDeleted).SingleOrDefaultAsync(o => o.Id == data.Id);
    }

    public T? FindById(T data)
    {
        return _efCoreContext.Set<T>().Where(o => !o.IsDeleted).SingleOrDefault(o => o.Id == data.Id);
    }

    public List<T> Find(Expression<Func<T, bool>> predicate)
    {
        return _efCoreContext.Set<T>().Where(o => !o.IsDeleted).Where(predicate).ToList();
    }

    public Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate)
    {
        return _efCoreContext.Set<T>().Where(o => !o.IsDeleted).Where(predicate).ToListAsync();
    }
}