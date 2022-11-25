using API.Abstractions;
using ApiModels;
using Microsoft.Extensions.Options;
using Rohirrim.Net.Utilities.Results;

namespace API.Implementations;

public class WeatherService : IWeatherService
{
    private readonly ILogger<WeatherService> _logger;
    private readonly TestOptions _testOptions;

    private static readonly string[] Summaries = {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public WeatherService(ILogger<WeatherService> logger, IOptions<TestOptions> testOptions)
    {
        _logger = logger;
        _testOptions = testOptions.Value;
    }
    
    public async Task<Result<WeatherForecastResponse>> GetForecastAsync(CancellationToken ct = default)
    {
        _logger.BeginScope(new Dictionary<string, string> { { "SomeId", "SomeValue" } });
        
        await Task.Delay(100);
        var random = new Random();
        var count = random.Next(1, _testOptions.SomeInt);
        _logger.LogInformation("Getting weather forecast, {@Count}", 5);
        var weatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = random.Next(-20, 55),
            Summary = Summaries[random.Next(Summaries.Length)]
        }).Take(count).ToList();
        if (!weatherForecasts.Any())
        {
            return new DataNotFoundException("The requested data was not found");
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