using BloodManager.Abstractions.Mediator;
using BloodManager.Application.ViewModels;
using BloodManager.Core;
using BloodManager.Core.Entities;

namespace BloodManager.Application.Commands.UpdateDonor;

public class UpdateDonorCommandHandler : IBkRequestHandler<UpdateDonorCommand>
{
    
    public UpdateDonorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    private readonly IUnitOfWork _unitOfWork;

    
    public async Task HandleAsync(UpdateDonorCommand request)
    {
        var donorId = new Donor(request.Id);
        var donor = await _unitOfWork.DonorRepository.FindByIdAsync(donorId);
        if (donor is null)
        {
            return;
        }
        donor.Update(request.FirstName);
        await _unitOfWork.CompleteAsync();
    }
}