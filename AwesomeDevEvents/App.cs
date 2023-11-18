using System;
using AwesomeDevEvents.Core;
using AwesomeDevEvents.Core.Models;
using AwesomeDevEvents.Core.Repositories;
using AwesomeDevEvents.Persistence;
using AwesomeDevEvents.Persistence.Ef;
using AwesomeDevEvents.Persistence.Ef.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace AwesomeDevEvents;

public abstract class App
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var connectionString = builder.Configuration.GetConnectionString("DevEventsCs");
        builder.Services.AddDbContext<DevEventsDbContext>(o => o.UseSqlServer(connectionString));
        builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
        builder.Services.AddTransient<IDevEventRepository, DevEventRepository>();
        builder.Services.AddControllers();
        var app = builder.Build();
        app.MapControllers();
        app.Run();
    }
}