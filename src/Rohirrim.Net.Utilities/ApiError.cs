using System;

namespace Rohirrim.Net.Utilities;

public class ApiError
{
    public ApiError()
    {
    }
    
    public ApiError(string message)
    {
        Message = message;
    }
    
    public string ReferenceId => Guid.NewGuid().ToString("N");
    public string? Message { get; }
    
    public static ApiError Create() => new();
    public static ApiError Create(string message) => new(message);
    public static ApiError Create<T>(string message, T details) => new ApiError<T>(message, details);
    public static ApiError Create<T>(T details) => new ApiError<T>(details);
}

public sealed class ApiError<T> : ApiError
{
    public ApiError(T details)
    {
        Details = details;
    }
    
    public ApiError(string message, T details) : base(message)
    {
        Details = details;
    }
    
    public T? Details { get; }
}