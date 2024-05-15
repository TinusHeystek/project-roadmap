using ProjectRoadmap.Cache.Endpoints;

namespace ProjectRoadmap.Cache.Tests.Factories;

public static class WeatherForecastFactory
{
    public static WeatherForecast GetWeatherForecast()
    {
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        return new WeatherForecast()
        {
            Date = DateTime.Now,
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = summaries[Random.Shared.Next(summaries.Length)]
        };
    }
}