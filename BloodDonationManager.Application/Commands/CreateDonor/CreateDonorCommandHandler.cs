using BloodDonationManager.Application.ViewModels;
using BloodDonationManager.Core;
using BloodDonationManager.Core.Entities;
using MediatR;

namespace BloodDonationManager.Application.Commands.CreateDonor;

public class CreateDonorCommandHandler : IRequestHandler<CreateDonorCommand, DonorDetailedViewModel>
{
    public CreateDonorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    private readonly IUnitOfWork _unitOfWork;
    
    public async Task<DonorDetailedViewModel> Handle(CreateDonorCommand request, CancellationToken cancellationToken)
    {
        var donor = new Donor(
            request.FirstName, 
            request.LastName, 
            request.Email, 
            request.Birth,
            request.Weight, 
            request.Genre, 
            request.BloodType, 
            request.RhFactorType, 
            request.Address
        );
        await _unitOfWork.DonorRepository.SaveAsync(donor);
        await _unitOfWork.CompleteAsync();
        var donorViewModel = new DonorDetailedViewModel(
            donor.FirstName, 
            donor.LastName,
            donor.Email,
            donor.Birth,
            donor.Weight,
            donor.Genre,
            donor.BloodType,
            donor.RhFactorType,
            donor.Address
        );
        return donorViewModel;
    }
}