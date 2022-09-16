using System.ComponentModel.DataAnnotations;

namespace Rohirrim.Net.Utilities.UnitTests;

public class ValidationExtensionsTests
{
    [Fact]
    public void TryValidate_ShouldReturnErrors_WhenValidationFails()
    {
        // Arrange
        var expectedErrors = new List<string>
        {
            "The SomeProperty field is required."
        };
        var testObject = new ValidationTestClass();

        // Act
        testObject.TryValidate(out var errors);

        // Assert
        errors.Should().NotBeNullOrEmpty();
        errors.Should().BeEquivalentTo(expectedErrors);
    }
    
    [Fact]
    public void TryValidate_ShouldReturnNoErrors_WhenValidationPasses()
    {
        // Arrange
        var testObject = new ValidationTestClass
        {
            SomeProperty = "some value"
        };

        // Act
        testObject.TryValidate(out var errors);

        // Assert
        errors.Should().BeEmpty();
    }
    
    [Fact]
    public void Validate_ShouldThrowValidationException_WhenValidationFails()
    {
        // Arrange
        var testObject = new ValidationTestClass();

        // Act
        var act = () => testObject.Validate();

        // Assert
        act.Should().Throw<ValidationException>().WithMessage("The ValidationTestClass object is invalid: The SomeProperty field is required.");
    }
    
    [Fact]
    public void Validate_ShouldNotThrow_WhenValidationPasses()
    {
        // Arrange
        var testObject = new ValidationTestClass
        {
            SomeProperty = "some value"
        };

        // Act
        var act = () => testObject.Validate();

        // Assert
        act.Should().NotThrow();
    }
}

public class ValidationTestClass
{
    [Required]
    public string SomeProperty { get; set; } = null!;
}