using ProjectRoadmap.Cache.Models;
using ProjectRoadmap.Cache.Weather.Interfaces;

namespace ProjectRoadmap.Cache.Weather;

public class WeatherService : IWeatherService
{
    private readonly IWeatherCache _weatherCache;
    private readonly IWeatherRepository _weatherRepository;

    public WeatherService(IWeatherCache weatherCache, IWeatherRepository weatherRepository)
    {
        _weatherCache = weatherCache;
        _weatherRepository = weatherRepository;
    }

    public WeatherForecast? GetByLocation(string location)
    {
        var forecast = _weatherCache.Get(location);
        if (forecast is not null)
            return forecast;
        
        forecast = _weatherRepository.GetByLocation(location);
        if (forecast is not null)
        {
            _weatherCache.Set(location, forecast);
        }
        return forecast;
    }

    public void Update(string location, WeatherForecast forecast)
    {
        // validation
        _weatherRepository.Update(location, forecast);
        _weatherCache.Set(location, forecast);
    }
}