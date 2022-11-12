using System.Collections.Generic;

namespace ApiModels;

public class WeatherForecastResponse : List<WeatherForecast>
{
    public WeatherForecastResponse(IEnumerable<WeatherForecast> weatherForecasts) : base(weatherForecasts)
    {   
    }
}