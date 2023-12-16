using BloodManager.Abstractions.Mediator;
using BloodManager.Application.ViewModels;

namespace BloodManager.Application.Commands.CreateDonation;

public class CreateDonationCommand : IBkRequest<DonationDetailedViewModel>
{
    public CreateDonationCommand(Guid idDonor, int quantityMl)
    {
        IdDonor = idDonor;
        QuantityMl = quantityMl;
    }

    public Guid IdDonor { get; set; }
    public int QuantityMl { get; set; }
}