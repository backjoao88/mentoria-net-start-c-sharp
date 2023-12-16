using BloodManager.Core;
using BloodManager.Core.Repositories;
using BloodManager.Infrastructure.Persistence.EfCore;
using BloodManager.Infrastructure.Persistence.EfCore.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace BloodManager.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddDbContext<EfCoreContext>();
        services.AddScoped<IDonorRepository, DonorRepository>();
        services.AddScoped<IDonationRepository, DonationRepository>();
        services.AddScoped<IStockRepository, StockRepository>();
        services.AddScoped<IUnitOfWork, EfCoreUnitOfWork>();
        return services;
    }
}