using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Rohirrim.Net.Utilities.OptionsValidation;

[AttributeUsage(AttributeTargets.Property)]
public sealed class ValidateObjectAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is null) return ValidationResult.Success;
        
        var results = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(value, new ValidationContext(value, null, null), results, true);
        if (isValid) return ValidationResult.Success;

        var errors = results.Select(x => x.ErrorMessage).ToList();
        var errorMessage = $"The {validationContext.DisplayName} object is invalid: {string.Join(" ", errors)}";
        
        return new ValidationResult(errorMessage);
    }
}