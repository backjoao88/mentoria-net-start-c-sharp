namespace BloodManager.Application.ViewModels;

public class DonationDetailedViewModel
{
    public DonationDetailedViewModel(Guid id, Guid? idDonor, DateTime donationDate, int quantityMl)
    {
        Id = id;
        IdDonor = idDonor;
        DonationDate = donationDate;
        QuantityMl = quantityMl;
    }

    public Guid Id { get; set; }
    public Guid? IdDonor { get; set; }
    public DateTime DonationDate { get; set; }
    public int QuantityMl { get; set; }
}