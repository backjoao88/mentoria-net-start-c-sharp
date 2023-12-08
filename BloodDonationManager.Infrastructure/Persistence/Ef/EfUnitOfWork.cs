using BloodDonationManager.Core;
using BloodDonationManager.Core.Repositories;

namespace BloodDonationManager.Infrastructure.Persistence.Ef;

public class EfUnitOfWork: IUnitOfWork
{
    public EfUnitOfWork(IDonorRepository donorRepository, IDonationRepository donationRepository, IStockRepository stockRepository, EfDbContext efDbContext)
    {
        DonorRepository = donorRepository;
        DonationRepository = donationRepository;
        StockRepository = stockRepository;
        _efDbContext = efDbContext;
    }

    private readonly EfDbContext _efDbContext;
    public IDonorRepository DonorRepository { get; }
    public IDonationRepository DonationRepository { get; }
    public IStockRepository StockRepository { get; }
    
    public int Complete()
    {
        return _efDbContext.SaveChanges();
    }

    public async Task<int> CompleteAsync()
    {
        return await _efDbContext.SaveChangesAsync();
    }
}