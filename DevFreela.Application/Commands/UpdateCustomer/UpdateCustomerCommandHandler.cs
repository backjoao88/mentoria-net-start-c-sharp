using DevFreela.Core;
using DevFreela.Core.Entities;
using MediatR;

namespace DevFreela.Application.Commands.UpdateCustomer;

public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Unit>
{
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCustomerCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = _unitOfWork.CustomerRepository.FindById(request.Id);
        customer.Update(
            request.FirstName.Any() ? request.FirstName : customer.FirstName,
            request.LastName.Any() ? request.LastName : customer.LastName,
            request.Email.Any() ? request.Email : customer.Email
        );
        await _unitOfWork.CompleteAsync();
        return await Task.FromResult(Unit.Value);
    }
}