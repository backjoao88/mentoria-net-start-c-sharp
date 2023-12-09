using BloodDonationManager.Core.Entities;

namespace BloodDonationManager.Application.ViewModels;

public class DonationDetailedViewModel
{
    public DonationDetailedViewModel(int id, int idDonor, DonorDetailedViewModel donor, DateTime donationDate, int quantityMlDonated)
    {
        Id = id;
        IdDonor = idDonor;
        Donor = donor;
        DonationDate = donationDate;
        QuantityMlDonated = quantityMlDonated;
    }

    public int Id { get; set; }
    public int IdDonor { get; set; }
    public DonorDetailedViewModel Donor { get; set; } = null!;
    public DateTime DonationDate { get; set; }
    public int QuantityMlDonated { get; set; }
}