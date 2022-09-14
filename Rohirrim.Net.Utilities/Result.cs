using System;
using System.Net;

namespace Rohirrim.Net.Utilities;

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
    public readonly ApiError? Error;

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
        Error = null;
    }

    /// <summary>
    /// Failed ctor, internal use only
    /// </summary>
    /// <param name="error"></param>
    private Result(ApiError error)
    {
        IsSuccess = false;
        Value = default;
        Error = error;
    }

    /// <summary>
    /// Implicit operator to allow to simple response objects
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static implicit operator Result<T>(T value) => new(value);
        
    /// <summary>
    /// Returns a Result with status code: 400 Bad Request
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public static Result<T> BadRequest(string? message = null) => ErrorResult(HttpStatusCode.BadRequest, message);
    
    /// <summary>
    /// Returns a Result with status code: 404 Not Found
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public static Result<T> NotFound(string? message = null) => ErrorResult(HttpStatusCode.NotFound, message);
    
    /// <summary>
    /// Returns a Result with status code: 409 Conflict
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public static Result<T> Conflict(string? message = null) => ErrorResult(HttpStatusCode.Conflict, message);
    
    /// <summary>
    /// Returns a Result with status code: 410 Gone
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public static Result<T> Gone(string? message = null) => ErrorResult(HttpStatusCode.Gone, message);
    
    /// <summary>
    /// Returns a Result with a defined status code
    /// </summary>
    /// <param name="message"></param>
    /// <param name="statusCode"></param>
    /// <returns></returns>
    public static Result<T> ErrorResult(HttpStatusCode statusCode, string? message = null) =>
        statusCode < HttpStatusCode.BadRequest 
            ? throw new ArgumentException("Cannot return an ErrorResult with a success-level status code", nameof(statusCode))
            : new Result<T>(ApiError.Create(statusCode, message));
    
}