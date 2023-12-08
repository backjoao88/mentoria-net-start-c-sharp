using BloodDonationManager.Application.Queries.GetAllDonors;
using Microsoft.Extensions.DependencyInjection;

namespace BloodDonationManager.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(o => o.RegisterServicesFromAssemblies(typeof(GetAllDonorsQuery).Assembly));
        return services;
    }
}