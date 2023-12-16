using BloodManager.Abstractions.Mediator;
using BloodManager.Application.ViewModels;
using BloodManager.Core;
using BloodManager.Core.Entities;

namespace BloodManager.Application.Queries.GetDonorById;

public class GetDonorByIdQueryHandler : IBkRequestHandler<GetDonorByIdQuery, DonorDetailedViewModel?>
{
    public GetDonorByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    private readonly IUnitOfWork _unitOfWork;

    public async Task<DonorDetailedViewModel?> HandleAsync(GetDonorByIdQuery request)
    {
        var donorId = new Donor(request.Id);
        var donor = await _unitOfWork.DonorRepository.FindByIdAsync(donorId);
        if (donor is null)
        {
            return null;
        }
        var donorViewModel = new DonorDetailedViewModel(donor.Id, donor.FirstName, donor.LastName, donor.Email, donor.Birth, donor.Weight, donor.Genre, donor.BloodType, donor.RhFactorType, donor.Address);
        return donorViewModel;
    }
}