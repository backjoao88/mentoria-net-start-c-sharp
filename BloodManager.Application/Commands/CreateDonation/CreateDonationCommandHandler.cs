using BloodManager.Abstractions.Mediator;
using BloodManager.Application.ViewModels;
using BloodManager.Core;
using BloodManager.Core.Entities;

namespace BloodManager.Application.Commands.CreateDonation;

public class CreateDonationCommandHandler : IBkRequestHandler<CreateDonationCommand, DonationDetailedViewModel>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateDonationCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public async Task<DonationDetailedViewModel> HandleAsync(CreateDonationCommand request)
    {
        var donation = new Donation(request.IdDonor, DateTime.Now, request.QuantityMl);
        await _unitOfWork.DonationRepository.SaveAsync(donation);
        await _unitOfWork.CompleteAsync();
        var donationDetailedViewModel =
            new DonationDetailedViewModel(donation.Id, donation.IdDonor, donation.DonationDate, donation.QuantityMl);
        return donationDetailedViewModel;
    }
}