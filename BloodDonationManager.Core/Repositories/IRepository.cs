namespace BloodDonationManager.Core.Repositories;

public interface IRepository<T> where T : class
{
    public Task SaveAsync(T data);
    public void Save(T data);
    public Task<List<T>> FindAllAsync();
    public List<T> FindAll();
    public Task RemoveAsync(int id);
    public void Remove(int id);
    public Task<T?> FindByIdAsync(int id);
    public T? FindById(int id);
}