
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ProductManagement.Common.Behaviors;
using ProductManagement.Common.Exceptions;
using ProductManagement.Infrastructure.Persistence;

namespace ProductManagement;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
        builder.Services.AddOpenApi();

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("Default")));

        builder.Services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

        builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);

        builder.Services.AddTransient(
        typeof(IPipelineBehavior<,>),
        typeof(ValidationBehavior<,>));


        builder.Services.AddExceptionHandler<ValidationExceptionHandler>();
        builder.Services.AddExceptionHandler<NotFoundExceptionHandler>();
        builder.Services.AddProblemDetails();

        var app = builder.Build();
        app.UseExceptionHandler();
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
