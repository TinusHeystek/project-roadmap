using System.Collections.Concurrent;
using ProjectRoadmap.Cache.Models;
using ProjectRoadmap.Cache.Weather.Interfaces;

namespace ProjectRoadmap.Cache.Weather;

public class WeatherRepository : IWeatherRepository
{
    private readonly ConcurrentDictionary<string, WeatherForecast> _dbContext = new();

    public WeatherRepository()
    {
        Seed();
    }

    public WeatherForecast? GetByLocation(string location)
    {
        return _dbContext.GetValueOrDefault(location);
    }

    public void Update(string location, WeatherForecast forecast)
    {
        _dbContext[location] = forecast;
    }

    private void Seed()
    {
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        var forecasts = Enumerable.Range(10, 15).Select(index =>
            new
            {
                location = index.ToString(),
                value = new WeatherForecast()
                {
                    Date = DateTime.Now,
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = summaries[Random.Shared.Next(summaries.Length)]
                }
            });

        foreach (var forecast in forecasts)
        {
            _dbContext[forecast.location] = forecast.value;
        }
    }
}