using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public virtual required DbSet<server.Models.WeatherForecast> WeatherForecast { get; set; }
    
    public virtual required DbSet<server.Models.User> Users { get; set; }
}
