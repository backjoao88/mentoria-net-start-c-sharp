using System.Diagnostics.CodeAnalysis;
using BloodManager.Core.Enums;
using BloodManager.Core.ValueObjects;

namespace BloodManager.Core.Entities;

public class Donor : BaseEntity
{
    public Donor()
    {
    }

    public Donor(Guid id) : base(id) {}
    
    public Donor(string firstName, string lastName, string email, DateTime birth, int weight, GenreType genre,
        BloodType bloodType, RhFactorType rhFactorType, Address address)
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
        Donations = null!;
    }

    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string Email { get; private set; } = null!;
    public DateTime Birth { get; private set; }
    public int Weight { get; private set; }
    public GenreType Genre { get; private set; }
    public BloodType BloodType { get; private set; }
    public RhFactorType RhFactorType { get; private set; }
    public Address Address { get; private set; } = null!;
    public List<Donation>? Donations { get; private set; }
    
    public void Update(string firstName)
    {
        FirstName = firstName;
    }

    public int GetAge()
    {
        return DateTime.Now.Year - Birth.Year - (DateTime.Today > Birth ? 0 : 1);
    }

    public bool IsWoman()
    {
        return Genre == GenreType.FEMALE;
    }

    public bool IsMan()
    {
        return Genre == GenreType.MALE;
    }
    
    public bool CanDonate()
    {
        if (this.Weight < 80)
        {
            return false;
        }

        if (GetAge() < 18)
        {
            return false;
        }
        return true;
    }
    
}