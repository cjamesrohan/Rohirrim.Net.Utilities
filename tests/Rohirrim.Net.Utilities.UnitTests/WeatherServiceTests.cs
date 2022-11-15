using API.Implementations;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Rohirrim.Net.Utilities.Testing;

namespace Rohirrim.Net.Utilities.UnitTests;

public class WeatherServiceTests
{
    // System under test
    private readonly WeatherService _sut;

    // Mocks
    private readonly Mock<ILogger<WeatherService>> _loggerMock = new();
    
    public WeatherServiceTests()
    {
        _sut = new WeatherService(
            _loggerMock.Object,
            Options.Create(new TestOptions{ SomeInt = 5 })
        );
    }
    
    [Fact]
    public async Task LogTest()
    {
        // Arrange
        const int count = 5;
        var scope = new Dictionary<string, string> { { "SomeId", "SomeValue" } };
        
        // Act
        await _sut.GetForecastAsync();
        
        // Assert
        _loggerMock.Should().LogInformation("Getting weather forecast, {@Count}", count);
        _loggerMock.Should().HaveScope(scope);
    }
}