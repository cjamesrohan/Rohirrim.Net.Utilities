using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.Extensions.Logging;
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

    #region LogDebug
    public void LogDebug(string message, params object[] args)
    {
        Log(LogLevel.Debug, message, args);
    }

    public void LogDebug(EventId eventId, string message, params object[] args)
    {
        Log(LogLevel.Debug, eventId, message, args);
    }

    public void LogDebug(Exception exception, string message, params object[] args)
    {
        Log(LogLevel.Debug, exception, message, args);
    }
    
    public void LogDebug(EventId eventId, Exception? exception, string message, params object[] args)
    {   
        Log(LogLevel.Debug, eventId, exception, message, args);
    }
    #endregion
    
    #region NotLogDebug
    public void NotLogDebug(string message, params object[] args)
    {
        NotLog(LogLevel.Debug, message, args);
    }

    public void NotLogDebug(EventId eventId, string message, params object[] args)
    {
        NotLog(LogLevel.Debug, eventId, message, args);
    }

    public void NotLogDebug(Exception exception, string message, params object[] args)
    {
        NotLog(LogLevel.Debug, exception, message, args);
    }
    
    public void NotLogDebug(EventId eventId, Exception? exception, string message, params object[] args)
    {   
        NotLog(LogLevel.Debug, eventId, exception, message, args);
    }
    #endregion
    
    #region LogTrace
    public void LogTrace(string message, params object[] args)
    {
        Log(LogLevel.Trace, message, args);
    }

    public void LogTrace(EventId eventId, string message, params object[] args)
    {
        Log(LogLevel.Trace, eventId, message, args);
    }

    public void LogTrace(Exception exception, string message, params object[] args)
    {
        Log(LogLevel.Trace, exception, message, args);
    }
    
    public void LogTrace(EventId eventId, Exception? exception, string message, params object[] args)
    {   
        Log(LogLevel.Trace, eventId, exception, message, args);
    }
    #endregion
    
    #region NotLogTrace
    public void NotLogTrace(string message, params object[] args)
    {
        NotLog(LogLevel.Trace, message, args);
    }

    public void NotLogTrace(EventId eventId, string message, params object[] args)
    {
        NotLog(LogLevel.Trace, eventId, message, args);
    }

    public void NotLogTrace(Exception exception, string message, params object[] args)
    {
        NotLog(LogLevel.Trace, exception, message, args);
    }
    
    public void NotLogTrace(EventId eventId, Exception? exception, string message, params object[] args)
    {   
        NotLog(LogLevel.Trace, eventId, exception, message, args);
    }
    #endregion
    
    #region LogInformation
    public void LogInformation(string message, params object[] args)
    {
        Log(LogLevel.Information, message, args);
    }

    public void LogInformation(EventId eventId, string message, params object[] args)
    {
        Log(LogLevel.Information, eventId, message, args);
    }

    public void LogInformation(Exception exception, string message, params object[] args)
    {
        Log(LogLevel.Information, exception, message, args);
    }
    
    public void LogInformation(EventId eventId, Exception? exception, string message, params object[] args)
    {   
        Log(LogLevel.Information, eventId, exception, message, args);
    }
    #endregion
    
    #region NotLogInformation
    public void NotLogInformation(string message, params object[] args)
    {
        NotLog(LogLevel.Information, message, args);
    }

    public void NotLogInformation(EventId eventId, string message, params object[] args)
    {
        NotLog(LogLevel.Information, eventId, message, args);
    }

    public void NotLogInformation(Exception exception, string message, params object[] args)
    {
        NotLog(LogLevel.Information, exception, message, args);
    }
    
    public void NotLogInformation(EventId eventId, Exception? exception, string message, params object[] args)
    {   
        NotLog(LogLevel.Information, eventId, exception, message, args);
    }
    #endregion
    
    #region LogWarning
    public void LogWarning(string message, params object[] args)
    {
        Log(LogLevel.Warning, message, args);
    }

    public void LogWarning(EventId eventId, string message, params object[] args)
    {
        Log(LogLevel.Warning, eventId, message, args);
    }

    public void LogWarning(Exception exception, string message, params object[] args)
    {
        Log(LogLevel.Warning, exception, message, args);
    }
    
    public void LogWarning(EventId eventId, Exception? exception, string message, params object[] args)
    {   
        Log(LogLevel.Warning, eventId, exception, message, args);
    }
    #endregion
    
    #region NotLogWarning
    public void NotLogWarning(string message, params object[] args)
    {
        NotLog(LogLevel.Warning, message, args);
    }

    public void NotLogWarning(EventId eventId, string message, params object[] args)
    {
        NotLog(LogLevel.Warning, eventId, message, args);
    }

    public void NotLogWarning(Exception exception, string message, params object[] args)
    {
        NotLog(LogLevel.Warning, exception, message, args);
    }
    
    public void NotLogWarning(EventId eventId, Exception? exception, string message, params object[] args)
    {   
        NotLog(LogLevel.Warning, eventId, exception, message, args);
    }
    #endregion
    
    #region LogError
    public void LogError(string message, params object[] args)
    {
        Log(LogLevel.Error, message, args);
    }

    public void LogError(EventId eventId, string message, params object[] args)
    {
        Log(LogLevel.Error, eventId, message, args);
    }

    public void LogError(Exception exception, string message, params object[] args)
    {
        Log(LogLevel.Error, exception, message, args);
    }
    
    public void LogError(EventId eventId, Exception? exception, string message, params object[] args)
    {   
        Log(LogLevel.Error, eventId, exception, message, args);
    }
    #endregion
    
    #region NotLogError
    public void NotLogError(string message, params object[] args)
    {
        NotLog(LogLevel.Error, message, args);
    }

    public void NotLogError(EventId eventId, string message, params object[] args)
    {
        NotLog(LogLevel.Error, eventId, message, args);
    }

    public void NotLogError(Exception exception, string message, params object[] args)
    {
        NotLog(LogLevel.Error, exception, message, args);
    }
    
    public void NotLogError(EventId eventId, Exception? exception, string message, params object[] args)
    {   
        NotLog(LogLevel.Error, eventId, exception, message, args);
    }
    #endregion
    
    #region LogCritical
    public void LogCritical(string message, params object[] args)
    {
        Log(LogLevel.Critical, message, args);
    }

    public void LogCritical(EventId eventId, string message, params object[] args)
    {
        Log(LogLevel.Critical, eventId, message, args);
    }

    public void LogCritical(Exception exception, string message, params object[] args)
    {
        Log(LogLevel.Critical, exception, message, args);
    }
    
    public void LogCritical(EventId eventId, Exception? exception, string message, params object[] args)
    {   
        Log(LogLevel.Critical, eventId, exception, message, args);
    }
    #endregion

    #region NotLogCritical
    public void NotLogCritical(string message, params object[] args)
    {
        NotLog(LogLevel.Critical, message, args);
    }

    public void NotLogCritical(EventId eventId, string message, params object[] args)
    {
        NotLog(LogLevel.Critical, eventId, message, args);
    }

    public void NotLogCritical(Exception exception, string message, params object[] args)
    {
        NotLog(LogLevel.Critical, exception, message, args);
    }
    
    public void NotLogCritical(EventId eventId, Exception? exception, string message, params object[] args)
    {   
        NotLog(LogLevel.Critical, eventId, exception, message, args);
    }
    #endregion
    
    #region Log
    public void Log(LogLevel logLevel, string message, params object[] args)
    {
        Verify(Times.AtLeastOnce(), logLevel, 0, null, message, args);
    }
    
    public void Log(LogLevel logLevel, EventId eventId, string message, params object[] args)
    {
        Verify(Times.AtLeastOnce(), logLevel, eventId, null, message, args);
    }
    
    public void Log(LogLevel logLevel, Exception exception, string message, params object[] args)
    {
        Verify(Times.AtLeastOnce(), logLevel, 0, exception, message, args);
    }
    
    public void Log(LogLevel logLevel, EventId eventId, Exception? exception, string message, params object[] args)
    {   
        Verify(Times.AtLeastOnce(), logLevel, eventId, exception, message, args);
    }
    #endregion
    
    #region NotLog
    public void NotLog(LogLevel logLevel, string message, params object[] args)
    {
        Verify(Times.Never(), logLevel, 0, null, message, args);
    }
    
    public void NotLog(LogLevel logLevel, EventId eventId, string message, params object[] args)
    {
        Verify(Times.Never(), logLevel, eventId, null, message, args);
    }
    
    public void NotLog(LogLevel logLevel, Exception exception, string message, params object[] args)
    {
        Verify(Times.Never(), logLevel, 0, exception, message, args);
    }
    
    public void NotLog(LogLevel logLevel, EventId eventId, Exception? exception, string message, params object[] args)
    {   
        Verify(Times.Never(), logLevel, eventId, exception, message, args);
    }
    #endregion
    
    private void Verify(Times times, LogLevel logLevel, EventId eventId, Exception? exception, string message, params object[] args)
    {
        var formattedLogMessage = new FormattedLogValues(message, args).ToString();
        var exceptionMessage = exception?.Message ?? "null";
        
        _instance.Verify(x => 
            x.Log(
                logLevel,
                eventId,
                It.Is<It.IsAnyType>((v, t) => v.ToString() == formattedLogMessage),
                exception,
                It.Is<Func<It.IsAnyType, Exception, string>>((v, t) => true)
            ),
            times,
            $"Expected log to occur Times.{times.ToString()}: Log(LogLevel.{logLevel}, {eventId}, {formattedLogMessage}, {exceptionMessage})"
        );
    }
    
    public void HaveScope<TState>(TState state)
    {
        _instance.Verify(x => x.BeginScope(state), "Missing or mismatched scope");
    }
}

