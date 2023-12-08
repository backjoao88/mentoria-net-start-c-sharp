using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.Application.Commands.CreateCustomer;

public class CreateCustomerCommand : IRequest<CustomerViewModel>
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
}