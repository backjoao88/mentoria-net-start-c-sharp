using BloodManager.Abstractions.Mediator;
using BloodManager.Application.ViewModels;
using BloodManager.Core.Enums;
using BloodManager.Core.ValueObjects;

namespace BloodManager.Application.Commands.CreateDonor;

public class CreateDonorCommand : IBkRequest<DonorViewModel>
{
    public CreateDonorCommand(string firstName, string lastName, string email, DateTime birth, int weight, GenreType genre, BloodType bloodType, RhFactorType rhFactorType, Address address)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Birth = birth;
        Weight = weight;
        Genre = genre;
        BloodType = bloodType;
        RhFactorType = rhFactorType;
        Address = address;
    }

    public string FirstName { get; set; } 
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime Birth { get; set; }
    public int Weight { get; set; }
    public GenreType Genre { get; set; }
    public BloodType BloodType { get; set; }
    public RhFactorType RhFactorType { get; set; }
    public Address Address { get; set; }
}