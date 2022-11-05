using System;
using System.Net;
using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;

namespace Rohirrim.Net.Utilities.Result;

public static class ResultExtensions
{   
    /// <summary>
    /// Returns an IActionResult with status code: 200 OK
    /// </summary>
    /// <param name="result"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static IActionResult ToOk<TResult>(this Result<TResult> result)
    {
        return result.OnSuccess(success => new OkObjectResult(success));
    }
        
    /// <summary>
    /// Returns an IActionResult with status code: 201 Created
    /// </summary>
    /// <param name="result"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static IActionResult ToCreated<TResult>(this Result<TResult> result)
    {
        return result.OnSuccess(success => new ObjectResult(success) { StatusCode = (int)HttpStatusCode.Created });
    }

    /// <summary>
    /// Returns an IActionResult with statusCode: 204 No Content
    /// </summary>
    /// <param name="result"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static IActionResult ToNoContent<TResult>(this Result<TResult> result)
    {
        return result.OnSuccess(_ => new NoContentResult());
    }

    private static IActionResult OnSuccess<TResult>(this Result<TResult> result, Func<TResult, IActionResult> onSuccess)
    {
        return result.Match(onSuccess, Fail);
    }
    
    private static IActionResult Fail(Exception exception)
    {
        var httpStatusCode = exception switch
        {
            ResultException ex => ex.StatusCode,
            _ => HttpStatusCode.InternalServerError
        };
        return new ObjectResult(new { exception.Message }) { StatusCode = (int) httpStatusCode };
    }
}