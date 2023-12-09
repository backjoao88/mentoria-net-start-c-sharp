using BloodDonationManager.Core.Entities;
using BloodDonationManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationManager.Infrastructure.Persistence.Ef.Repositories;

public class DonationRepository : EfRepository<Donation>, IDonationRepository
{
    public DonationRepository(EfDbContext efDbContext) : base(efDbContext)
    {
    }

    public new async Task<List<Donation>> FindAllAsync()
    {
        var donations = await EfDbContext.Donations.Include(o => o.Donor).ToListAsync();
        return donations;
    }
    
}