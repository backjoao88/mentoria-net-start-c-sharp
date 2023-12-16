using System.Reflection;
using BloodManager.Abstractions.Mediator;
using Microsoft.Extensions.DependencyInjection;
namespace BloodManager.Abstractions;

public static class DependencyInjection
{
    public static IServiceCollection AddBkMediator(this IServiceCollection services, Assembly assembly)
    {
        services.AddTransient<IBkMediator, BkMediator>();
        var handlers = assembly.GetTypes().Where(o => o.Name.EndsWith("Handler"));
        foreach (var handler in handlers)
        {
            var interfaceType = handler.GetInterfaces().FirstOrDefault();
            if (interfaceType != null) services.AddScoped(interfaceType, handler);
        }
        return services;
    }  
}