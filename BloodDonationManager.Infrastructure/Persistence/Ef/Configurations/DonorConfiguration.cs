using BloodDonationManager.Core.Entities;
using BloodDonationManager.Core.Enums;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BloodDonationManager.Infrastructure.Persistence.Ef.Configurations;

public class DonorConfiguration : IEntityTypeConfiguration<Donor>
{
    public void Configure(EntityTypeBuilder<Donor> builder)
    {
        builder.HasKey(o => o.Id);
        
        // key navigation
        builder.OwnsOne(o => o.Address).WithOwner().HasForeignKey(o => o.IdDonor);

        int id = 0;
        
        // Fake data for donors
        var fakerDonor = new Faker<Donor>("pt_BR")
            .RuleFor(o => o.Id, f => ++id)
            .RuleFor(o => o.Email, f => f.Person.Email)
            .RuleFor(o => o.Birth, f => f.Person.DateOfBirth)
            .RuleFor(o => o.BloodType,
                f => f.PickRandom<BloodType>(BloodType.A, BloodType.Ab, BloodType.B, BloodType.O))
            .RuleFor(o => o.RhFactorType, f => f.PickRandom<RhFactorType>(RhFactorType.Negative, RhFactorType.Positive))
            .RuleFor(o => o.Genre, f => f.PickRandom<GenreType>(GenreType.MALE, GenreType.FEMALE))
            .RuleFor(o => o.Weight, f => f.PickRandom<int>(45, 60, 67, 90, 80, 102, 49, 56))
            .RuleFor(o => o.FirstName, f => f.Person.FirstName)
            .RuleFor(o => o.LastName, f => f.Person.LastName);
                
        var fakeDonor = fakerDonor.Generate(15);
        builder.HasData(fakeDonor);

        // Fake data for addresses

        foreach (var donor in fakeDonor)
        {
            var fakeAddress = new Faker<Address>("pt_BR")
                .RuleFor(o => o.IdDonor, f => donor.Id)
                .RuleFor(o => o.City, f => f.Person.Address.City)
                .RuleFor(o => o.Cep, f => f.Person.Address.ZipCode)
                .RuleFor(o => o.Street, f => f.Person.Address.Street)
                .RuleFor(o => o.State, f => f.Person.Address.State)
                .Generate(1);
            builder.OwnsOne(o => o.Address).HasData(fakeAddress);
        }
        
    }
}