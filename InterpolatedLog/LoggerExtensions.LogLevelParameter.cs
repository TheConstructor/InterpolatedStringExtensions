using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Extensions.Logging;

namespace InterpolatedLog;

public static partial class LoggerExtensions
{
    /// <summary>
    /// Log the interpolated string as formattable message to <paramref name="logger"/>, if it returns <c>true</c> from
    /// <see cref="ILogger.IsEnabled"/> for <paramref name="logLevel"/>.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><description>Uses C# 10 compiler-features to let you construct <paramref name="logHandler"/>!</description></item>
    /// <item><description>The placeholders are not evaluated, if the <paramref name="logLevel"/> is not enabled!</description></item>
    /// <item><description>Everything after the last <c>:</c> in a format-string is used as placeholder in the log-message. That means, that you need to type out a placeholder, if you use custom formats containing <c>:</c></description></item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// logger.LogEx(LogLevel.Trace, $"It is currently {GetTime():HH:mm:ss:logTime}!");
    /// </code>
    /// will have the same effect as
    /// <code>
    /// logger.Log(LogLevel.Trace, "It is currently {logTime:HH:mm:ss}!", new object?[] {GetTime()});
    /// </code>
    /// if <see cref="LogLevel.Trace"/> is enabled.
    /// If <see cref="LogLevel.Trace"/> is not enabled, <c>GetTime()</c> is not called.
    /// </example>
    /// <param name="logger">The <see cref="ILogger"/> to use</param>
    /// <param name="logLevel">The <see cref="LogLevel"/> to use (should be the same as used in the constructor)</param>
    /// <param name="logHandler">The compiler-constructed <see cref="InterpolatedLogHandler"/>. Just write your <c>$"Log {message}"</c></param>
    public static void LogEx(
        this ILogger logger,
        LogLevel logLevel,
        [InterpolatedStringHandlerArgument("logger", "logLevel")]
        ref InterpolatedLogHandler logHandler)
    {
        logHandler.LogAndClear(logger, logLevel);
    }

    /// <summary>
    /// Log the interpolated string as formattable message to <paramref name="logger"/>, if it returns <c>true</c> from
    /// <see cref="ILogger.IsEnabled"/> for <paramref name="logLevel"/>.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><description>Uses C# 10 compiler-features to let you construct <paramref name="logHandler"/>!</description></item>
    /// <item><description>The placeholders are not evaluated, if the <paramref name="logLevel"/> is not enabled!</description></item>
    /// <item><description>Everything after the last <c>:</c> in a format-string is used as placeholder in the log-message. That means, that you need to type out a placeholder, if you use custom formats containing <c>:</c></description></item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// logger.LogEx(LogLevel.Trace, $"It is currently {GetTime():HH:mm:ss:logTime}!");
    /// </code>
    /// will have the same effect as
    /// <code>
    /// logger.Log(LogLevel.Trace, "It is currently {logTime:HH:mm:ss}!", new object?[] {GetTime()});
    /// </code>
    /// if <see cref="LogLevel.Trace"/> is enabled.
    /// If <see cref="LogLevel.Trace"/> is not enabled, <c>GetTime()</c> is not called.
    /// </example>
    /// <param name="logger">The <see cref="ILogger"/> to use</param>
    /// <param name="logLevel">The <see cref="LogLevel"/> to use (should be the same as used in the constructor)</param>
    /// <param name="eventId">The <see cref="EventId"/> to use</param>
    /// <param name="logHandler">The compiler-constructed <see cref="InterpolatedLogHandler"/>. Just write your <c>$"Log {message}"</c></param>
    public static void LogEx(
        this ILogger logger,
        LogLevel logLevel,
        EventId eventId,
        [InterpolatedStringHandlerArgument("logger", "logLevel")]
        ref InterpolatedLogHandler logHandler)
    {
        logHandler.LogAndClear(logger, logLevel, eventId);
    }

    /// <summary>
    /// Log the interpolated string as formattable message to <paramref name="logger"/>, if it returns <c>true</c> from
    /// <see cref="ILogger.IsEnabled"/> for <paramref name="logLevel"/>.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><description>Uses C# 10 compiler-features to let you construct <paramref name="logHandler"/>!</description></item>
    /// <item><description>The placeholders are not evaluated, if the <paramref name="logLevel"/> is not enabled!</description></item>
    /// <item><description>Everything after the last <c>:</c> in a format-string is used as placeholder in the log-message. That means, that you need to type out a placeholder, if you use custom formats containing <c>:</c></description></item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// logger.LogEx(LogLevel.Trace, $"It is currently {GetTime():HH:mm:ss:logTime}!");
    /// </code>
    /// will have the same effect as
    /// <code>
    /// logger.Log(LogLevel.Trace, "It is currently {logTime:HH:mm:ss}!", new object?[] {GetTime()});
    /// </code>
    /// if <see cref="LogLevel.Trace"/> is enabled.
    /// If <see cref="LogLevel.Trace"/> is not enabled, <c>GetTime()</c> is not called.
    /// </example>
    /// <param name="logger">The <see cref="ILogger"/> to use</param>
    /// <param name="logLevel">The <see cref="LogLevel"/> to use (should be the same as used in the constructor)</param>
    /// <param name="exception">The <see cref="Exception"/> to log</param>
    /// <param name="logHandler">The compiler-constructed <see cref="InterpolatedLogHandler"/>. Just write your <c>$"Log {message}"</c></param>
    public static void LogEx(
        this ILogger logger,
        LogLevel logLevel,
        Exception? exception,
        [InterpolatedStringHandlerArgument("logger", "logLevel")]
        ref InterpolatedLogHandler logHandler)
    {
        logHandler.LogAndClear(logger, logLevel, exception);
    }

