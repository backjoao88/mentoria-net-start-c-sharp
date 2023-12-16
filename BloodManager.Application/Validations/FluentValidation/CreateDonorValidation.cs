using BloodManager.Application.Commands.CreateDonor;
using BloodManager.Core.Repositories;
using BloodManager.Core.Validations;
using FluentValidation;

namespace BloodManager.Application.Validations.FluentValidation;

public class CreateDonorValidation : AbstractValidator<CreateDonorCommand>, IValidation<CreateDonorCommand>
{
    
    private readonly IDonorRepository _donorRepository;

    public CreateDonorValidation(IDonorRepository donorRepository)
    {
        _donorRepository = donorRepository;
        RuleFor(o => o.FirstName).NotEmpty();
        RuleFor(o => o.LastName).NotEmpty();
        RuleFor(o => o.Email).NotEmpty();
        RuleFor(o => o.Email).Must(BeUniqueEmail).WithMessage("This e-mail is already been used.");
    }

    private bool BeUniqueEmail(string email)
    {
        var donors = _donorRepository.Find(o => o.Email == email);
        return donors.Count == 0;
    }

    public async Task<ValidationResult> IsValidAsync(CreateDonorCommand data)
    {
        var validationResult = await ValidateAsync(data);
        if (!validationResult.IsValid)
        {
            return new ValidationResult(false, string.Join("; ", validationResult.Errors.ToList()));
        }
        return new ValidationResult(true, "");
    }
}