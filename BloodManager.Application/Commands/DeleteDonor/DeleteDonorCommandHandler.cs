using BloodManager.Abstractions.Mediator;
using BloodManager.Application.ViewModels;
using BloodManager.Core;
using BloodManager.Core.Entities;

namespace BloodManager.Application.Commands.DeleteDonor;

public class DeleteDonorCommandHandler : IBkRequestHandler<DeleteDonorCommand, DonorViewModel?>
{

    private readonly IUnitOfWork _unitOfWork;

    public DeleteDonorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<DonorViewModel?> HandleAsync(DeleteDonorCommand request)
    {
        var donorId = new Donor(request.Id);
        var donor = await _unitOfWork.DonorRepository.RemoveAsync(donorId);
        if (donor is null)
        {
            return null;
        }
        await _unitOfWork.CompleteAsync();
        var donorViewModel = new DonorViewModel(donor.Id);
        return donorViewModel;
    }
}