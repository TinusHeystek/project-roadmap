using Microsoft.Extensions.Caching.Memory;
using ProjectRoadmap.Cache.Tests.Factories;
using ProjectRoadmap.Cache.Weather;

namespace ProjectRoadmap.Cache.Tests;

public class WeatherCacheTests
{
    private readonly WeatherCache _cache;
    
    public WeatherCacheTests()
    {
        var memoryCache = new MemoryCache(new MemoryCacheOptions());
        _cache = new WeatherCache(memoryCache);
    }
    
    [Fact]
    public void Get_ReturnsForecast_WhenForecastExists()
    {
        // Arrange
        var expectedForecast = WeatherForecastFactory.GetWeatherForecast();
        _cache.Set("location", expectedForecast);

        // Act
        var result = _cache.Get("location");

        // Assert
        Assert.Equal(expectedForecast, result);
    }

    [Fact]
    public void Set_SetsForecast()
    {
        // Arrange
        var forecast = WeatherForecastFactory.GetWeatherForecast();

        // Act
        _cache.Set("location", forecast);

        // Assert
        var result = _cache.Get("location");
        Assert.Equal(forecast, result);
    }
}