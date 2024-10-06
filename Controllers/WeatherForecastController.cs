using System.ComponentModel.DataAnnotations;
using HttpExceptions.Exceptions;
using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Models.DTO;
using server.Services;

namespace server.Controllers;

[ApiController]
[Route("weatherForecast")]
public class WeatherForecastController(WeatherForecastService service) : ControllerBase
{
    [HttpGet("GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        return await service.Get();
    }

    [HttpPost]
    public void Post([Required] WeatherForecastRequest newWeatherForecast)
    {
        service.Post(newWeatherForecast);
    }

    [HttpPut]
    public void Put([Required] WeatherForecastRequest newWeatherForecast, [Required] int id)
    {
        service.Put(newWeatherForecast, id);
    }

    [HttpDelete]
    public void Delete([Required] int id)
    {
        service.Delete(id);
    }
}