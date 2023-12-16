using System.Linq.Expressions;
using BloodManager.Core.Entities;

namespace BloodManager.Core;

public interface IRepository<T> where T : BaseEntity
{
    public void Save(T data);
    public Task SaveAsync(T data);
    public T? Remove(T data);
    public Task<T?> RemoveAsync(T data);
    public Task<List<T>> FindAllAsync();
    public List<T> FindAll();
    public Task<T?> FindByIdAsync(T data);
    public T? FindById(T data);
    public Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate);
    public List<T> Find(Expression<Func<T, bool>> predicate);
}