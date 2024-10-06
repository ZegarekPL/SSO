namespace server.Models.DTO;

public class WeatherForecastRequest
{
    public DateTime Date { get; set; }
    public int Temperature { get; set; }
    public string? Summary { get; set; }
}