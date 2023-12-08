using BloodDonationManager.Core.Entities;
using BloodDonationManager.Core.Repositories;

namespace BloodDonationManager.Infrastructure.Persistence.Ef.Repositories;

public class DonationRepository : EfRepository<Donation>, IDonationRepository
{
    public DonationRepository(EfDbContext efDbContext) : base(efDbContext)
    {
    }
}