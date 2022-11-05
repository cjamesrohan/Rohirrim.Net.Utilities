using System;
using System.Net;
using LanguageExt.Common;

namespace Rohirrim.Net.Utilities.Result;

public readonly struct Result
{       
    /// <summary>
    /// Returns a Result with status code: 400 Bad Request
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public static Result<object> BadRequest(string message) => ErrorResult(HttpStatusCode.BadRequest, message);
    
    /// <summary>
    /// Returns a Result with status code: 404 Not Found
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public static Result<object> NotFound(string message) => ErrorResult(HttpStatusCode.NotFound, message);
    
    /// <summary>
    /// Returns a Result with status code: 409 Conflict
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public static Result<object> Conflict(string message) => ErrorResult(HttpStatusCode.Conflict, message);
    
    /// <summary>
    /// Returns a Result with status code: 410 Gone
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public static Result<object> Gone(string message) => ErrorResult(HttpStatusCode.Gone, message);

    /// <summary>
    /// Returns a Result with a defined status code
    /// </summary>
    /// <param name="statusCode"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    public static Result<object> ErrorResult(HttpStatusCode statusCode, string message) =>
        statusCode < HttpStatusCode.BadRequest 
            ? throw new ArgumentException("Cannot return an ErrorResult with a success-level status code", nameof(statusCode))
            : new Result<object>(new ResultException(statusCode, message));
    
}