using DevFreela.Application.ViewModels;
using DevFreela.Core;
using DevFreela.Core.Entities;
using MediatR;

namespace DevFreela.Application.Commands.CreateCustomer;

public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerViewModel>
{

    private readonly IUnitOfWork _unitOfWork;

    public CreateCustomerCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<CustomerViewModel> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = new Customer(Guid.NewGuid(), request.FirstName, request.LastName, request.Email,
            "client");
        _unitOfWork.CustomerRepository.Save(customer);
        _unitOfWork.Complete();
        return new CustomerViewModel(customer.Id, customer.FirstName, customer.LastName, customer.Email);
    }
}