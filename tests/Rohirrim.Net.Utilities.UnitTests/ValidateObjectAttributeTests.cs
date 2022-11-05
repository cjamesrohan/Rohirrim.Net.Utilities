using System.ComponentModel.DataAnnotations;
using LanguageExt.Common;
using Microsoft.Extensions.Logging;
using Rohirrim.Net.Utilities.OptionsValidation;
using Rohirrim.Net.Utilities.Testing;

namespace Rohirrim.Net.Utilities.UnitTests;

public class ValidateObjectAttributeTests
{
    // System under test
    private readonly ValidateObjectAttribute _sut;

    public ValidateObjectAttributeTests()
    {
        _sut = new ValidateObjectAttribute();
    }

    [Fact]
    public void Validate_ShouldReturnSuccess_WhenValueIsNull()
    {
        // Arrange
        TestClass? testClass = null;

        // Act
        var result = _sut.GetValidationResult(testClass, new ValidationContext(new TestClass()));

        // Assert
        result.Should().Be(ValidationResult.Success);
    }

    [Fact]
    public void Validate_ShouldReturnSuccess_WhenValidationSucceeds()
    {
        // Arrange
        var testClass = new TestClass { Value = "SomeString" };

        // Act
        var result = _sut.GetValidationResult(testClass, new ValidationContext(testClass));

        // Assert
        result.Should().Be(ValidationResult.Success);
    }

    [Fact]
    public void Validate_ShouldReturnError_WhenValidationFails()
    {
        // Arrange
        var testClass = new TestClass();
        var expectedResult = new ValidationResult("The TestClass object is invalid: The Value field is required.");

        // Act
        var result = _sut.GetValidationResult(testClass, new ValidationContext(testClass));

        // Assert
        result.Should().BeEquivalentTo(expectedResult);
    }
}

public class TestClass
{
    [Required]
    public string? Value { get; set; }
}