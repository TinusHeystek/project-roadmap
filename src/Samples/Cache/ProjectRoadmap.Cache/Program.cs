using ProjectRoadmap.Cache.Weather;
using ProjectRoadmap.Cache.Weather.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMemoryCache();
builder.Services.AddSingleton<IWeatherRepository, WeatherRepository>();

// builder.Services.AddSingleton<IWeatherCache, WeatherCache>();
// builder.Services.AddScoped<IWeatherService, WeatherService>();

builder.Services.AddScoped<IWeatherService, WeatherServiceWithMemoryCache>();

var app = builder.Build();

app.RegisterWeatherEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();