    /// <summary>
    /// Log the interpolated string as formattable message to <paramref name="logger"/>, if it returns <c>true</c> from
    /// <see cref="ILogger.IsEnabled"/> for <paramref name="logLevel"/>.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><description>Uses C# 10 compiler-features to let you construct <paramref name="logHandler"/>!</description></item>
    /// <item><description>The placeholders are not evaluated, if the <paramref name="logLevel"/> is not enabled!</description></item>
    /// <item><description>Everything after the last <c>:</c> in a format-string is used as placeholder in the log-message. That means, that you need to type out a placeholder, if you use custom formats containing <c>:</c></description></item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// logger.LogEx(LogLevel.Trace, $"It is currently {GetTime():HH:mm:ss:logTime}!");
    /// </code>
    /// will have the same effect as
    /// <code>
    /// logger.Log(LogLevel.Trace, "It is currently {logTime:HH:mm:ss}!", new object?[] {GetTime()});
    /// </code>
    /// if <see cref="LogLevel.Trace"/> is enabled.
    /// If <see cref="LogLevel.Trace"/> is not enabled, <c>GetTime()</c> is not called.
    /// </example>
    /// <param name="logger">The <see cref="ILogger"/> to use</param>
    /// <param name="logLevel">The <see cref="LogLevel"/> to use (should be the same as used in the constructor)</param>
    /// <param name="eventId">The <see cref="EventId"/> to use</param>
    /// <param name="exception">The <see cref="Exception"/> to log</param>
    /// <param name="logHandler">The compiler-constructed <see cref="InterpolatedLogHandler"/>. Just write your <c>$"Log {message}"</c></param>
    public static void LogEx(
        this ILogger logger,
        LogLevel logLevel,
        EventId eventId,
        Exception? exception,
        [InterpolatedStringHandlerArgument("logger", "logLevel")]
        ref InterpolatedLogHandler logHandler)
    {
        logHandler.LogAndClear(logger, logLevel, eventId, exception);
    }

