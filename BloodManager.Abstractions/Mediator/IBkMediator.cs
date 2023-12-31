namespace BloodManager.Abstractions.Mediator;

public interface IBkMediator
{
    public Task SendAsync<TRequest>(TRequest request) where TRequest : IBkRequest;
    public Task<TResponse> SendAsync<TRequest, TResponse>(TRequest request) where TRequest : IBkRequest<TResponse>;
}

