using System.Collections.Concurrent;
using ProjectRoadmap.Cache.Endpoints;

namespace ProjectRoadmap.Cache;

public class WeatherRepository : IWeatherRepository
{
    private readonly ConcurrentDictionary<string, WeatherForecast> _db = new();

    public WeatherRepository()
    {
        Seed();
    }

    public WeatherForecast? GetByLocation(string location)
    {
        return _db.GetValueOrDefault(location);
    }

    public void Update(string location, WeatherForecast forecast)
    {
        _db[location] = forecast;
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
            _db[forecast.location] = forecast.value;
        }
    }
}