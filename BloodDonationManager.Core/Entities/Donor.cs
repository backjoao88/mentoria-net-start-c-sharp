using BloodDonationManager.Core.Entities.Interfaces;
using BloodDonationManager.Core.Enums;

namespace BloodDonationManager.Core.Entities;

public class Donor : IIdentificable, IDeletable
{
    public Donor()
    {
    }

    public Donor(string firstName, string lastName, string email, DateTime birth, int weight, GenreType genre, BloodType bloodType, RhFactorType rhFactorType, Address address)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Birth = birth;
        Genre = genre;
        Weight = weight;
        BloodType = bloodType;
        RhFactorType = rhFactorType;
        Address = address;
    }

    public int Id { get; private set; }
    public Address Address { get; private set; } = null!;
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public DateTime Birth { get; private set; }
    public GenreType Genre { get; private set; }
    public int Weight { get; private set; }
    public BloodType BloodType { get; private set; }
    public RhFactorType RhFactorType { get; private set; }
    public bool IsDeleted { get; private set; }

    public void Delete()
    {
        IsDeleted = true;
    }
}