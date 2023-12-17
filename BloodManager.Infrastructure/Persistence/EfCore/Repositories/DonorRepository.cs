using BloodManager.Core.Entities;
using BloodManager.Core.Repositories;

namespace BloodManager.Infrastructure.Persistence.EfCore.Repositories;

public class DonorRepository : EfCoreRepository<Donor>, IDonorRepository
{
    public DonorRepository(EfCoreContext efCoreContext) : base(efCoreContext)
    {
    }


    public Donation? GetLastDonation(Donor donor)
    {
        var donations = donor.Donations;
        if (donations == null)
        {
            return null;
        }
        var lastDonation = donations.MaxBy(o => o.DonationDate);
        return lastDonation;
    }

    public Task<Donation?> GetLastDonationAsync(Donor donor)
    {
        throw new NotImplementedException();
    }
}