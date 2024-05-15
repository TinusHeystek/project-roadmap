using ProjectRoadmap.Cache.Tests.Factories;
using ProjectRoadmap.Cache.Weather;

namespace ProjectRoadmap.Cache.Tests;

public class WeatherRepositoryTests
{
    private readonly WeatherRepository _repository;
    
    public WeatherRepositoryTests()
    {
        _repository = new WeatherRepository();
    }
    
    [Fact]
    public void GetByLocation_ReturnsForecast_WhenForecastExists()
    {
        // Arrange
        var expectedForecast = WeatherForecastFactory.GetWeatherForecast();
        _repository.Update("location", expectedForecast);

        // Act
        var result = _repository.GetByLocation("location");

        // Assert
        Assert.Equal(expectedForecast, result);
    }

    [Fact]
    public void Update_UpdatesForecast()
    {
        // Arrange
        var forecast = WeatherForecastFactory.GetWeatherForecast();

        // Act
        _repository.Update("location", forecast);

        // Assert
        var result = _repository.GetByLocation("location");
        Assert.Equal(forecast, result);
    }
}