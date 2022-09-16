namespace Rohirrim.Net.Utilities.UnitTests;

public class UrlFormatAttributeTests
{
    // System under test
    private readonly UrlFormatAttribute _sut;

    public UrlFormatAttributeTests()
    {
        _sut = new UrlFormatAttribute();
    }
    
    [Theory]
    [InlineData(null, true)]
    [InlineData(5, false)]
    [InlineData("google", false)]
    [InlineData("https://google.com", true)]
    [InlineData("http://google.com", true)]
    [InlineData("http:///google.com", false)]
    [InlineData("htp://google.com", false)]
    [InlineData("http:://google.com", false)]
    public void IsValid_ShouldReturnExpectedResult_WhenValueProvided(object? value, bool expected)
    {
        // Arrange

        // Act
        var result = _sut.IsValid(value);

        // Assert
        result.Should().Be(expected);
    }
}