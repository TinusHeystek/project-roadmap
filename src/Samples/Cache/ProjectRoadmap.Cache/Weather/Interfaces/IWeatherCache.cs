using ProjectRoadmap.Cache.Endpoints;

namespace ProjectRoadmap.Cache;

public interface IWeatherCache
{
    WeatherForecast? Get(string location);
    void Set(string location, WeatherForecast forecast);
}