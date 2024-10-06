namespace server.Models.DTO;

public class WeatherForecastRequest
{
    public required DateTime Date { get; set; }
    public required int Temperature { get; set; }
    public string? Summary { get; set; }
}