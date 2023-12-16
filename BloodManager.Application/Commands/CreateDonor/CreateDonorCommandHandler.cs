using BloodManager.Abstractions.Mediator;
using BloodManager.Application.ViewModels;
using BloodManager.Core;
using BloodManager.Core.Entities;

namespace BloodManager.Application.Commands.CreateDonor;

public class CreateDonorCommandHandler : IBkRequestHandler<CreateDonorCommand, DonorViewModel>
{
    public CreateDonorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    private readonly IUnitOfWork _unitOfWork;

    public async Task<DonorViewModel> HandleAsync(CreateDonorCommand request)
    {
        var donor = new Donor(request.FirstName, request.LastName, request.Email, request.Birth,
            request.Weight, request.Genre, request.BloodType, request.RhFactorType, request.Address);
        await _unitOfWork.DonorRepository.SaveAsync(donor);
        await _unitOfWork.CompleteAsync();
        var donorViewModel = new DonorViewModel(donor.Id);
        return donorViewModel;
    }
}