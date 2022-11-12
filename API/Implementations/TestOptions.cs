using System.ComponentModel.DataAnnotations;

namespace API.Implementations;

public sealed class TestOptions
{
    [Range(1,5)]
    public int SomeInt { get; set; }

    [Required]
    public SubOptions Sub { get; set; } = null!;
}

public sealed class SubOptions
{
    [Range(1,5)]
    public int SomeSubInt { get; set; }
}