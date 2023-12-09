using BloodDonationManager.Application.ViewModels;
using BloodDonationManager.Core;
using MediatR;

namespace BloodDonationManager.Application.Queries.GetDonorById;

public class GetDonorByIdQueryHandler : IRequestHandler<GetDonorById.GetDonorByIdQuery, DonorDetailedViewModel>
{

    private readonly IUnitOfWork _unitOfWork;

    public GetDonorByIdQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }


    public async Task<DonorDetailedViewModel> Handle(GetDonorByIdQuery request, CancellationToken cancellationToken)
    {
        var donor = await _unitOfWork.DonorRepository.FindByIdAsync(request.Id);
        if (donor is null) return null;
        var donorViewModel = new DonorDetailedViewModel(
            donor.Id,
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