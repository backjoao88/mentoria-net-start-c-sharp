using BloodDonationManager.Core.Entities.Interfaces;
using BloodDonationManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationManager.Infrastructure.Persistence.Ef;

public class EfRepository<T> : IRepository<T> where T : class, IIdentificable, IDeletable
{

    protected readonly EfDbContext EfDbContext;

    public EfRepository(EfDbContext efDbContext)
    {
        EfDbContext = efDbContext;
    }

    public async Task SaveAsync(T data)
    {
        await EfDbContext.Set<T>().AddAsync(data);
    }

    public void Save(T data)
    {
        EfDbContext.Set<T>().Add(data);
    }

    public async Task<List<T>> FindAllAsync()
    {
        var data = await EfDbContext.Set<T>().ToListAsync();
        return data;
    }

    public List<T> FindAll()
    {
        var data = EfDbContext.Set<T>().ToList();
        return data;
    }
    
    public async Task<T?> FindByIdAsync(int id)
    {
        var data = await EfDbContext.Set<T>().SingleOrDefaultAsync(o => o.Id == id);
        return data;
    }

    public T? FindById(int id)
    {
        var data = EfDbContext.Set<T>().SingleOrDefault(o => o.Id == id);
        return data;
    }

    public async Task RemoveAsync(int id)
    {
        var data = await FindByIdAsync(id);
        if (data is null)
        {
            return;
        }
        data.Delete();
    }

    public void Remove(int id)
    {
        var data = FindById(id);
        if (data is null)
        {
            return;
        }
        data.Delete();
    }
}