    /// <summary>
    /// String interpolation handler for the <c>LogEx</c>-functions. To be used by the compiler.
    /// </summary>
    [InterpolatedStringHandler]
    public ref struct InterpolatedLogHandler
    {
        private readonly bool _shouldAppend;
        private readonly StringBuilder _messageBuilder;
        private readonly object?[] _arguments;
        private int _nextArgument = 0;

        /// <summary>
        /// Creates a <see cref="InterpolatedLogHandler"/>. To be used by the compiler.
        /// </summary>
        public InterpolatedLogHandler(int literalLength, int formattedCount, ILogger logger, LogLevel logLevel,
            out bool shouldAppend)
        {
            _shouldAppend = shouldAppend = logger.IsEnabled(logLevel);
            if (shouldAppend)
            {
                _messageBuilder = new StringBuilder(literalLength + AveragePlaceholderLength * formattedCount);
                _arguments = new object[formattedCount];
            }
            else
            {
                _messageBuilder = null!;
                _arguments = Array.Empty<object>();
            }
        }

        /// <summary>
        /// Appends a literal part to the message-format-string
        /// </summary>
        public void AppendLiteral(string value)
        {
            AppendEscaped(_messageBuilder, value);
        }

        /// <summary>
        /// Appends a placeholder to the message-format-string and stores <paramref name="value"/> ar argument
        /// </summary>
        public void AppendFormatted(
            object? value,
            string? format = null,
            [CallerArgumentExpression("value")] string? expression = null)
        {
            AppendPlaceholder(_messageBuilder, expression, format, _nextArgument);
            _arguments[_nextArgument++] = value;
        }

        /// <summary>
        /// Appends a placeholder to the message-format-string and stores <paramref name="value"/> ar argument
        /// </summary>
        public void AppendFormatted(
            object? value,
            int alignment,
            string? format = null,
            [CallerArgumentExpression("value")] string? expression = null)
        {
            AppendPlaceholder(_messageBuilder, expression, alignment, format, _nextArgument);
            _arguments[_nextArgument++] = value;
        }

        /// <summary>
        /// Appends a placeholder to the message-format-string and stores <paramref name="value"/> ar argument
        /// </summary>
        public void AppendFormatted(
            ReadOnlySpan<char> value,
            string? format = null,
            [CallerArgumentExpression("value")] string? expression = null)
        {
            AppendPlaceholder(_messageBuilder, expression, format, _nextArgument);
            _arguments[_nextArgument++] = value.ToString();
        }

        /// <summary>
        /// Appends a placeholder to the message-format-string and stores <paramref name="value"/> ar argument
        /// </summary>
        public void AppendFormatted(
            ReadOnlySpan<char> value,
            int alignment,
            string? format = null,
            [CallerArgumentExpression("value")] string? expression = null)
        {
            AppendPlaceholder(_messageBuilder, expression, alignment, format, _nextArgument);
            _arguments[_nextArgument++] = value.ToString();
        }

        /// <summary>
        /// Send message to <paramref name="logger"/> using
        /// <see cref="M:Microsoft.Extensions.Logging.LoggerExtensions.Log(Microsoft.Extensions.Logging.ILogger,Microsoft.Extensions.Logging.LogLevel,Microsoft.Extensions.Logging.EventId,System.Exception,System.String,System.Object[])"/>. 
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to use</param>
        /// <param name="logLevel">The <see cref="LogLevel"/> to use (should be the same as used in the constructor)</param>
        [SuppressMessage("Usage", "CA2254",
            Justification = "The logged message will always be the same, as always the same strings are appended")]
        public void LogAndClear(ILogger logger, LogLevel logLevel)
        {
            if (_shouldAppend)
            {
                logger.Log(logLevel, _messageBuilder.ToString(), _arguments);
                _messageBuilder.Clear();
            }
        }

        /// <summary>
        /// Send message to <paramref name="logger"/> using
        /// <see cref="M:Microsoft.Extensions.Logging.LoggerExtensions.Log(Microsoft.Extensions.Logging.ILogger,Microsoft.Extensions.Logging.LogLevel,Microsoft.Extensions.Logging.EventId,System.Exception,System.String,System.Object[])"/>. 
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to use</param>
        /// <param name="logLevel">The <see cref="LogLevel"/> to use (should be the same as used in the constructor)</param>
        /// <param name="eventId">The <see cref="EventId"/> to use</param>
        [SuppressMessage("Usage", "CA2254",
            Justification = "The logged message will always be the same, as always the same strings are appended")]
        public void LogAndClear(ILogger logger, LogLevel logLevel, EventId eventId)
        {
            if (_shouldAppend)
            {
                logger.Log(logLevel, eventId, _messageBuilder.ToString(), _arguments);
                _messageBuilder.Clear();
            }
        }

        /// <summary>
        /// Send message to <paramref name="logger"/> using
        /// <see cref="M:Microsoft.Extensions.Logging.LoggerExtensions.Log(Microsoft.Extensions.Logging.ILogger,Microsoft.Extensions.Logging.LogLevel,System.Exception,System.String,System.Object[])"/>. 
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to use</param>
        /// <param name="logLevel">The <see cref="LogLevel"/> to use (should be the same as used in the constructor)</param>
        /// <param name="exception">The <see cref="Exception"/> to log</param>
        [SuppressMessage("Usage", "CA2254",
            Justification = "The logged message will always be the same, as always the same strings are appended")]
        public void LogAndClear(ILogger logger, LogLevel logLevel, Exception? exception)
        {
            if (_shouldAppend)
            {
                logger.Log(logLevel, exception, _messageBuilder.ToString(), _arguments);
                _messageBuilder.Clear();
            }
        }

        /// <summary>
        /// Send message to <paramref name="logger"/> using
        /// <see cref="M:Microsoft.Extensions.Logging.LoggerExtensions.Log(Microsoft.Extensions.Logging.ILogger,Microsoft.Extensions.Logging.LogLevel,Microsoft.Extensions.Logging.EventId,System.Exception,System.String,System.Object[])"/>. 
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to use</param>
        /// <param name="logLevel">The <see cref="LogLevel"/> to use (should be the same as used in the constructor)</param>
        /// <param name="eventId">The <see cref="EventId"/> to use</param>
        /// <param name="exception">The <see cref="Exception"/> to log</param>
        [SuppressMessage("Usage", "CA2254",
            Justification = "The logged message will always be the same, as always the same strings are appended")]
        public void LogAndClear(ILogger logger, LogLevel logLevel, EventId eventId, Exception? exception)
        {
            if (_shouldAppend)
            {
                logger.Log(logLevel, eventId, exception, _messageBuilder.ToString(), _arguments);
                _messageBuilder.Clear();
            }
        }
    }
}