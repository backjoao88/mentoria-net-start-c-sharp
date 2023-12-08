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
        builder.OwnsOne(o => o.Address).WithOwner().HasForeignKey(o => o.IdDonor);
        builder.OwnsOne(o => o.Address)
            .Property(o => o.Street)
            .IsRequired();
        builder.OwnsOne(o => o.Address)
            .Property(o => o.City)
            .IsRequired();
        builder.OwnsOne(o => o.Address)
            .Property(o => o.Cep)
            .IsRequired();
        builder.OwnsOne(o => o.Address)
            .Property(o => o.State)
            .IsRequired();
        
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
        var fakeDonor = fakerDonor.Generate(1);
        builder.HasData(fakeDonor);
        // var fakerAddress = new Faker<Address>("pt_BR")
        //     .RuleFor(o => o.IdDonor, 1)
        //     .RuleFor(o => o.Street, f => f.Address.StreetAddress())
        //     .RuleFor(o => o.City, f => f.Address.City())
        //     .RuleFor(o => o.Cep, f => f.Address.ZipCode())
        //     .RuleFor(o => o.State, f => f.Address.State());
        // var fakeAddresses = fakerAddress.Generate(1);
        //
        //
    }
}