using BloodManager.Abstractions.Mediator;
using BloodManager.Application.ViewModels;

namespace BloodManager.Application.Queries.GetDonorById;

public class GetDonorByIdQuery : IBkRequest<DonorDetailedViewModel?>
{
    public GetDonorByIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}