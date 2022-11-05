using System;
using System.Net;
using LanguageExt.Common;

namespace Rohirrim.Net.Utilities.Result;

public class ResultException : Exception
{
    public readonly HttpStatusCode StatusCode;

    public ResultException(HttpStatusCode statusCode, string message) : base(message)
    {
        StatusCode = statusCode;
        Result.BadRequest("");
    }
}