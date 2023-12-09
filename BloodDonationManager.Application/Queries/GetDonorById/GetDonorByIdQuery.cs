using BloodDonationManager.Application.ViewModels;
using MediatR;

namespace BloodDonationManager.Application.Queries.GetDonorById;

public class GetDonorByIdQuery : IRequest<DonorDetailedViewModel>
{
    public GetDonorByIdQuery(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
}