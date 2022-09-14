using System.Net;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Rohirrim.Net.Utilities;

public static class ResultExtensions
{
    public static ResultAssertions<T> Should<T>(this Result<T> instance)
    {
        return new ResultAssertions<T>(instance);
    }
    
    /// <summary>
    /// Returns an IActionResult with status code: 200 OK
    /// </summary>
    /// <param name="result"></param>
    /// <param name="logger"></param>
    /// <param name="methodName"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static IActionResult ToOk<TResult>(this Result<TResult> result, ILogger? logger = null, [CallerMemberName] string? methodName = null)
    {
        if (!result.IsSuccess) return Fail(result.Error, logger, methodName);
        logger?.LogInformation("Request succeeded for {@MethodName}, {@Response}", methodName, result.Value);
        return new OkObjectResult(result.Value);
    }
        
    /// <summary>
    /// Returns an IActionResult with status code: 201 Created
    /// </summary>
    /// <param name="result"></param>
    /// <param name="logger"></param>
    /// <param name="methodName"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static IActionResult ToCreated<TResult>(this Result<TResult> result, ILogger? logger = null, [CallerMemberName] string? methodName = null)
    {
        if (!result.IsSuccess) return Fail(result.Error, logger, methodName);
        logger?.LogInformation("Request succeeded for {@MethodName}, {@Response}", methodName, result.Value);
        return new ObjectResult(result.Value) { StatusCode = (int)HttpStatusCode.Created };
    }

    /// <summary>
    /// Returns an IActionResult with statusCode: 204 No Content
    /// </summary>
    /// <param name="result"></param>
    /// <param name="logger"></param>
    /// <param name="methodName"></param>
    /// <typeparam name="TResult"></typeparam>
    /// <returns></returns>
    public static IActionResult ToNoContent<TResult>(this Result<TResult> result, ILogger? logger = null, [CallerMemberName] string? methodName = null)
    {
        if (!result.IsSuccess) return Fail(result.Error, logger, methodName);
        logger?.LogInformation("Request succeeded for {@MethodName}", methodName);
        return new NoContentResult();
    }
        
    private static IActionResult Fail(ApiError? apiError, ILogger? logger = null, string? methodName = null)
    {
        logger?.LogWarning("Request failed for {@MethodName}, {@Response}", methodName, apiError);
        return new ObjectResult(apiError) { StatusCode = apiError?.HttpStatusCode };
    }
}