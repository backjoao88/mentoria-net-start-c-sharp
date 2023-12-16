using BloodManager.Core.Entities;
using BloodManager.Core.Repositories;

namespace BloodManager.Infrastructure.Persistence.EfCore.Repositories;

public class DonationRepository : EfCoreRepository<Donation>, IDonationRepository
{
    public DonationRepository(EfCoreContext efCoreContext) : base(efCoreContext)
    {
    }
}