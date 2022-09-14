using System;
using System.Net;

namespace Rohirrim.Net.Utilities;

public readonly struct ApiError
{
    public readonly int HttpStatusCode;
    public readonly string ErrorId;
    public readonly string? Message;
    
    [Obsolete("Default constructor disabled.", true)]
    public ApiError() => throw new InvalidOperationException("Default constructor disabled.");
    
    public ApiError(HttpStatusCode statusCode, string? message = null)
    {
        HttpStatusCode = (int)statusCode;
        ErrorId = statusCode.ToString().ToUpper();
        Message = message;
    }
}