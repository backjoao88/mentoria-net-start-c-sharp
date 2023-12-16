using BloodManager.Core.Entities;

namespace BloodManager.Core.Repositories;

public interface IDonorRepository : IRepository<Donor>
{
    public Donation? GetLastDonation(Donor donor);
    public Task<Donation?> GetLastDonationAsync(Donor donor);
}