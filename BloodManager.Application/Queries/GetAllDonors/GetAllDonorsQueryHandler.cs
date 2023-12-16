using BloodManager.Abstractions.Mediator;
using BloodManager.Application.ViewModels;
using BloodManager.Core;

namespace BloodManager.Application.Queries.GetAllDonors;

public class GetAllDonorsQueryHandler : IBkRequestHandler<GetAllDonorsQuery, List<DonorDetailedViewModel>>
{
    public GetAllDonorsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    private readonly IUnitOfWork _unitOfWork;

    public async Task<List<DonorDetailedViewModel>> HandleAsync(GetAllDonorsQuery request)
    {
        var donors = await _unitOfWork.DonorRepository.FindAllAsync();
        var donorsViewModel = donors.Select(o => new DonorDetailedViewModel(o.Id, o.FirstName, o.LastName, o.Email, o.Birth, o.Weight, o.Genre, o.BloodType, o.RhFactorType, o.Address)).ToList();
        return donorsViewModel;
    }
}