using System.Threading.Tasks;

namespace BloodManager.Abstractions.Mediator;

public interface IBkRequestHandler<TRequest, TResponse> where TRequest : IBkRequest<TResponse>
{
    public Task<TResponse> HandleAsync(TRequest request);
}

public interface IBkRequestHandler<TRequest> where TRequest : IBkRequest
{
    public Task HandleAsync(TRequest request);
}