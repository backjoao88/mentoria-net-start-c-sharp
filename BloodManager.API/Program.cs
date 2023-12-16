using BloodManager.Abstractions;
using BloodManager.Application;
using BloodManager.Application.Commands.CreateDonor;
using BloodManager.Infrastructure;

namespace BloodManager.API;

public abstract class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddBkMediator(typeof(CreateDonorCommand).Assembly);
        builder.Services.AddPersistence();
        builder.Services.AddValidators();
        builder.Services.AddControllers();
        var app = builder.Build();
        app.MapControllers();
        app.Run();
    }
}