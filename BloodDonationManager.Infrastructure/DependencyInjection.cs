using BloodDonationManager.Core;
using BloodDonationManager.Core.Repositories;
using BloodDonationManager.Infrastructure.Persistence.Ef;
using BloodDonationManager.Infrastructure.Persistence.Ef.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BloodDonationManager.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<EfDbContext>();
        services.AddScoped<IUnitOfWork, EfUnitOfWork>();
        services.AddScoped<IDonorRepository, DonorRepository>();
        services.AddScoped<IDonationRepository, DonationRepository>();
        services.AddScoped<IStockRepository, StockRepository>();
        return services;
    }
}