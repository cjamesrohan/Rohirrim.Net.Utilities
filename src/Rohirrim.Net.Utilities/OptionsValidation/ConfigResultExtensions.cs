using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Rohirrim.Net.Utilities.OptionsValidation;

public static class ConfigResultExtensions
{
    public static ConfigResult<T> Validate<T>(this ConfigResult<T> configResult) where T : class
    {
        if (!configResult.Config.Exists()) throw new ValidationException($"Missing config section for {configResult.Config.Key}");
        var isValid = configResult.TryValidate(out var errorMessages);
        if (!isValid) throw new ValidationException($"The {typeof(T).Name} object is invalid: {string.Join(" ", errorMessages)}");
        return configResult;
    }

    public static bool TryValidate<T>(this ConfigResult<T> configResult, out List<string> errorMessages) where T : class
    {
        var options = configResult.Options;
        var validationContext = new ValidationContext(options);
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(options, validationContext, validationResults, true);
        errorMessages = validationResults.Where(x => !string.IsNullOrWhiteSpace(x.ErrorMessage)).Select(x => x.ErrorMessage!).ToList();
        return isValid;
    }
}