internal class FormattedLogValues : IReadOnlyList<KeyValuePair<string, object>>
{
    internal const int MaxCachedFormatters = 1024;
    private const string NullFormat = "[null]";
    private static int _count;
    private static ConcurrentDictionary<string, LogValuesFormatter> _formatters = new();
    private readonly LogValuesFormatter _formatter = null!;
    private readonly object[] _values;
    private readonly string _originalMessage;

    // for testing purposes
    internal LogValuesFormatter? Formatter => _formatter;

    public FormattedLogValues(string format, params object[]? values)
    {
        if (values?.Length != 0 && format != null)
        {
            if (_count >= MaxCachedFormatters)
            {
                if (!_formatters.TryGetValue(format, out _formatter))
                {
                    _formatter = new LogValuesFormatter(format);
                }
            }
            else
            {
                _formatter = _formatters.GetOrAdd(format, f =>
                {
                    Interlocked.Increment(ref _count);
                    return new LogValuesFormatter(f);
                });
            }
        }

        _originalMessage = format ?? NullFormat;
        _values = values ?? new List<object>().ToArray();
    }

    public KeyValuePair<string, object> this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

            if (index == Count - 1)
            {
                return new KeyValuePair<string, object> ("{OriginalFormat}", _originalMessage);
            }

            return _formatter.GetValue(_values, index);
        }
    }

    public int Count
    {
        get
        {
            if (_formatter == null)
            {
                return 1;
            }

            return _formatter.ValueNames.Count + 1;
        }
    }

    public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
    {
        for (int i = 0; i < Count; ++i)
        {
            yield return this[i];
        }
    }

    public override string ToString()
    {
        if (_formatter == null)
        {
            return _originalMessage;
        }

        return _formatter.Format(_values);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
    
internal class LogValuesFormatter
{
    private const string NullValue = "(null)";
    private static readonly object[] EmptyArray = new object[0];
    private static readonly char[] FormatDelimiters = {',', ':'};
    private readonly string _format;
    private readonly List<string> _valueNames = new List<string>();

    public LogValuesFormatter(string format)
    {
        OriginalFormat = format;

        var sb = new StringBuilder();
        var scanIndex = 0;
        var endIndex = format.Length;

        while (scanIndex < endIndex)
        {
            var openBraceIndex = FindBraceIndex(format, '{', scanIndex, endIndex);
            var closeBraceIndex = FindBraceIndex(format, '}', openBraceIndex, endIndex);

            // Format item syntax : { index[,alignment][ :formatString] }.
            var formatDelimiterIndex = FindIndexOfAny(format, FormatDelimiters, openBraceIndex, closeBraceIndex);

            if (closeBraceIndex == endIndex)
            {
                sb.Append(format, scanIndex, endIndex - scanIndex);
                scanIndex = endIndex;
            }
            else
            {
                sb.Append(format, scanIndex, openBraceIndex - scanIndex + 1);
                sb.Append(_valueNames.Count.ToString(CultureInfo.InvariantCulture));
                _valueNames.Add(format.Substring(openBraceIndex + 1, formatDelimiterIndex - openBraceIndex - 1));
                sb.Append(format, formatDelimiterIndex, closeBraceIndex - formatDelimiterIndex + 1);

                scanIndex = closeBraceIndex + 1;
            }
        }

        _format = sb.ToString();
    }

    public string OriginalFormat { get; private set; }
    public List<string> ValueNames => _valueNames;

    private static int FindBraceIndex(string format, char brace, int startIndex, int endIndex)
    {
        // Example: {{prefix{{{Argument}}}suffix}}.
        var braceIndex = endIndex;
        var scanIndex = startIndex;
        var braceOccurenceCount = 0;

        while (scanIndex < endIndex)
        {
            if (braceOccurenceCount > 0 && format[scanIndex] != brace)
            {
                if (braceOccurenceCount % 2 == 0)
                {
                    // Even number of '{' or '}' found. Proceed search with next occurence of '{' or '}'.
                    braceOccurenceCount = 0;
                    braceIndex = endIndex;
                }
                else
                {
                    // An unescaped '{' or '}' found.
                    break;
                }
            }
            else if (format[scanIndex] == brace)
            {
                if (brace == '}')
                {
                    if (braceOccurenceCount == 0)
                    {
                        // For '}' pick the first occurence.
                        braceIndex = scanIndex;
                    }
                }
                else
                {
                    // For '{' pick the last occurence.
                    braceIndex = scanIndex;
                }

                braceOccurenceCount++;
            }

            scanIndex++;
        }

        return braceIndex;
    }

    private static int FindIndexOfAny(string format, char[] chars, int startIndex, int endIndex)
    {
        var findIndex = format.IndexOfAny(chars, startIndex, endIndex - startIndex);
        return findIndex == -1 ? endIndex : findIndex;
    }

    public string Format(object[] values)
    {
        if (values != null)
        {
            for (int i = 0; i < values.Length; i++)
            {
                var value = values[i];

                if (value == null)
                {
                    values[i] = NullValue;
                    continue;
                }

                // since 'string' implements IEnumerable, special case it
                if (value is string)
                {
                    continue;
                }

                // if the value implements IEnumerable, build a comma separated string.
                var enumerable = value as IEnumerable;
                if (enumerable != null)
                {
                    values[i] = string.Join(", ", enumerable.Cast<object>().Select(o => o ?? NullValue));
                }
            }
        }

        return string.Format(CultureInfo.InvariantCulture, _format, values ?? EmptyArray);
    }

    public KeyValuePair<string, object> GetValue(object[] values, int index)
    {
        if (index < 0 || index > _valueNames.Count)
        {
            throw new IndexOutOfRangeException(nameof(index));
        }

        if (_valueNames.Count > index)
        {
            return new KeyValuePair<string, object>(_valueNames[index], values[index]);
        }

        return new KeyValuePair<string, object>("{OriginalFormat}", OriginalFormat);
    }

    public IEnumerable<KeyValuePair<string, object>> GetValues(object[] values)
    {
        var valueArray = new KeyValuePair<string, object>[values.Length + 1];
        for (var index = 0; index != _valueNames.Count; ++index)
        {
            valueArray[index] = new KeyValuePair<string, object>(_valueNames[index], values[index]);
        }

        valueArray[valueArray.Length - 1] = new KeyValuePair<string, object>("{OriginalFormat}", OriginalFormat);
        return valueArray;
    }
}