using MediatR;

namespace DevFreela.Application.Commands.UpdateCustomer;

public class UpdateCustomerCommand : IRequest<Unit>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; } 
}