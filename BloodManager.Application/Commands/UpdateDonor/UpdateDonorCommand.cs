using BloodManager.Abstractions.Mediator;
using BloodManager.Application.ViewModels;

namespace BloodManager.Application.Commands.UpdateDonor;

public class UpdateDonorCommand : IBkRequest
{
    public UpdateDonorCommand(Guid id, string firstName)
    {
        Id = id;
        FirstName = firstName;
    }

    public Guid Id { get; set; }
    public string FirstName { get; set; }
}