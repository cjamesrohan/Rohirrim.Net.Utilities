using API.Abstractions;
using API.Implementations;
using ApiModels;
using Microsoft.AspNetCore.Mvc;
using Rohirrim.Net.Utilities.Results;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
[Produces("application/json")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherService _weatherService;

    public WeatherForecastController(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    [ProducesResponseType(typeof(WeatherForecastResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get(CancellationToken ct = default)
    {
        return await _weatherService.GetForecastAsync(ct)
            .OnSuccess(Ok)
            .HandleException<DataNotFoundException>(ex => NotFound(ex.Message))
            .ReturnAsync();
    }
}