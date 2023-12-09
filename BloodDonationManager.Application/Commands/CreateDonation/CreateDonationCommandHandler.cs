using BloodDonationManager.Application.ViewModels;
using BloodDonationManager.Core;
using BloodDonationManager.Core.Entities;
using MediatR;

namespace BloodDonationManager.Application.Commands.CreateDonation;

public class CreateDonationCommandHandler : IRequestHandler<CreateDonationCommand, DonationDetailedViewModel>
{
    
    public CreateDonationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    private readonly IUnitOfWork _unitOfWork;

    
    public async Task<DonationDetailedViewModel> Handle(CreateDonationCommand request, CancellationToken cancellationToken)
    {

        var donor = await _unitOfWork.DonorRepository.FindByIdAsync(request.IdDonor);
        if (donor is null)
        {
            return null;
        }
        
        var donation = new Donation(request.IdDonor, request.DonationDate, request.QuantityMl);
        await _unitOfWork.DonationRepository.SaveAsync(donation);
        await _unitOfWork.CompleteAsync();

        var donorViewModel = new DonorDetailedViewModel(donation.Donor.Id, donation.Donor.FirstName,
            donation.Donor.LastName, donation.Donor.Email, donation.Donor.Birth, donation.Donor.Weight,
            donation.Donor.Genre, donation.Donor.BloodType, donation.Donor.RhFactorType, donation.Donor.Address
        );
        var donationViewModel = new DonationDetailedViewModel(donation.Id, donation.IdDonor, donorViewModel, donation.DonationDate,
            donation.QuantityMlDonated);
        return donationViewModel;
    }
}