using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace InterpolatedLogTest;

public class ListLogger : ILogger
{
    private readonly LogLevel _minimumLogLevel;

    public List<(LogLevel logLevel, EventId eventId, object? state, Exception? exception, Delegate formatter)>
        Messages { get; } = new();

    public ListLogger(LogLevel minimumLogLevel)
    {
        _minimumLogLevel = minimumLogLevel;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return logLevel != LogLevel.None
               && logLevel >= _minimumLogLevel;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception,
        Func<TState, Exception?, string> formatter)
    {
        Messages.Add((logLevel, eventId, state, exception, formatter));
    }

    public IDisposable BeginScope<TState>(TState state)
    {
        throw new NotImplementedException();
    }
}