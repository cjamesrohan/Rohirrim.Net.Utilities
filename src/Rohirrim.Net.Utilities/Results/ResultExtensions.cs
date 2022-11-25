using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Rohirrim.Net.Utilities.Results;

public static class ResultExtensions
{
    public static ResultBuilder<T> OnSuccess<T>(this Task<Result<T>> resultTask, Func<T, IActionResult> onSuccess)
    {
        try
        {
            var result = resultTask.GetAwaiter().GetResult();
            return new ResultBuilder<T>(result, onSuccess);
        }
        catch (Exception ex)
        {
            return new ResultBuilder<T>(ex, onSuccess);
        }
    }
}