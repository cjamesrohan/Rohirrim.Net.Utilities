using Microsoft.Extensions.Configuration;

namespace Rohirrim.Net.Utilities;

public sealed class ConfigResult<T>
{
    public IConfigurationSection Config { get; set; } = null!;
    public T Options { get; set; } = default!;
}