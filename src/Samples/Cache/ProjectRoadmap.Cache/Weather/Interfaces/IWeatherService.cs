using ProjectRoadmap.Cache.Models;

namespace ProjectRoadmap.Cache.Weather.Interfaces;

public interface IWeatherService
{
    WeatherForecast? GetByLocation(string location);
    void Update(string location, WeatherForecast forecast);
}