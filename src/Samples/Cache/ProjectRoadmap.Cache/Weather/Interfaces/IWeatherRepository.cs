using ProjectRoadmap.Cache.Endpoints;

namespace ProjectRoadmap.Cache;

public interface IWeatherRepository
{
    WeatherForecast? GetByLocation(string location);
    void Update(string location, WeatherForecast forecast);
}