using Microsoft.AspNetCore.Mvc;
using ProjectRoadmap.Cache.Models;
using ProjectRoadmap.Cache.Weather.Interfaces;

namespace ProjectRoadmap.Cache.Weather;

public static class WeatherEndpoints
{
    public static void RegisterWeatherEndpoints(this WebApplication app )
    {
        app.MapGet("/weatherforecast", (
                [FromQuery] string location, 
                [FromServices] IWeatherService weatherService) =>
            {
                return weatherService.GetByLocation(location);
            })
            .WithName("GetWeatherForecast")
            .WithOpenApi();
        
        app.MapPost("/weatherforecast", (
                [FromQuery]string location, 
                [FromBody]WeatherForecast weatherForecast, 
                IWeatherService weatherService) =>
            {
                weatherService.Update(location, weatherForecast);
            })
            .WithName("SetWeatherForecast")
            .WithOpenApi();
    }
}