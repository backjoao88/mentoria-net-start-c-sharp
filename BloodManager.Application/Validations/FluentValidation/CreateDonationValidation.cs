using BloodManager.Application.Commands.CreateDonation;
using BloodManager.Core.Entities;
using BloodManager.Core.Repositories;
using BloodManager.Core.Validations;
using FluentValidation;

namespace BloodManager.Application.Validations.FluentValidation;

public class CreateDonationValidation : AbstractValidator<CreateDonationCommand>, IValidation<CreateDonationCommand>
{
    private readonly IDonorRepository _donorRepository;
    
    public CreateDonationValidation(IDonorRepository donorRepository)
    {
        _donorRepository = donorRepository;
        RuleFor(o => o.QuantityMl).NotEmpty();
        RuleFor(o => o.IdDonor).Must(DonorExistsOnDatabase).WithMessage("This donor doesn't exist.");
        RuleFor(o => o.IdDonor).Must(BeValidDonor).WithMessage("This donor is unable to donate.");
    }
    
    private bool BeValidDonor(Guid id)
    {
        var donorId = new Donor(id);
        var donor = _donorRepository.FindById(donorId);
        if (donor is null)
        {
            return false;
        }
        return donor.CanDonate();
    }

    private bool DonorExistsOnDatabase(Guid id)
    {
        var donorId = new Donor(id);
        var donor = _donorRepository.FindById(donorId);
        return !(donor is null);
    }

    public async Task<ValidationResult> IsValidAsync(CreateDonationCommand data)
    {
        var validationResult = await ValidateAsync(data);
        if (!validationResult.IsValid)
        {
            return new ValidationResult(false, string.Join("; ", validationResult.Errors.ToList()));
        }
        return new ValidationResult(true, "");
    }
}