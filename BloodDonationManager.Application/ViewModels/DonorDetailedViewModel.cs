using BloodDonationManager.Core.Entities;
using BloodDonationManager.Core.Enums;

namespace BloodDonationManager.Application.ViewModels;

public class DonorDetailedViewModel
{
    public DonorDetailedViewModel(int id,string firstName, string lastName, string email, DateTime birth, int weight, GenreType genre, BloodType bloodType, RhFactorType fatorRhType, Address address)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Birth = birth;
        Genre = genre;
        Weight = weight;
        BloodType = bloodType;
        FatorRhType = fatorRhType;
        Address = address;
    }
    
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public DateTime Birth { get; set; }
    public GenreType Genre { get; set; }
    public int Weight { get; set; }
    public BloodType BloodType { get; set; }
    public RhFactorType FatorRhType { get; set; }
    public Address Address { get; set; }
}