using Microsoft.Extensions.Caching.Memory;
using ProjectRoadmap.Cache.Models;
using ProjectRoadmap.Cache.Weather.Interfaces;

namespace ProjectRoadmap.Cache.Weather;

public class WeatherServiceWithMemoryCache : IWeatherService
{
    private readonly IMemoryCache _memoryCache;
    private const string WeatherCacheKey = "weather-cache-";
    private static readonly TimeSpan ExpirationTime = TimeSpan.FromMinutes(5);
    
    private readonly IWeatherRepository _weatherRepository;

    public WeatherServiceWithMemoryCache(IMemoryCache memoryCache, IWeatherRepository weatherRepository)
    {
        _weatherRepository = weatherRepository;
        _memoryCache = memoryCache;
    }

    public WeatherForecast? GetByLocation(string location)
    {
        var key = $"{WeatherCacheKey}{location}";
        var forecast = _memoryCache.GetOrCreate(key, entry =>
        {
            var entity = _weatherRepository.GetByLocation(location);
            entry.AbsoluteExpirationRelativeToNow = entity is null ? TimeSpan.FromMinutes(-1) : ExpirationTime;
            return _weatherRepository.GetByLocation(location);
        });
        return forecast;
    }

    public void Update(string location, WeatherForecast forecast)
    {
        // validation
        _weatherRepository.Update(location, forecast);
        SetCache(location, forecast);
    }
    
    private void SetCache(string location, WeatherForecast forecast)
    {
        var key = $"{WeatherCacheKey}{location}";
        _memoryCache.Set(key, forecast, ExpirationTime);
    }
}