using System.ComponentModel.DataAnnotations;
using HttpExceptions.Exceptions;
using Microsoft.EntityFrameworkCore;
using server.Models;
using server.Models.DTO;

namespace server.Services;

public class WeatherForecastService(AppDbContext context)
{
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        return await context.WeatherForecast.ToListAsync();
    }
    
    public void Post([Required] WeatherForecastRequest newWeatherForecast)
    {
        WeatherForecast weatherForecast = new WeatherForecast();

        weatherForecast.Date = newWeatherForecast.Date;
        weatherForecast.Temperature = newWeatherForecast.Temperature;
        weatherForecast.Summary = newWeatherForecast.Summary;

        context.WeatherForecast.Add(weatherForecast);
        context.SaveChanges();
    }
    
    public void Put([Required] WeatherForecastRequest newWeatherForecast, [Required] int id)
    {
        WeatherForecast weatherForecast = context.WeatherForecast.SingleOrDefault(wf => wf.Id == id)
                                          ?? throw new NotFoundException("Not Exists");

        weatherForecast.Date = newWeatherForecast.Date;
        if (newWeatherForecast.Date.Day > 31) throw new BadRequestException("ASDasd");
        weatherForecast.Temperature = newWeatherForecast.Temperature;
        weatherForecast.Summary = newWeatherForecast.Summary;

        context.WeatherForecast.Update(weatherForecast);
        context.SaveChanges();
    }
    
    public void Delete([Required] int id)
    {
        WeatherForecast weatherForecast = context.WeatherForecast.SingleOrDefault(wf => wf.Id == id)
                                          ?? throw new NotFoundException("Not Exists");
        context.WeatherForecast.Remove(weatherForecast);
        context.SaveChanges();
    }
}