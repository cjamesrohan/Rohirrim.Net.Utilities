using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Internal;
using Moq;

namespace Rohirrim.Net.Utilities.Testing;

public static class LoggerMockExtensions
{
    public static LoggerAssertions<T> Should<T>(this Mock<ILogger<T>> instance)
    {
        return new LoggerAssertions<T>(instance);
    }
}

public sealed class LoggerAssertions<T>
{
    private readonly Mock<ILogger<T>> _instance;

    public LoggerAssertions(Mock<ILogger<T>> instance)
    {
        _instance = instance;
    }

    public void Log(LogLevel logLevel, string message, params object[] args)
    {
        Log(logLevel, 0, null, message, args);
    }

    public void Log(LogLevel logLevel, EventId eventId, string message, params object[] args)
    {
        Log(logLevel, eventId, null, message, args);
    }

    public void Log(LogLevel logLevel, Exception exception, string message, params object[] args)
    {
        Log(logLevel, 0, exception, message, args);
    }
    
    public void Log(LogLevel logLevel, EventId eventId, Exception? exception, string message, params object[] args)
    {
        _instance.Verify(x => x.Log(
            logLevel,
            eventId,
            new FormattedLogValues(message, args),
            exception,
            It.IsAny<Func<FormattedLogValues,Exception,string>>()));
    }
}