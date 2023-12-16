using BloodManager.Core.Enums;
using BloodManager.Core.ValueObjects;

namespace BloodManager.Application.ViewModels;

public class DonorDetailedViewModel
{
    public DonorDetailedViewModel(Guid id, string firstName, string lastName, string email, DateTime birth, int weight,
        GenreType genreType, BloodType bloodType, RhFactorType rhFactorType, Address address)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Birth = birth;
        Weight = weight;
        GenreType = genreType;
        BloodType = bloodType;
        RhFactorType = rhFactorType;
        Address = address;
    }

    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime Birth { get; set; }
    public int Weight { get; set; }
    public GenreType GenreType { get; set; }
    public BloodType BloodType { get; set; }
    public RhFactorType RhFactorType { get; set; }
    public Address Address { get; set; }
}