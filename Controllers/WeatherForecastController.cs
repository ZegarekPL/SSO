using HttpExceptions.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Models;
using server.Models.DTO;

namespace server.Controllers;

[ApiController]
[Route("weatherForecast")]
public class WeatherForecastController(AppDbContext context) : ControllerBase
{
    [HttpGet("GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        return await context.WeatherForecast.ToListAsync();
    }

    [HttpPost]
    public void Post(WeatherForecastRequest newWeatherForecast)
    {
        WeatherForecast weatherForecast = new WeatherForecast();
        
        weatherForecast.Date = newWeatherForecast.Date;
        weatherForecast.Temperature = newWeatherForecast.Temperature;
        weatherForecast.Summary = newWeatherForecast.Summary;
        
        context.WeatherForecast.Add(weatherForecast);
        context.SaveChanges();
    }
    
    [HttpPut]
    public void Put(WeatherForecastRequest newWeatherForecast, int id)
    {
        WeatherForecast weatherForecast = context.WeatherForecast.SingleOrDefault(wf => wf.Id == id)
            ?? throw new NotFoundException("Not Exists");
        
        weatherForecast.Date = newWeatherForecast.Date;
        if(newWeatherForecast.Date.Day > 31) throw new BadRequestException("ASDasd");
        weatherForecast.Temperature = newWeatherForecast.Temperature;
        weatherForecast.Summary = newWeatherForecast.Summary;
        
        context.WeatherForecast.Update(weatherForecast);
        context.SaveChanges();
    }
    
    [HttpDelete]
    public void Delete(int id)
    {
        WeatherForecast weatherForecast = context.WeatherForecast.SingleOrDefault(wf => wf.Id == id)
                                          ?? throw new NotFoundException("Not Exists");
        context.WeatherForecast.Remove(weatherForecast);
        context.SaveChanges();
    }
}