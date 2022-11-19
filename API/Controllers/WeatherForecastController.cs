using API.Abstractions;
using API.Implementations;
using ApiModels;
using Microsoft.AspNetCore.Mvc;
using Rohirrim.Net.Utilities;

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
    public async Task<IActionResult> Get()
    {
        try
        {
            var response = await _weatherService.GetForecastAsync();
            return Ok(response);
        }
        catch (DataNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}