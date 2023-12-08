using BloodDonationManager.Application.ViewModels;
using BloodDonationManager.Core.Entities;
using BloodDonationManager.Core.Enums;
using MediatR;

namespace BloodDonationManager.Application.Commands.CreateDonor;

public class CreateDonorCommand : IRequest<DonorDetailedViewModel>
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public DateTime Birth { get; set; }
    public GenreType Genre { get; set; }
    public int Weight { get; set; } = 0;
    public BloodType BloodType { get; set; }
    public RhFactorType RhFactorType { get; set; }
    public Address Address { get; set; } = null!;
}