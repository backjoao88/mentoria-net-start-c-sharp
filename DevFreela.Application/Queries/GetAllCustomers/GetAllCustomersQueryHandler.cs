using DevFreela.Application.ViewModels;
using DevFreela.Core;
using MediatR;

namespace DevFreela.Application.Queries.GetAllCustomers;

public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, List<CustomerViewModel>>
{

    private readonly IUnitOfWork _unitOfWork;

    public GetAllCustomersQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<CustomerViewModel>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
    {
        var customers = await _unitOfWork.CustomerRepository.FindAllAsync();
        var customersViewModel = customers.Select(o => new CustomerViewModel(o.Id, o.FirstName, o.LastName, o.Email))
            .ToList();
        return customersViewModel;
    }
}