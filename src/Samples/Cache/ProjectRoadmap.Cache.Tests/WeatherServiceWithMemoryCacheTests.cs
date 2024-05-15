using Microsoft.Extensions.Caching.Memory;
using Moq;
using ProjectRoadmap.Cache.Models;
using ProjectRoadmap.Cache.Tests.Factories;
using ProjectRoadmap.Cache.Weather;
using ProjectRoadmap.Cache.Weather.Interfaces;

namespace ProjectRoadmap.Cache.Tests;

public class WeatherServiceWithMemoryCacheTests
{
    private readonly MemoryCache _memoryCache;
    private readonly Mock<IWeatherRepository> _mockRepository;
    private readonly WeatherServiceWithMemoryCache _service;
    
    private const string WeatherCacheKey = "weather-cache-";
    
    public WeatherServiceWithMemoryCacheTests()
    {
        _memoryCache = new MemoryCache(new MemoryCacheOptions());
        _mockRepository = new Mock<IWeatherRepository>();
        _service = new WeatherServiceWithMemoryCache(_memoryCache, _mockRepository.Object);
    }
    
    [Fact]
    public void GetByLocation_ReturnsForecastFromCache_WhenForecastExistsInCache()
    {
        // Arrange
        var key = "location";
        var expectedForecast = WeatherForecastFactory.GetWeatherForecast();
        _memoryCache.Set($"{WeatherCacheKey}{key}", expectedForecast);

        // Act
        var result = _service.GetByLocation(key);

        // Assert
        Assert.Equal(expectedForecast, result);
    }

    [Fact]
    public void GetByLocation_ReturnsForecastFromRepository_WhenForecastDoesNotExistInCache()
    {
        // Arrange
        var key = "location";
        var expectedForecast = WeatherForecastFactory.GetWeatherForecast();
        _mockRepository.Setup(r => r.GetByLocation(key)).Returns(expectedForecast);

        // Act
        var result = _service.GetByLocation(key);

        // Assert
        Assert.Equal(expectedForecast, result);
    }

    [Fact]
    public void Update_UpdatesForecastInRepositoryAndCache()
    {
        // Arrange
        var key = "location";
        var forecast = WeatherForecastFactory.GetWeatherForecast();

        // Act
        _service.Update(key, forecast);

        // Assert
        _mockRepository.Verify(r => r.Update("location", forecast), Times.Once);
        Assert.Equal(forecast, _memoryCache.Get<WeatherForecast>($"{WeatherCacheKey}{key}"));
    }
}