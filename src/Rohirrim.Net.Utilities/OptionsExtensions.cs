using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Rohirrim.Net.Utilities;

public static class OptionsExtensions
{
    public static ConfigResult<T> ConfigureAndGet<T>(this IServiceCollection services, IConfiguration config) where T : class
    {
        var configSection = config.GetSection(typeof(T).Name);
        return services.ConfigureAndGet<T>(configSection);
    }
    
    public static ConfigResult<T> ConfigureAndGet<T>(this IServiceCollection services, IConfigurationSection configSection) where T : class
    {
        if (!configSection.Exists()) throw new ValidationException($"Missing config section for {configSection.Key}");
        services.Configure<T>(configSection);
        var options = configSection.Get<T>();
        options.Validate();
        return new ConfigResult<T>(configSection, options);
    }
}