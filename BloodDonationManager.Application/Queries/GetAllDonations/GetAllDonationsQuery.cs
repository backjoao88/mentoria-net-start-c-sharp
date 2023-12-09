using BloodDonationManager.Application.ViewModels;
using MediatR;

namespace BloodDonationManager.Application.Queries.GetAllDonations;

public class GetAllDonationsQuery : IRequest<List<DonationDetailedViewModel>>
{
    public GetAllDonationsQuery(string query)
    {
        Query = query;
    }
    
    public string Query { get; set; }
}