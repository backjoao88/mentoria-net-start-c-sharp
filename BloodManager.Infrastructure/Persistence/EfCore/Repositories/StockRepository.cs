using BloodManager.Core.Entities;
using BloodManager.Core.Repositories;

namespace BloodManager.Infrastructure.Persistence.EfCore.Repositories;

public class StockRepository : EfCoreRepository<Stock>, IStockRepository
{
    public StockRepository(EfCoreContext efCoreContext) : base(efCoreContext)
    {
    }
}