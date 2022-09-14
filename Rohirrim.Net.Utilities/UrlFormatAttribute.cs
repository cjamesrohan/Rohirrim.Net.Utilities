using System;
using System.ComponentModel.DataAnnotations;

namespace Rohirrim.Net.Utilities;

[AttributeUsage(AttributeTargets.Property)]
public sealed class UrlFormatAttribute : ValidationAttribute
{
    public UrlFormatAttribute()
    {
        ErrorMessage = "The {0} field is not a valid fully-qualified http or https URL.";
    }
    
    public override bool IsValid(object? value)
    {
        if (value is null) return true;

        return value is string url &&
               Uri.TryCreate(url, UriKind.Absolute, out var result) &&
               (result.Scheme == Uri.UriSchemeHttp || result.Scheme == Uri.UriSchemeHttps);
    }
}