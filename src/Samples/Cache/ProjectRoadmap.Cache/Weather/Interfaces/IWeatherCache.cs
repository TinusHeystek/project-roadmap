using ProjectRoadmap.Cache.Models;

namespace ProjectRoadmap.Cache.Weather.Interfaces;

public interface IWeatherCache
{
    WeatherForecast? Get(string location);
    void Set(string location, WeatherForecast forecast);
}