using ProjectRoadmap.Cache.Models;

namespace ProjectRoadmap.Cache.Weather.Interfaces;

public interface IWeatherRepository
{
    WeatherForecast? GetByLocation(string location);
    void Update(string location, WeatherForecast forecast);
}