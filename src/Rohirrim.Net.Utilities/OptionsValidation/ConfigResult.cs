using System;
using Microsoft.Extensions.Configuration;

namespace Rohirrim.Net.Utilities.OptionsValidation;

public readonly struct ConfigResult<T>
{
    public readonly IConfigurationSection Config;
    public readonly T Options;
    
    [Obsolete("Default constructor disabled.", true)]
    public ConfigResult() => throw new InvalidOperationException("Default constructor disabled.");

    public ConfigResult(IConfigurationSection configSection, T options)
    {
        Config = configSection;
        Options = options;
    }
}