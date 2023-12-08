using BloodDonationManager.Application.ViewModels;
using MediatR;

namespace BloodDonationManager.Application.Queries.GetAllDonors;

public class GetAllDonorsQuery : IRequest<List<DonorDetailedViewModel>>
{
    public GetAllDonorsQuery(string query)
    {
        Query = query;
    }
    public string Query { get; set; }    
}