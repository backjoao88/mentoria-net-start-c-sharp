using BloodManager.Core;
using BloodManager.Core.Repositories;

namespace BloodManager.Infrastructure.Persistence.EfCore;

public class EfCoreUnitOfWork : IUnitOfWork
{
    public EfCoreUnitOfWork(EfCoreContext efCoreContext, IDonorRepository donorRepository, IDonationRepository donationRepository, IStockRepository stockRepository)
    {
        _efCoreContext = efCoreContext;
        DonorRepository = donorRepository;
        DonationRepository = donationRepository;
        StockRepository = stockRepository;
    }

    public IDonorRepository DonorRepository { get; set; }
    public IDonationRepository DonationRepository { get; set; }
    public IStockRepository StockRepository { get; set; }
    private readonly EfCoreContext _efCoreContext;

    public int Complete()
    {
        return _efCoreContext.SaveChanges();
    }

    public async Task<int> CompleteAsync()
    {
        return await _efCoreContext.SaveChangesAsync();
    }
}