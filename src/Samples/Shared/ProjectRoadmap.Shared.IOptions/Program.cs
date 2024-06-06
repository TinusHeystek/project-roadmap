using FluentValidation;
using ProjectRoadmap.Shared.IOptions.BackgroundServices;
using ProjectRoadmap.Shared.IOptions.Sample;
using ProjectRoadmap.Shared.IOptions.SharedKernel;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    
    builder.Services
        .AddOptions<SampleAnnotationSettings>()
        .BindConfiguration(SampleAnnotationSettings.SectionName)
        .ValidateDataAnnotations()
        .ValidateOnStart();

    builder.Services.AddOptionsWithFluentValidation<SampleSettings>(SampleSettings.SectionName);
    
    builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
    
    builder.Services.AddHostedService<OptionsBackgroundService>();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    
    app.RegisterOptionEndpoints();

    app.UseHttpsRedirection();
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

public partial class Program;
