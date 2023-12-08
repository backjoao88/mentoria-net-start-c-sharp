using DevFreela.Application.ViewModels;
using MediatR;

namespace DevFreela.Application.Queries.GetAllCustomers;

public class GetAllCustomersQuery : IRequest<List<CustomerViewModel>>
{
    public GetAllCustomersQuery(string query)
    {
        Query = query;
    }

    public string Query { get; set; }
}