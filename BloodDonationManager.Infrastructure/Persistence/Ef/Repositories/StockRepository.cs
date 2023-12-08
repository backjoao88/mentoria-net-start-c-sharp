using BloodDonationManager.Core.Entities;
using BloodDonationManager.Core.Repositories;

namespace BloodDonationManager.Infrastructure.Persistence.Ef.Repositories;

public class StockRepository : EfRepository<Stock>, IStockRepository
{
    public StockRepository(EfDbContext efDbContext) : base(efDbContext)
    {
    }
}