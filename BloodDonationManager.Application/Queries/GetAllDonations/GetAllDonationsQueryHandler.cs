using BloodDonationManager.Application.ViewModels;
using BloodDonationManager.Core;
using MediatR;

namespace BloodDonationManager.Application.Queries.GetAllDonations;

public class GetAllDonationsQueryHandler : IRequestHandler<GetAllDonationsQuery, List<DonationDetailedViewModel>>
{
    public GetAllDonationsQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    private readonly IUnitOfWork _unitOfWork;

    public async Task<List<DonationDetailedViewModel>> Handle(GetAllDonationsQuery request,
        CancellationToken cancellationToken)
    {
        var donations = await _unitOfWork.DonationRepository.FindAllAsync();

        var donationsViewModel =
            donations.Select(o => new DonationDetailedViewModel(o.Id, o.IdDonor, new DonorDetailedViewModel(o.Donor.Id,
                    o.Donor.FirstName,
                    o.Donor.LastName, o.Donor.Email, o.Donor.Birth, o.Donor.Weight,
                    o.Donor.Genre, o.Donor.BloodType, o.Donor.RhFactorType, o.Donor.Address
                ), o.DonationDate, o.QuantityMlDonated))
                .ToList();
        return donationsViewModel;
    }
}