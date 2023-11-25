using LibraryManagerApi.Core;
using LibraryManagerApi.Core.Entities;
using LibraryManagerApi.Core.Models.InputModels;
using LibraryManagerApi.Core.Models.ViewModels;
using LibraryManagerApi.Core.Repositories;
using LibraryManagerApi.Core.Validation;
using LibraryManagerApi.Mappers;
using LibraryManagerApi.Persistence.Ef;
using LibraryManagerApi.Persistence.Ef.Repositories;
using LibraryManagerApi.Validations.Fluent;
using Microsoft.OpenApi.Models;

namespace LibraryManagerApi;
public abstract class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        
        // AutoMapper
        builder.Services.AddAutoMapper(typeof(BookProfile).Assembly);
        builder.Services.AddAutoMapper(typeof(UserProfile).Assembly);
        builder.Services.AddAutoMapper(typeof(LoanProfile).Assembly);
        
        // >> DI from EF Core
        builder.Services.AddSingleton<DatabaseContext>();
        builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
        builder.Services.AddScoped<IBookRepository, BookRepository>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<ILoanRepository, LoanRepository>();
        
        // Validations
        builder.Services.AddScoped<IValidation<BookInputModel>, BookValidation>();
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(o =>
        {
            o.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Description = "LibraryManagerApi",
                Contact = new OpenApiContact
                {
                    Name = "João Paulo Back",
                    Email = "joaoback47@gmail.com"
                }
            });
            var xmlFile = "LibraryManagerApi.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            o.IncludeXmlComments(xmlPath);
        });
        var app = builder.Build();
        app.MapControllers();
        app.UseSwagger();
        app.UseSwaggerUI();

        // ensure for bogus fake data
        var context = app.Services.GetService<DatabaseContext>();
        context?.Database.EnsureCreated();
        app.Run();
    }
}