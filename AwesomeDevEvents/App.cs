using System;
using AwesomeDevEvents.Models;
using AwesomeDevEvents.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
namespace AwesomeDevEvents;

public abstract class App
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddSingleton<DevEventsDbContext>();
        builder.Services.AddControllers();
        var app = builder.Build();
        app.MapControllers();
        var dbContext = (DevEventsDbContext)app.Services.GetService(typeof(DevEventsDbContext)) ?? new DevEventsDbContext();
        dbContext.DevEvents.Add(new DevEvents(Guid.NewGuid(), "Sérgio Sacani", "Astronomia na atualidade",
            $"Na verdade ele irá fazer um treino de perna com a galera"));
        dbContext.DevEvents.Add(new DevEvents(Guid.NewGuid(), "Eslen Delanogate", "Psicologia comportamental",
            $"Efeitos da psicologia comportamental"));
        dbContext.SaveChanges();
        app.Run();
    }
}