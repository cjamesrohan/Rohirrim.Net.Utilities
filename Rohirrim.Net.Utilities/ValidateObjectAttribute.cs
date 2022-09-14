using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Rohirrim.Net.Utilities
{
    [ExcludeFromCodeCoverage] // don't seem to have access ot this IsValid method for testing
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
}