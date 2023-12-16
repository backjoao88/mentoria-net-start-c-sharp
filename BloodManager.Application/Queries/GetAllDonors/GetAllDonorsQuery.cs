using BloodManager.Abstractions.Mediator;
using BloodManager.Application.ViewModels;

namespace BloodManager.Application.Queries.GetAllDonors;

public class GetAllDonorsQuery : IBkRequest<List<DonorDetailedViewModel>>;