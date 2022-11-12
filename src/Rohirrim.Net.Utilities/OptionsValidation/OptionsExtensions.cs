using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Rohirrim.Net.Utilities.OptionsValidation;

public static class OptionsExtensions
{
    private static readonly OptionsValidationConfig OptionsValidationConfig = new();

    public static IServiceCollection AddOptionsValidation(this IServiceCollection services, Action<OptionsValidationConfig>? config = null)
    {
        services.AddOptions();
        if (config is not null)
        {
            config(OptionsValidationConfig);
            OptionsValidationConfig.ValidateAllOptions = false;
        }
        else
        {
            OptionsValidationConfig.ValidateAllOptions = true;
        }
        return services;
    }
    
    public static ConfigResult<T> ConfigureAndGet<T>(this IServiceCollection services, IConfiguration config) where T : class
    {
        var configSection = config.GetSection(typeof(T).Name);
        return services.ConfigureAndGet<T>(configSection);
    }
    
    public static ConfigResult<T> ConfigureAndGet<T>(this IServiceCollection services, IConfigurationSection configSection) where T : class
    {
        services.Configure<T>(configSection);
        var options = configSection.Get<T>();
        var configResult = new ConfigResult<T>(configSection, options);
        if (OptionsValidationConfig.ValidateAllOptions ||
            (OptionsValidationConfig.OptionsToInclude.Contains(typeof(T)) && !OptionsValidationConfig.OptionsToExclude.Contains(typeof(T))))
        {
            return configResult.Validate();
        }
        return configResult;
    }
}

public sealed class OptionsValidationConfig
{
    internal bool ValidateAllOptions { get; set; }
    public List<Type> OptionsToInclude { get; set; } = new();
    public List<Type> OptionsToExclude { get; set; } = new();
}