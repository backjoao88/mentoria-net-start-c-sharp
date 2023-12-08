using BloodDonationManager.Application.ViewModels;
using BloodDonationManager.Core;
using MediatR;

namespace BloodDonationManager.Application.Queries.GetAllDonors;

public class GetAllDonorsQueryHandler : IRequestHandler<GetAllDonorsQuery, List<DonorDetailedViewModel>>
{
    public GetAllDonorsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    private readonly IUnitOfWork _unitOfWork;
    
    public async Task<List<DonorDetailedViewModel>> Handle(GetAllDonorsQuery request, CancellationToken cancellationToken)
    {
        var donors = await _unitOfWork.DonorRepository.FindAllAsync();
        var donorsViewModel = donors.Select(d => new DonorDetailedViewModel(
            d.FirstName, 
            d.LastName, 
            d.Email, 
            d.Birth, 
            d.Weight, 
            d.Genre, 
            d.BloodType, 
            d.RhFactorType, 
            d.Address
        )).ToList();
        return donorsViewModel;
    }
}