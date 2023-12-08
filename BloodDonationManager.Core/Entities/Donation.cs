using BloodDonationManager.Core.Entities.Interfaces;

namespace BloodDonationManager.Core.Entities;

public class Donation : IIdentificable, IDeletable
{
    public Donation(int id, int idDonor, DateTime donationDate, int quantityMlDonated)
    {
        Id = id;
        IdDonor = idDonor;
        DonationDate = donationDate;
        QuantityMlDonated = quantityMlDonated;
    }
    public int Id { get; private set; }
    public int IdDonor { get; private set; }
    public Donor Donor { get; private set; } = null!;
    public DateTime DonationDate { get; private set; }
    public int QuantityMlDonated { get; private set; }
    
    public bool IsDeleted { get; private set; }
    public void Delete()
    {
        IsDeleted = true;
    }
}