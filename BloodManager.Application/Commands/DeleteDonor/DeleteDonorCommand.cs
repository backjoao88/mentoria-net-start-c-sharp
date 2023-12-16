using BloodManager.Abstractions.Mediator;
using BloodManager.Application.ViewModels;

namespace BloodManager.Application.Commands.DeleteDonor;

public class DeleteDonorCommand : IBkRequest<DonorViewModel?>
{
    public DeleteDonorCommand(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
}