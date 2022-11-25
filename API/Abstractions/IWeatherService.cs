using ApiModels;
using Rohirrim.Net.Utilities.Results;

namespace API.Abstractions;

public interface IWeatherService
{
    public Task<Result<WeatherForecastResponse>> GetForecastAsync(CancellationToken ct = default);
}