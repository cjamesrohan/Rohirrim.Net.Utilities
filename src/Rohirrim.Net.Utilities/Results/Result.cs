using System;

namespace Rohirrim.Net.Utilities.Results;

public readonly struct Result<T>
{
    /// <summary>
    /// True if Value is not null, False if Exception is not null
    /// </summary>
    public readonly bool IsSuccess;
    
    /// <summary>
    /// Success object
    /// </summary>
    public readonly T? Value;

    /// <summary>
    /// Error used for failed state
    /// </summary>
    public readonly Exception? Exception;

    [Obsolete("Default constructor disabled. Please use extension methods.", true)]
    public Result() => throw new InvalidOperationException("Default constructor disabled. Please use extension methods.");

    /// <summary>
    /// Success ctor, internal use only
    /// </summary>
    /// <param name="value"></param>
    private Result(T value)
    {
        IsSuccess = true;
        Value = value;
        Exception = null;
    }

    /// <summary>
    /// Failed ctor, internal use only
    /// </summary>
    /// <param name="exception"></param>
    private Result(Exception exception)
    {
        IsSuccess = false;
        Value = default;
        Exception = exception;
    }

    /// <summary>
    /// Implicit operator to allow simple response objects
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static implicit operator Result<T>(T value) => new(value);

    /// <summary>
    /// Implicit operator to allow simple response objects
    /// </summary>
    /// <param name="exception"></param>
    /// <returns></returns>
    public static implicit operator Result<T>(Exception exception) => new(exception);
}