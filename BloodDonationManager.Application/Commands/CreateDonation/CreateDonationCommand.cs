using BloodDonationManager.Application.ViewModels;
using BloodDonationManager.Core.Entities;
using MediatR;

namespace BloodDonationManager.Application.Commands.CreateDonation;

public class CreateDonationCommand : IRequest<DonationDetailedViewModel>
{
    public int IdDonor { get; set; }
    public DateTime DonationDate { get; set; }
    public int QuantityMl { get; set; }
}