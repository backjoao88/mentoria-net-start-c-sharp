using Microsoft.Extensions.DependencyInjection;

namespace BloodManager.Abstractions.Mediator;

public class BkMediator : IBkMediator
{
    public BkMediator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    private readonly IServiceProvider _serviceProvider;
    
    public async Task SendAsync<TRequest>(TRequest request) where TRequest : IBkRequest
    {
        var handler = (IBkRequestHandler<TRequest>) _serviceProvider.GetRequiredService(typeof(IBkRequestHandler<TRequest>));
        await handler.HandleAsync(request);
    }

    public async Task<TResponse> SendAsync<TRequest, TResponse>(TRequest request) where TRequest : IBkRequest<TResponse>
    {
        var handler = (IBkRequestHandler<TRequest, TResponse>) _serviceProvider.GetRequiredService(typeof(IBkRequestHandler<TRequest, TResponse>));
        return await handler.HandleAsync(request);
    }
}