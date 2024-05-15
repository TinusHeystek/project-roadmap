using ProjectRoadmap.Cache.Endpoints;

namespace ProjectRoadmap.Cache;

public interface IWeatherService
{
    WeatherForecast? GetByLocation(string location);
    void Update(string location, WeatherForecast forecast);
}