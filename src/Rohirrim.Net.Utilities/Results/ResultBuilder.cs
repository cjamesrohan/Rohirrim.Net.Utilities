using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Rohirrim.Net.Utilities.Results;

public sealed class ResultBuilder<T>
{
    private readonly Result<T> _instance;
    private IActionResult? _result;
    
    public ResultBuilder(Result<T> instance, Func<T, IActionResult> onSuccess)
    {
        _instance = instance;
        if (instance.IsSuccess && instance.Value is not null)
        {
            _result = onSuccess(instance.Value);
        }
    }

    public ResultBuilder<T> HandleException<TException>(Func<TException, IActionResult> onFailure) where TException : Exception
    {
        var handledExceptionName = typeof(TException).Name;
        var instanceExceptionName = _instance.Exception?.GetType().Name;
        
        if (!_instance.IsSuccess && _instance.Exception is TException ex && string.Equals(handledExceptionName, instanceExceptionName))
        {
            _result = onFailure(ex);
        }
        return this;
    }

    public Task<IActionResult> ReturnAsync()
    {
        if (_result is not null)
        {
            // result will be either success path or handled exception path
            return Task.FromResult(_result);
        }

        if (_instance.Exception is not null)
        {
            // throw unhandled exceptions that were either thrown or returned
            throw _instance.Exception;
        }

        throw new Exception("The impossible has happened!");
    }
}