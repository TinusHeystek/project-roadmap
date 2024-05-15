using Moq;
using ProjectRoadmap.Cache.Endpoints;
using ProjectRoadmap.Cache.Tests.Factories;

namespace ProjectRoadmap.Cache.Tests;

public class WeatherServiceTests
{
    private readonly Mock<IWeatherCache> _mockCache;
    private readonly Mock<IWeatherRepository> _mockRepository;
    private readonly WeatherService _service;
    
    public WeatherServiceTests()
    {
        _mockCache = new Mock<IWeatherCache>();
        _mockRepository = new Mock<IWeatherRepository>();
        _service = new WeatherService(_mockCache.Object, _mockRepository.Object);
    }
    
    [Fact]
    public void GetByLocation_ReturnsForecastFromCache_WhenForecastExistsInCache()
    {
        // Arrange
        var expectedForecast = WeatherForecastFactory.GetWeatherForecast();
        _mockCache.Setup(c => c.Get(It.IsAny<string>())).Returns(expectedForecast);

        // Act
        var result = _service.GetByLocation("location");

        // Assert
        Assert.Equal(expectedForecast, result);
    }

    [Fact]
    public void GetByLocation_ReturnsForecastFromRepository_WhenForecastDoesNotExistInCache()
    {
        // Arrange
        var expectedForecast = WeatherForecastFactory.GetWeatherForecast();
        _mockCache.Setup(c => c.Get(It.IsAny<string>())).Returns((WeatherForecast)null!);
        _mockRepository.Setup(r => r.GetByLocation(It.IsAny<string>())).Returns(expectedForecast);

        // Act
        var result = _service.GetByLocation("location");

        // Assert
        Assert.Equal(expectedForecast, result);
    }

    [Fact]
    public void Update_UpdatesForecastInRepositoryAndCache()
    {
        // Arrange
        var forecast = WeatherForecastFactory.GetWeatherForecast();

        // Act
        _service.Update("location", forecast);

        // Assert
        _mockRepository.Verify(r => r.Update("location", forecast), Times.Once);
        _mockCache.Verify(c => c.Set("location", forecast), Times.Once);
    }
}