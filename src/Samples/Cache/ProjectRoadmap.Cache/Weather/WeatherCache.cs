using Microsoft.Extensions.Caching.Memory;
using ProjectRoadmap.Cache.Endpoints;

namespace ProjectRoadmap.Cache;

public class WeatherCache : IWeatherCache
{
    private readonly IMemoryCache _memoryCache;
    private const string WeatherCacheKey = "weather-cache-";
    private static readonly TimeSpan ExpirationTime = TimeSpan.FromMinutes(5);

    public WeatherCache(IMemoryCache memoryCache)
    {
        _memoryCache = memoryCache;
    }

    public WeatherForecast? Get(string location)
    {
        var key = $"{WeatherCacheKey}{location}";
        return _memoryCache.Get<WeatherForecast>(key);
    }

    public void Set(string location, WeatherForecast forecast)
    {
        var key = $"{WeatherCacheKey}{location}";
        _memoryCache.Set(key, forecast, ExpirationTime);
    }
}