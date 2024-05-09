using System.Reflection;
using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using Serilog;
using StockStream.SharedKernel;
using StockStream.Users;

var logger = Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

logger.Information("Starting web host");

var builder = WebApplication.CreateBuilder(args);
{
    builder.Host.UseSerilog((_, config) =>
        config.ReadFrom.Configuration(builder.Configuration));

    builder.Services.AddFastEndpoints()
        .AddAuthenticationJwtBearer(
            signingOptions => { signingOptions.SigningKey = builder.Configuration["Auth:JwtSecret"]; })
        .AddAuthorization()
        .SwaggerDocument();

    // Add Module Services
    List<Assembly> mediatRAssemblies = [typeof(Program).Assembly];
    builder.Services.AddUserModuleServices(builder.Configuration, logger, mediatRAssemblies);

    // Set up MediatR
    builder.Services.AddMediatR(cfg =>
        cfg.RegisterServicesFromAssemblies(mediatRAssemblies.ToArray()));
    builder.Services.AddMediatRLoggingBehavior();
    builder.Services.AddMediatRFluentValidationBehavior();
    // builder.Services.AddValidatorsFromAssemblyContaining<AddItemToCartCommandValidator>();
    // Add MediatR Domain Event Dispatcher
    builder.Services.AddScoped<IDomainEventDispatcher, MediatRDomainEventDispatcher>();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    
    app.UseAuthentication()
        .UseAuthorization();

    app.UseFastEndpoints()
        .UseSwaggerGen();

    app.Run();
}

public partial class Program { } // needed for tests