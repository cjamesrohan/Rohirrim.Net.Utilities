using API.Abstractions;
using ApiModels;
using Microsoft.Extensions.Options;

namespace API.Implementations;

public class WeatherService : IWeatherService
{
    private readonly TestOptions _testOptions;

    private static readonly string[] Summaries = {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public WeatherService(IOptions<TestOptions> testOptions)
    {
        _testOptions = testOptions.Value;
    }
    
    public async Task<WeatherForecastResponse> GetForecastAsync()
    {
        await Task.Delay(100);
        var count = Random.Shared.Next(0, _testOptions.SomeInt);
        var weatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }).Take(count).ToList();
        if (!weatherForecasts.Any())
        {
            throw new DataNotFoundException("The requested data was not found");
        }
        return new WeatherForecastResponse(weatherForecasts);
    }
}

public class DataNotFoundException : Exception
{
    public DataNotFoundException(string message) : base(message)
    {
    }
}