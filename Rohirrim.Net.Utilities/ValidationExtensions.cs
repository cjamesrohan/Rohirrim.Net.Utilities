using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Rohirrim.Net.Utilities
{
    [ExcludeFromCodeCoverage]
    public static class ValidationExtensions
    {
        public static void Validate<T>(this T instance) where T : class
        {
            var isValid = instance.TryValidate(out var errorMessages);
            if (!isValid) throw new ValidationException($"The {typeof(T).Name} object is invalid: {string.Join(" ", errorMessages)}");
        }

        public static bool TryValidate<T>(this T instance, out List<string> errorMessages) where T : class
        {
            var validationContext = new ValidationContext(instance);
            var validationResults = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(instance, validationContext, validationResults, true);
            errorMessages = validationResults.Where(x => !string.IsNullOrWhiteSpace(x.ErrorMessage)).Select(x => x.ErrorMessage!).ToList();
            return isValid;
        }
    }
}