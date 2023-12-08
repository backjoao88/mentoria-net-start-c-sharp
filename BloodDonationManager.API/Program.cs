using BloodDonationManager.Application;
using BloodDonationManager.Infrastructure;
using BloodDonationManager.Infrastructure.Persistence.Ef;
using Microsoft.OpenApi.Models;

namespace BloodDonationManager.API;

public abstract class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddApplication();
        builder.Services.AddPersistence();
        builder.Services.AddSwaggerGen(o =>
        {
            o.SwaggerDoc("v1", new OpenApiInfo()
            {
                Contact = new OpenApiContact()
                {
                    Name = "João Paulo Back"
                }
            });
            var xmlFile = "BloodDonationManager.API.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            o.IncludeXmlComments(xmlPath);
        });
        var app = builder.Build();
        app.MapControllers();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.Run();
    }
}