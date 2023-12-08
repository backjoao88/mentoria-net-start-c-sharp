using BloodDonationManager.Core.Entities;
using BloodDonationManager.Core.Repositories;

namespace BloodDonationManager.Infrastructure.Persistence.Ef.Repositories;

public class DonorRepository : EfRepository<Donor>, IDonorRepository
{
    public DonorRepository(EfDbContext efDbContext) : base(efDbContext)
    {
    }
}