using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace Rohirrim.Net.Utilities.OptionsValidation;

public static class ConfigResultExtensions
{
    private static readonly Dictionary<string, List<ValidationResult>> Errors = new();
    
    public static ConfigResult<T> Validate<T>(this ConfigResult<T> configResult) where T : class
    {
        if (!configResult.Config.Exists()) throw new ValidationException($"Missing config section for {configResult.Config.Key}");
        var isValid = configResult.TryValidate(out var errorMessages);
        if (!isValid) throw new ValidationException(string.Join(' ', errorMessages));
        return configResult;
    }

    public static bool TryValidate<T>(this ConfigResult<T> configResult, out List<string> errorMessages) where T : class
    {
        configResult.Options.TryValidate();
        errorMessages = Errors
            .Select(x => $"The {x.Key} object is invalid: {string.Join(' ', x.Value)}")
            .ToList();
        return !errorMessages.Any();
    }

    private static void TryValidate(this object? instance, string? rootTypeName = null)
    {
        if (instance is null) return;
        var type = instance.GetType();
        var typeName = type.Name;
        if (!string.IsNullOrWhiteSpace(rootTypeName))
        {
            typeName = $"{rootTypeName}.{typeName}";
        }
        var validationContext = new ValidationContext(instance);
        var validationResults = new List<ValidationResult>();
        Validator.TryValidateObject(instance, validationContext, validationResults, true);
        if (validationResults.Any())
        {
            if (!Errors.ContainsKey(typeName))
            {
                Errors.Add(typeName, new List<ValidationResult>());
            }
            Errors[typeName].AddRange(validationResults);   
        }
        foreach (var propertyInfo in type.GetProperties())
        {
            if (propertyInfo.PropertyType.IsClass)
            {
                var value = propertyInfo.GetValue(instance);
                value.TryValidate(typeName);
            }
        }
    }
}