using Xunit;

namespace server.Test;

public class WeatherForecastServiceTest
{
    [Fact]
    public void test1()
    {
        Assert.Equal(2, 1+1);
    }
    [Fact]
    public void test2()
    {
        Assert.Equal(2, 1+2);
    }
    [Fact]
    public void test3()
    {
        Assert.Equal(10, 1+1);
    }
}