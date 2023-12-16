namespace BloodManager.Core.Entities;

public class Donation : BaseEntity
{
    public Donation()
    {
    }

    public Donation(Guid id) : base(id)
    {
    }

    public Donation(Guid idDonor, DateTime donationDate, int quantityMl)
    {
        IdDonor = idDonor;
        DonationDate = donationDate;
        QuantityMl = quantityMl;
    }
    
    public Guid? IdDonor { get; private set; }
    public Donor? Donor { get; private set; }
    public DateTime DonationDate { get; private set; }
    public int QuantityMl { get; private set; }
    
}