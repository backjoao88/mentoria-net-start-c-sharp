using BloodManager.Abstractions.Mediator;
using BloodManager.Application.ViewModels;
using BloodManager.Core;

namespace BloodManager.Application.Queries.GetAllDonations;

public class GetAllDonationsQueryHandler : IBkRequestHandler<GetAllDonationsQuery, List<DonationDetailedViewModel>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAllDonationsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<List<DonationDetailedViewModel>> HandleAsync(GetAllDonationsQuery request)
    {
        var donations = await _unitOfWork.DonationRepository.FindAllAsync();
        var donationsViewModel =
            donations.Select(o => new DonationDetailedViewModel(o.Id, o.IdDonor, o.DonationDate, o.QuantityMl))
                .ToList();
        return donationsViewModel;
    }
}