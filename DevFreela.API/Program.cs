using DevFreela.Application.Commands.CreateCustomer;
using DevFreela.Infrastructure;
using Microsoft.OpenApi.Models;

namespace DevFreela.API;

public abstract class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddInfrastructure();
        builder.Services.AddMediatR(o => o.RegisterServicesFromAssemblies(typeof(CreateCustomerCommand).Assembly));
        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo()
            {
                Contact = new OpenApiContact()
                {
                    Name = "João Paulo Back"
                }
            });
            var xmlFile = Path.Combine(AppContext.BaseDirectory, "DevFreela.API.xml");
            options.IncludeXmlComments(xmlFile);
        });
        var app = builder.Build();
        app.MapControllers();
        app.UseSwagger();
        app.UseSwaggerUI();
        app.Run();
    }
}