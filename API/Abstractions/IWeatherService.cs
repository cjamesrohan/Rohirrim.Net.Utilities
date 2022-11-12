using ApiModels;

namespace API.Abstractions;

public interface IWeatherService
{
    public Task<WeatherForecastResponse> GetForecastAsync();
}