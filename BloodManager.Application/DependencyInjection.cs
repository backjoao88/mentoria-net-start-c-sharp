using BloodManager.Application.Commands.CreateDonation;
using BloodManager.Application.Commands.CreateDonor;
using BloodManager.Application.Validations.FluentValidation;
using BloodManager.Core.Entities;
using BloodManager.Core.Validations;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace BloodManager.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(typeof(CreateDonorValidation).Assembly);
        services.AddScoped<IValidation<CreateDonorCommand>, CreateDonorValidation>();
        services.AddScoped<IValidation<CreateDonationCommand>, CreateDonationValidation>();
        return services;
    }
}