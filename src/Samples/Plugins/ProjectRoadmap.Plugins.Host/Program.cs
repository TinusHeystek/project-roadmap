using ProjectRoadmap.Plugins.Host;
using ProjectRoadmap.Plugins.Host.Extensions;
using Serilog;

var logger = Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateLogger();

logger.Information("Starting web host");

var builder = WebApplication.CreateBuilder(args);
{
    builder.Host.UseSerilog((_, config) =>
        config.ReadFrom.Configuration(builder.Configuration));
    
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddPluginModules(builder.Configuration);
    builder.Services.AddEndpoints(AssemblyReference.Assembly);
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.RegisterPluginModules();
    app.MapEndpoints();
    
    app.Map("/",() => "Ok");
}

try
{
    app.Run();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    Environment.Exit(-1);
}

public partial class Program { } // needed for tests