using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.Extensions.Logging;

namespace InterpolatedStringExtensions;

public static partial class LoggerExtensions
{
    /// <summary>
    /// Log the interpolated string as formattable message to <paramref name="logger"/>, if it returns <c>true</c> from
    /// <see cref="ILogger.IsEnabled"/> for <see cref="LogLevel.Trace"/>.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><description>Uses C# 10 compiler-features to let you construct <paramref name="logHandler"/>!</description></item>
    /// <item><description>The placeholders are not evaluated, if the <see cref="LogLevel.Trace"/> is not enabled!</description></item>
    /// <item><description>Everything after the last <c>:</c> in a format-string is used as placeholder in the log-message. That means, that you need to type out a placeholder, if you use custom formats containing <c>:</c></description></item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// logger.LogTraceEx($"It is currently {GetTime():HH:mm:ss:logTime}!");
    /// </code>
    /// will have the same effect as
    /// <code>
    /// logger.Log("It is currently {logTime:HH:mm:ss}!", new object?[] {GetTime()});
    /// </code>
    /// if <see cref="LogLevel.Trace"/> is enabled.
    /// If <see cref="LogLevel.Trace"/> is not enabled, <c>GetTime()</c> is not called.
    /// </example>
    /// <param name="logger">The <see cref="ILogger"/> to use</param>
    /// <param name="logHandler">The compiler-constructed <see cref="InterpolatedTraceLogHandler"/>. Just write your <c>$"Log {message}"</c></param>
    public static void LogTraceEx(
        this ILogger logger,
        [InterpolatedStringHandlerArgument("logger")]
        ref InterpolatedTraceLogHandler logHandler)
    {
        logHandler.LogAndClear(logger);
    }

    /// <summary>
    /// Log the interpolated string as formattable message to <paramref name="logger"/>, if it returns <c>true</c> from
    /// <see cref="ILogger.IsEnabled"/> for <see cref="LogLevel.Trace"/>.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><description>Uses C# 10 compiler-features to let you construct <paramref name="logHandler"/>!</description></item>
    /// <item><description>The placeholders are not evaluated, if the <see cref="LogLevel.Trace"/> is not enabled!</description></item>
    /// <item><description>Everything after the last <c>:</c> in a format-string is used as placeholder in the log-message. That means, that you need to type out a placeholder, if you use custom formats containing <c>:</c></description></item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// logger.LogTraceEx($"It is currently {GetTime():HH:mm:ss:logTime}!");
    /// </code>
    /// will have the same effect as
    /// <code>
    /// logger.Log("It is currently {logTime:HH:mm:ss}!", new object?[] {GetTime()});
    /// </code>
    /// if <see cref="LogLevel.Trace"/> is enabled.
    /// If <see cref="LogLevel.Trace"/> is not enabled, <c>GetTime()</c> is not called.
    /// </example>
    /// <param name="logger">The <see cref="ILogger"/> to use</param>
    /// <param name="eventId">The <see cref="EventId"/> to use</param>
    /// <param name="logHandler">The compiler-constructed <see cref="InterpolatedTraceLogHandler"/>. Just write your <c>$"Log {message}"</c></param>
    public static void LogTraceEx(
        this ILogger logger,
        EventId eventId,
        [InterpolatedStringHandlerArgument("logger")]
        ref InterpolatedTraceLogHandler logHandler)
    {
        logHandler.LogAndClear(logger, eventId);
    }

    /// <summary>
    /// Log the interpolated string as formattable message to <paramref name="logger"/>, if it returns <c>true</c> from
    /// <see cref="ILogger.IsEnabled"/> for <see cref="LogLevel.Trace"/>.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><description>Uses C# 10 compiler-features to let you construct <paramref name="logHandler"/>!</description></item>
    /// <item><description>The placeholders are not evaluated, if the <see cref="LogLevel.Trace"/> is not enabled!</description></item>
    /// <item><description>Everything after the last <c>:</c> in a format-string is used as placeholder in the log-message. That means, that you need to type out a placeholder, if you use custom formats containing <c>:</c></description></item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// logger.LogTraceEx($"It is currently {GetTime():HH:mm:ss:logTime}!");
    /// </code>
    /// will have the same effect as
    /// <code>
    /// logger.Log("It is currently {logTime:HH:mm:ss}!", new object?[] {GetTime()});
    /// </code>
    /// if <see cref="LogLevel.Trace"/> is enabled.
    /// If <see cref="LogLevel.Trace"/> is not enabled, <c>GetTime()</c> is not called.
    /// </example>
    /// <param name="logger">The <see cref="ILogger"/> to use</param>
    /// <param name="exception">The <see cref="Exception"/> to log</param>
    /// <param name="logHandler">The compiler-constructed <see cref="InterpolatedTraceLogHandler"/>. Just write your <c>$"Log {message}"</c></param>
    public static void LogTraceEx(
        this ILogger logger,
        Exception? exception,
        [InterpolatedStringHandlerArgument("logger")]
        ref InterpolatedTraceLogHandler logHandler)
    {
        logHandler.LogAndClear(logger, exception);
    }

    /// <summary>
    /// Log the interpolated string as formattable message to <paramref name="logger"/>, if it returns <c>true</c> from
    /// <see cref="ILogger.IsEnabled"/> for <see cref="LogLevel.Trace"/>.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><description>Uses C# 10 compiler-features to let you construct <paramref name="logHandler"/>!</description></item>
    /// <item><description>The placeholders are not evaluated, if the <see cref="LogLevel.Trace"/> is not enabled!</description></item>
    /// <item><description>Everything after the last <c>:</c> in a format-string is used as placeholder in the log-message. That means, that you need to type out a placeholder, if you use custom formats containing <c>:</c></description></item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// logger.LogTraceEx($"It is currently {GetTime():HH:mm:ss:logTime}!");
    /// </code>
    /// will have the same effect as
    /// <code>
    /// logger.Log("It is currently {logTime:HH:mm:ss}!", new object?[] {GetTime()});
    /// </code>
    /// if <see cref="LogLevel.Trace"/> is enabled.
    /// If <see cref="LogLevel.Trace"/> is not enabled, <c>GetTime()</c> is not called.
    /// </example>
    /// <param name="logger">The <see cref="ILogger"/> to use</param>
    /// <param name="eventId">The <see cref="EventId"/> to use</param>
    /// <param name="exception">The <see cref="Exception"/> to log</param>
    /// <param name="logHandler">The compiler-constructed <see cref="InterpolatedTraceLogHandler"/>. Just write your <c>$"Log {message}"</c></param>
    public static void LogTraceEx(
        this ILogger logger,
        EventId eventId,
        Exception? exception,
        [InterpolatedStringHandlerArgument("logger")]
        ref InterpolatedTraceLogHandler logHandler)
    {
        logHandler.LogAndClear(logger, eventId, exception);
    }

    /// <summary>
    /// String interpolation handler for the <c>LogTraceEx</c>-functions. To be used by the compiler.
    /// </summary>
    [InterpolatedStringHandler]
    public ref struct InterpolatedTraceLogHandler
    {
        private readonly bool _shouldAppend;
        private readonly StringBuilder _messageBuilder;
        private readonly object?[] _arguments;
        private int _nextArgument = 0;

        /// <summary>
        /// Creates a <see cref="InterpolatedTraceLogHandler"/>. To be used by the compiler.
        /// </summary>
        public InterpolatedTraceLogHandler(int literalLength, int formattedCount, ILogger logger,
            out bool shouldAppend)
        {
            _shouldAppend = shouldAppend = logger.IsEnabled(LogLevel.Trace);
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
        /// <see cref="M:Microsoft.Extensions.Logging.LoggerExtensions.LogTrace(Microsoft.Extensions.Logging.ILogger,Microsoft.Extensions.Logging.EventId,System.Exception,System.String,System.Object[])"/>. 
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to use</param>
        [SuppressMessage("Usage", "CA2254",
            Justification = "The logged message will always be the same, as always the same strings are appended")]
        public void LogAndClear(ILogger logger)
        {
            if (_shouldAppend)
            {
                logger.LogTrace(_messageBuilder.ToString(), _arguments);
                _messageBuilder.Clear();
            }
        }

        /// <summary>
        /// Send message to <paramref name="logger"/> using
        /// <see cref="M:Microsoft.Extensions.Logging.LoggerExtensions.LogTrace(Microsoft.Extensions.Logging.ILogger,Microsoft.Extensions.Logging.EventId,System.Exception,System.String,System.Object[])"/>. 
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to use</param>
        /// <param name="eventId">The <see cref="EventId"/> to use</param>
        [SuppressMessage("Usage", "CA2254",
            Justification = "The logged message will always be the same, as always the same strings are appended")]
        public void LogAndClear(ILogger logger, EventId eventId)
        {
            if (_shouldAppend)
            {
                logger.LogTrace(eventId, _messageBuilder.ToString(), _arguments);
                _messageBuilder.Clear();
            }
        }

        /// <summary>
        /// Send message to <paramref name="logger"/> using
        /// <see cref="M:Microsoft.Extensions.Logging.LoggerExtensions.LogTrace(Microsoft.Extensions.Logging.ILogger,System.Exception,System.String,System.Object[])"/>. 
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to use</param>
        /// <param name="exception">The <see cref="Exception"/> to log</param>
        [SuppressMessage("Usage", "CA2254",
            Justification = "The logged message will always be the same, as always the same strings are appended")]
        public void LogAndClear(ILogger logger, Exception? exception)
        {
            if (_shouldAppend)
            {
                logger.LogTrace(exception, _messageBuilder.ToString(), _arguments);
                _messageBuilder.Clear();
            }
        }

        /// <summary>
        /// Send message to <paramref name="logger"/> using
        /// <see cref="M:Microsoft.Extensions.Logging.LoggerExtensions.LogTrace(Microsoft.Extensions.Logging.ILogger,Microsoft.Extensions.Logging.EventId,System.Exception,System.String,System.Object[])"/>. 
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to use</param>
        /// <param name="eventId">The <see cref="EventId"/> to use</param>
        /// <param name="exception">The <see cref="Exception"/> to log</param>
        [SuppressMessage("Usage", "CA2254",
            Justification = "The logged message will always be the same, as always the same strings are appended")]
        public void LogAndClear(ILogger logger, EventId eventId, Exception? exception)
        {
            if (_shouldAppend)
            {
                logger.LogTrace(eventId, exception, _messageBuilder.ToString(), _arguments);
                _messageBuilder.Clear();
            }
        }
    }

    /// <summary>
    /// Log the interpolated string as formattable message to <paramref name="logger"/>, if it returns <c>true</c> from
    /// <see cref="ILogger.IsEnabled"/> for <see cref="LogLevel.Debug"/>.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><description>Uses C# 10 compiler-features to let you construct <paramref name="logHandler"/>!</description></item>
    /// <item><description>The placeholders are not evaluated, if the <see cref="LogLevel.Debug"/> is not enabled!</description></item>
    /// <item><description>Everything after the last <c>:</c> in a format-string is used as placeholder in the log-message. That means, that you need to type out a placeholder, if you use custom formats containing <c>:</c></description></item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// logger.LogDebugEx($"It is currently {GetTime():HH:mm:ss:logTime}!");
    /// </code>
    /// will have the same effect as
    /// <code>
    /// logger.Log("It is currently {logTime:HH:mm:ss}!", new object?[] {GetTime()});
    /// </code>
    /// if <see cref="LogLevel.Debug"/> is enabled.
    /// If <see cref="LogLevel.Debug"/> is not enabled, <c>GetTime()</c> is not called.
    /// </example>
    /// <param name="logger">The <see cref="ILogger"/> to use</param>
    /// <param name="logHandler">The compiler-constructed <see cref="InterpolatedDebugLogHandler"/>. Just write your <c>$"Log {message}"</c></param>
    public static void LogDebugEx(
        this ILogger logger,
        [InterpolatedStringHandlerArgument("logger")]
        ref InterpolatedDebugLogHandler logHandler)
    {
        logHandler.LogAndClear(logger);
    }

    /// <summary>
    /// Log the interpolated string as formattable message to <paramref name="logger"/>, if it returns <c>true</c> from
    /// <see cref="ILogger.IsEnabled"/> for <see cref="LogLevel.Debug"/>.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><description>Uses C# 10 compiler-features to let you construct <paramref name="logHandler"/>!</description></item>
    /// <item><description>The placeholders are not evaluated, if the <see cref="LogLevel.Debug"/> is not enabled!</description></item>
    /// <item><description>Everything after the last <c>:</c> in a format-string is used as placeholder in the log-message. That means, that you need to type out a placeholder, if you use custom formats containing <c>:</c></description></item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// logger.LogDebugEx($"It is currently {GetTime():HH:mm:ss:logTime}!");
    /// </code>
    /// will have the same effect as
    /// <code>
    /// logger.Log("It is currently {logTime:HH:mm:ss}!", new object?[] {GetTime()});
    /// </code>
    /// if <see cref="LogLevel.Debug"/> is enabled.
    /// If <see cref="LogLevel.Debug"/> is not enabled, <c>GetTime()</c> is not called.
    /// </example>
    /// <param name="logger">The <see cref="ILogger"/> to use</param>
    /// <param name="eventId">The <see cref="EventId"/> to use</param>
    /// <param name="logHandler">The compiler-constructed <see cref="InterpolatedDebugLogHandler"/>. Just write your <c>$"Log {message}"</c></param>
    public static void LogDebugEx(
        this ILogger logger,
        EventId eventId,
        [InterpolatedStringHandlerArgument("logger")]
        ref InterpolatedDebugLogHandler logHandler)
    {
        logHandler.LogAndClear(logger, eventId);
    }

    /// <summary>
    /// Log the interpolated string as formattable message to <paramref name="logger"/>, if it returns <c>true</c> from
    /// <see cref="ILogger.IsEnabled"/> for <see cref="LogLevel.Debug"/>.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><description>Uses C# 10 compiler-features to let you construct <paramref name="logHandler"/>!</description></item>
    /// <item><description>The placeholders are not evaluated, if the <see cref="LogLevel.Debug"/> is not enabled!</description></item>
    /// <item><description>Everything after the last <c>:</c> in a format-string is used as placeholder in the log-message. That means, that you need to type out a placeholder, if you use custom formats containing <c>:</c></description></item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// logger.LogDebugEx($"It is currently {GetTime():HH:mm:ss:logTime}!");
    /// </code>
    /// will have the same effect as
    /// <code>
    /// logger.Log("It is currently {logTime:HH:mm:ss}!", new object?[] {GetTime()});
    /// </code>
    /// if <see cref="LogLevel.Debug"/> is enabled.
    /// If <see cref="LogLevel.Debug"/> is not enabled, <c>GetTime()</c> is not called.
    /// </example>
    /// <param name="logger">The <see cref="ILogger"/> to use</param>
    /// <param name="exception">The <see cref="Exception"/> to log</param>
    /// <param name="logHandler">The compiler-constructed <see cref="InterpolatedDebugLogHandler"/>. Just write your <c>$"Log {message}"</c></param>
    public static void LogDebugEx(
        this ILogger logger,
        Exception? exception,
        [InterpolatedStringHandlerArgument("logger")]
        ref InterpolatedDebugLogHandler logHandler)
    {
        logHandler.LogAndClear(logger, exception);
    }

    /// <summary>
    /// Log the interpolated string as formattable message to <paramref name="logger"/>, if it returns <c>true</c> from
    /// <see cref="ILogger.IsEnabled"/> for <see cref="LogLevel.Debug"/>.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><description>Uses C# 10 compiler-features to let you construct <paramref name="logHandler"/>!</description></item>
    /// <item><description>The placeholders are not evaluated, if the <see cref="LogLevel.Debug"/> is not enabled!</description></item>
    /// <item><description>Everything after the last <c>:</c> in a format-string is used as placeholder in the log-message. That means, that you need to type out a placeholder, if you use custom formats containing <c>:</c></description></item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// logger.LogDebugEx($"It is currently {GetTime():HH:mm:ss:logTime}!");
    /// </code>
    /// will have the same effect as
    /// <code>
    /// logger.Log("It is currently {logTime:HH:mm:ss}!", new object?[] {GetTime()});
    /// </code>
    /// if <see cref="LogLevel.Debug"/> is enabled.
    /// If <see cref="LogLevel.Debug"/> is not enabled, <c>GetTime()</c> is not called.
    /// </example>
    /// <param name="logger">The <see cref="ILogger"/> to use</param>
    /// <param name="eventId">The <see cref="EventId"/> to use</param>
    /// <param name="exception">The <see cref="Exception"/> to log</param>
    /// <param name="logHandler">The compiler-constructed <see cref="InterpolatedDebugLogHandler"/>. Just write your <c>$"Log {message}"</c></param>
    public static void LogDebugEx(
        this ILogger logger,
        EventId eventId,
        Exception? exception,
        [InterpolatedStringHandlerArgument("logger")]
        ref InterpolatedDebugLogHandler logHandler)
    {
        logHandler.LogAndClear(logger, eventId, exception);
    }

    /// <summary>
    /// String interpolation handler for the <c>LogDebugEx</c>-functions. To be used by the compiler.
    /// </summary>
    [InterpolatedStringHandler]
    public ref struct InterpolatedDebugLogHandler
    {
        private readonly bool _shouldAppend;
        private readonly StringBuilder _messageBuilder;
        private readonly object?[] _arguments;
        private int _nextArgument = 0;

        /// <summary>
        /// Creates a <see cref="InterpolatedDebugLogHandler"/>. To be used by the compiler.
        /// </summary>
        public InterpolatedDebugLogHandler(int literalLength, int formattedCount, ILogger logger,
            out bool shouldAppend)
        {
            _shouldAppend = shouldAppend = logger.IsEnabled(LogLevel.Debug);
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
        /// <see cref="M:Microsoft.Extensions.Logging.LoggerExtensions.LogDebug(Microsoft.Extensions.Logging.ILogger,Microsoft.Extensions.Logging.EventId,System.Exception,System.String,System.Object[])"/>. 
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to use</param>
        [SuppressMessage("Usage", "CA2254",
            Justification = "The logged message will always be the same, as always the same strings are appended")]
        public void LogAndClear(ILogger logger)
        {
            if (_shouldAppend)
            {
                logger.LogDebug(_messageBuilder.ToString(), _arguments);
                _messageBuilder.Clear();
            }
        }

        /// <summary>
        /// Send message to <paramref name="logger"/> using
        /// <see cref="M:Microsoft.Extensions.Logging.LoggerExtensions.LogDebug(Microsoft.Extensions.Logging.ILogger,Microsoft.Extensions.Logging.EventId,System.Exception,System.String,System.Object[])"/>. 
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to use</param>
        /// <param name="eventId">The <see cref="EventId"/> to use</param>
        [SuppressMessage("Usage", "CA2254",
            Justification = "The logged message will always be the same, as always the same strings are appended")]
        public void LogAndClear(ILogger logger, EventId eventId)
        {
            if (_shouldAppend)
            {
                logger.LogDebug(eventId, _messageBuilder.ToString(), _arguments);
                _messageBuilder.Clear();
            }
        }

        /// <summary>
        /// Send message to <paramref name="logger"/> using
        /// <see cref="M:Microsoft.Extensions.Logging.LoggerExtensions.LogDebug(Microsoft.Extensions.Logging.ILogger,System.Exception,System.String,System.Object[])"/>. 
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to use</param>
        /// <param name="exception">The <see cref="Exception"/> to log</param>
        [SuppressMessage("Usage", "CA2254",
            Justification = "The logged message will always be the same, as always the same strings are appended")]
        public void LogAndClear(ILogger logger, Exception? exception)
        {
            if (_shouldAppend)
            {
                logger.LogDebug(exception, _messageBuilder.ToString(), _arguments);
                _messageBuilder.Clear();
            }
        }

        /// <summary>
        /// Send message to <paramref name="logger"/> using
        /// <see cref="M:Microsoft.Extensions.Logging.LoggerExtensions.LogDebug(Microsoft.Extensions.Logging.ILogger,Microsoft.Extensions.Logging.EventId,System.Exception,System.String,System.Object[])"/>. 
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to use</param>
        /// <param name="eventId">The <see cref="EventId"/> to use</param>
        /// <param name="exception">The <see cref="Exception"/> to log</param>
        [SuppressMessage("Usage", "CA2254",
            Justification = "The logged message will always be the same, as always the same strings are appended")]
        public void LogAndClear(ILogger logger, EventId eventId, Exception? exception)
        {
            if (_shouldAppend)
            {
                logger.LogDebug(eventId, exception, _messageBuilder.ToString(), _arguments);
                _messageBuilder.Clear();
            }
        }
    }

    /// <summary>
    /// Log the interpolated string as formattable message to <paramref name="logger"/>, if it returns <c>true</c> from
    /// <see cref="ILogger.IsEnabled"/> for <see cref="LogLevel.Information"/>.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><description>Uses C# 10 compiler-features to let you construct <paramref name="logHandler"/>!</description></item>
    /// <item><description>The placeholders are not evaluated, if the <see cref="LogLevel.Information"/> is not enabled!</description></item>
    /// <item><description>Everything after the last <c>:</c> in a format-string is used as placeholder in the log-message. That means, that you need to type out a placeholder, if you use custom formats containing <c>:</c></description></item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// logger.LogInformationEx($"It is currently {GetTime():HH:mm:ss:logTime}!");
    /// </code>
    /// will have the same effect as
    /// <code>
    /// logger.Log("It is currently {logTime:HH:mm:ss}!", new object?[] {GetTime()});
    /// </code>
    /// if <see cref="LogLevel.Information"/> is enabled.
    /// If <see cref="LogLevel.Information"/> is not enabled, <c>GetTime()</c> is not called.
    /// </example>
    /// <param name="logger">The <see cref="ILogger"/> to use</param>
    /// <param name="logHandler">The compiler-constructed <see cref="InterpolatedInformationLogHandler"/>. Just write your <c>$"Log {message}"</c></param>
    public static void LogInformationEx(
        this ILogger logger,
        [InterpolatedStringHandlerArgument("logger")]
        ref InterpolatedInformationLogHandler logHandler)
    {
        logHandler.LogAndClear(logger);
    }

    /// <summary>
    /// Log the interpolated string as formattable message to <paramref name="logger"/>, if it returns <c>true</c> from
    /// <see cref="ILogger.IsEnabled"/> for <see cref="LogLevel.Information"/>.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><description>Uses C# 10 compiler-features to let you construct <paramref name="logHandler"/>!</description></item>
    /// <item><description>The placeholders are not evaluated, if the <see cref="LogLevel.Information"/> is not enabled!</description></item>
    /// <item><description>Everything after the last <c>:</c> in a format-string is used as placeholder in the log-message. That means, that you need to type out a placeholder, if you use custom formats containing <c>:</c></description></item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// logger.LogInformationEx($"It is currently {GetTime():HH:mm:ss:logTime}!");
    /// </code>
    /// will have the same effect as
    /// <code>
    /// logger.Log("It is currently {logTime:HH:mm:ss}!", new object?[] {GetTime()});
    /// </code>
    /// if <see cref="LogLevel.Information"/> is enabled.
    /// If <see cref="LogLevel.Information"/> is not enabled, <c>GetTime()</c> is not called.
    /// </example>
    /// <param name="logger">The <see cref="ILogger"/> to use</param>
    /// <param name="eventId">The <see cref="EventId"/> to use</param>
    /// <param name="logHandler">The compiler-constructed <see cref="InterpolatedInformationLogHandler"/>. Just write your <c>$"Log {message}"</c></param>
    public static void LogInformationEx(
        this ILogger logger,
        EventId eventId,
        [InterpolatedStringHandlerArgument("logger")]
        ref InterpolatedInformationLogHandler logHandler)
    {
        logHandler.LogAndClear(logger, eventId);
    }

    /// <summary>
    /// Log the interpolated string as formattable message to <paramref name="logger"/>, if it returns <c>true</c> from
    /// <see cref="ILogger.IsEnabled"/> for <see cref="LogLevel.Information"/>.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><description>Uses C# 10 compiler-features to let you construct <paramref name="logHandler"/>!</description></item>
    /// <item><description>The placeholders are not evaluated, if the <see cref="LogLevel.Information"/> is not enabled!</description></item>
    /// <item><description>Everything after the last <c>:</c> in a format-string is used as placeholder in the log-message. That means, that you need to type out a placeholder, if you use custom formats containing <c>:</c></description></item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// logger.LogInformationEx($"It is currently {GetTime():HH:mm:ss:logTime}!");
    /// </code>
    /// will have the same effect as
    /// <code>
    /// logger.Log("It is currently {logTime:HH:mm:ss}!", new object?[] {GetTime()});
    /// </code>
    /// if <see cref="LogLevel.Information"/> is enabled.
    /// If <see cref="LogLevel.Information"/> is not enabled, <c>GetTime()</c> is not called.
    /// </example>
    /// <param name="logger">The <see cref="ILogger"/> to use</param>
    /// <param name="exception">The <see cref="Exception"/> to log</param>
    /// <param name="logHandler">The compiler-constructed <see cref="InterpolatedInformationLogHandler"/>. Just write your <c>$"Log {message}"</c></param>
    public static void LogInformationEx(
        this ILogger logger,
        Exception? exception,
        [InterpolatedStringHandlerArgument("logger")]
        ref InterpolatedInformationLogHandler logHandler)
    {
        logHandler.LogAndClear(logger, exception);
    }

    /// <summary>
    /// Log the interpolated string as formattable message to <paramref name="logger"/>, if it returns <c>true</c> from
    /// <see cref="ILogger.IsEnabled"/> for <see cref="LogLevel.Information"/>.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><description>Uses C# 10 compiler-features to let you construct <paramref name="logHandler"/>!</description></item>
    /// <item><description>The placeholders are not evaluated, if the <see cref="LogLevel.Information"/> is not enabled!</description></item>
    /// <item><description>Everything after the last <c>:</c> in a format-string is used as placeholder in the log-message. That means, that you need to type out a placeholder, if you use custom formats containing <c>:</c></description></item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// logger.LogInformationEx($"It is currently {GetTime():HH:mm:ss:logTime}!");
    /// </code>
    /// will have the same effect as
    /// <code>
    /// logger.Log("It is currently {logTime:HH:mm:ss}!", new object?[] {GetTime()});
    /// </code>
    /// if <see cref="LogLevel.Information"/> is enabled.
    /// If <see cref="LogLevel.Information"/> is not enabled, <c>GetTime()</c> is not called.
    /// </example>
    /// <param name="logger">The <see cref="ILogger"/> to use</param>
    /// <param name="eventId">The <see cref="EventId"/> to use</param>
    /// <param name="exception">The <see cref="Exception"/> to log</param>
    /// <param name="logHandler">The compiler-constructed <see cref="InterpolatedInformationLogHandler"/>. Just write your <c>$"Log {message}"</c></param>
    public static void LogInformationEx(
        this ILogger logger,
        EventId eventId,
        Exception? exception,
        [InterpolatedStringHandlerArgument("logger")]
        ref InterpolatedInformationLogHandler logHandler)
    {
        logHandler.LogAndClear(logger, eventId, exception);
    }

    /// <summary>
    /// String interpolation handler for the <c>LogInformationEx</c>-functions. To be used by the compiler.
    /// </summary>
    [InterpolatedStringHandler]
    public ref struct InterpolatedInformationLogHandler
    {
        private readonly bool _shouldAppend;
        private readonly StringBuilder _messageBuilder;
        private readonly object?[] _arguments;
        private int _nextArgument = 0;

        /// <summary>
        /// Creates a <see cref="InterpolatedInformationLogHandler"/>. To be used by the compiler.
        /// </summary>
        public InterpolatedInformationLogHandler(int literalLength, int formattedCount, ILogger logger,
            out bool shouldAppend)
        {
            _shouldAppend = shouldAppend = logger.IsEnabled(LogLevel.Information);
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
        /// <see cref="M:Microsoft.Extensions.Logging.LoggerExtensions.LogInformation(Microsoft.Extensions.Logging.ILogger,Microsoft.Extensions.Logging.EventId,System.Exception,System.String,System.Object[])"/>. 
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to use</param>
        [SuppressMessage("Usage", "CA2254",
            Justification = "The logged message will always be the same, as always the same strings are appended")]
        public void LogAndClear(ILogger logger)
        {
            if (_shouldAppend)
            {
                logger.LogInformation(_messageBuilder.ToString(), _arguments);
                _messageBuilder.Clear();
            }
        }

        /// <summary>
        /// Send message to <paramref name="logger"/> using
        /// <see cref="M:Microsoft.Extensions.Logging.LoggerExtensions.LogInformation(Microsoft.Extensions.Logging.ILogger,Microsoft.Extensions.Logging.EventId,System.Exception,System.String,System.Object[])"/>. 
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to use</param>
        /// <param name="eventId">The <see cref="EventId"/> to use</param>
        [SuppressMessage("Usage", "CA2254",
            Justification = "The logged message will always be the same, as always the same strings are appended")]
        public void LogAndClear(ILogger logger, EventId eventId)
        {
            if (_shouldAppend)
            {
                logger.LogInformation(eventId, _messageBuilder.ToString(), _arguments);
                _messageBuilder.Clear();
            }
        }

        /// <summary>
        /// Send message to <paramref name="logger"/> using
        /// <see cref="M:Microsoft.Extensions.Logging.LoggerExtensions.LogInformation(Microsoft.Extensions.Logging.ILogger,System.Exception,System.String,System.Object[])"/>. 
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to use</param>
        /// <param name="exception">The <see cref="Exception"/> to log</param>
        [SuppressMessage("Usage", "CA2254",
            Justification = "The logged message will always be the same, as always the same strings are appended")]
        public void LogAndClear(ILogger logger, Exception? exception)
        {
            if (_shouldAppend)
            {
                logger.LogInformation(exception, _messageBuilder.ToString(), _arguments);
                _messageBuilder.Clear();
            }
        }

        /// <summary>
        /// Send message to <paramref name="logger"/> using
        /// <see cref="M:Microsoft.Extensions.Logging.LoggerExtensions.LogInformation(Microsoft.Extensions.Logging.ILogger,Microsoft.Extensions.Logging.EventId,System.Exception,System.String,System.Object[])"/>. 
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to use</param>
        /// <param name="eventId">The <see cref="EventId"/> to use</param>
        /// <param name="exception">The <see cref="Exception"/> to log</param>
        [SuppressMessage("Usage", "CA2254",
            Justification = "The logged message will always be the same, as always the same strings are appended")]
        public void LogAndClear(ILogger logger, EventId eventId, Exception? exception)
        {
            if (_shouldAppend)
            {
                logger.LogInformation(eventId, exception, _messageBuilder.ToString(), _arguments);
                _messageBuilder.Clear();
            }
        }
    }

    /// <summary>
    /// Log the interpolated string as formattable message to <paramref name="logger"/>, if it returns <c>true</c> from
    /// <see cref="ILogger.IsEnabled"/> for <see cref="LogLevel.Warning"/>.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><description>Uses C# 10 compiler-features to let you construct <paramref name="logHandler"/>!</description></item>
    /// <item><description>The placeholders are not evaluated, if the <see cref="LogLevel.Warning"/> is not enabled!</description></item>
    /// <item><description>Everything after the last <c>:</c> in a format-string is used as placeholder in the log-message. That means, that you need to type out a placeholder, if you use custom formats containing <c>:</c></description></item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// logger.LogWarningEx($"It is currently {GetTime():HH:mm:ss:logTime}!");
    /// </code>
    /// will have the same effect as
    /// <code>
    /// logger.Log("It is currently {logTime:HH:mm:ss}!", new object?[] {GetTime()});
    /// </code>
    /// if <see cref="LogLevel.Warning"/> is enabled.
    /// If <see cref="LogLevel.Warning"/> is not enabled, <c>GetTime()</c> is not called.
    /// </example>
    /// <param name="logger">The <see cref="ILogger"/> to use</param>
    /// <param name="logHandler">The compiler-constructed <see cref="InterpolatedWarningLogHandler"/>. Just write your <c>$"Log {message}"</c></param>
    public static void LogWarningEx(
        this ILogger logger,
        [InterpolatedStringHandlerArgument("logger")]
        ref InterpolatedWarningLogHandler logHandler)
    {
        logHandler.LogAndClear(logger);
    }

    /// <summary>
    /// Log the interpolated string as formattable message to <paramref name="logger"/>, if it returns <c>true</c> from
    /// <see cref="ILogger.IsEnabled"/> for <see cref="LogLevel.Warning"/>.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><description>Uses C# 10 compiler-features to let you construct <paramref name="logHandler"/>!</description></item>
    /// <item><description>The placeholders are not evaluated, if the <see cref="LogLevel.Warning"/> is not enabled!</description></item>
    /// <item><description>Everything after the last <c>:</c> in a format-string is used as placeholder in the log-message. That means, that you need to type out a placeholder, if you use custom formats containing <c>:</c></description></item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// logger.LogWarningEx($"It is currently {GetTime():HH:mm:ss:logTime}!");
    /// </code>
    /// will have the same effect as
    /// <code>
    /// logger.Log("It is currently {logTime:HH:mm:ss}!", new object?[] {GetTime()});
    /// </code>
    /// if <see cref="LogLevel.Warning"/> is enabled.
    /// If <see cref="LogLevel.Warning"/> is not enabled, <c>GetTime()</c> is not called.
    /// </example>
    /// <param name="logger">The <see cref="ILogger"/> to use</param>
    /// <param name="eventId">The <see cref="EventId"/> to use</param>
    /// <param name="logHandler">The compiler-constructed <see cref="InterpolatedWarningLogHandler"/>. Just write your <c>$"Log {message}"</c></param>
    public static void LogWarningEx(
        this ILogger logger,
        EventId eventId,
        [InterpolatedStringHandlerArgument("logger")]
        ref InterpolatedWarningLogHandler logHandler)
    {
        logHandler.LogAndClear(logger, eventId);
    }

    /// <summary>
    /// Log the interpolated string as formattable message to <paramref name="logger"/>, if it returns <c>true</c> from
    /// <see cref="ILogger.IsEnabled"/> for <see cref="LogLevel.Warning"/>.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><description>Uses C# 10 compiler-features to let you construct <paramref name="logHandler"/>!</description></item>
    /// <item><description>The placeholders are not evaluated, if the <see cref="LogLevel.Warning"/> is not enabled!</description></item>
    /// <item><description>Everything after the last <c>:</c> in a format-string is used as placeholder in the log-message. That means, that you need to type out a placeholder, if you use custom formats containing <c>:</c></description></item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// logger.LogWarningEx($"It is currently {GetTime():HH:mm:ss:logTime}!");
    /// </code>
    /// will have the same effect as
    /// <code>
    /// logger.Log("It is currently {logTime:HH:mm:ss}!", new object?[] {GetTime()});
    /// </code>
    /// if <see cref="LogLevel.Warning"/> is enabled.
    /// If <see cref="LogLevel.Warning"/> is not enabled, <c>GetTime()</c> is not called.
    /// </example>
    /// <param name="logger">The <see cref="ILogger"/> to use</param>
    /// <param name="exception">The <see cref="Exception"/> to log</param>
    /// <param name="logHandler">The compiler-constructed <see cref="InterpolatedWarningLogHandler"/>. Just write your <c>$"Log {message}"</c></param>
    public static void LogWarningEx(
        this ILogger logger,
        Exception? exception,
        [InterpolatedStringHandlerArgument("logger")]
        ref InterpolatedWarningLogHandler logHandler)
    {
        logHandler.LogAndClear(logger, exception);
    }

    /// <summary>
    /// Log the interpolated string as formattable message to <paramref name="logger"/>, if it returns <c>true</c> from
    /// <see cref="ILogger.IsEnabled"/> for <see cref="LogLevel.Warning"/>.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><description>Uses C# 10 compiler-features to let you construct <paramref name="logHandler"/>!</description></item>
    /// <item><description>The placeholders are not evaluated, if the <see cref="LogLevel.Warning"/> is not enabled!</description></item>
    /// <item><description>Everything after the last <c>:</c> in a format-string is used as placeholder in the log-message. That means, that you need to type out a placeholder, if you use custom formats containing <c>:</c></description></item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// logger.LogWarningEx($"It is currently {GetTime():HH:mm:ss:logTime}!");
    /// </code>
    /// will have the same effect as
    /// <code>
    /// logger.Log("It is currently {logTime:HH:mm:ss}!", new object?[] {GetTime()});
    /// </code>
    /// if <see cref="LogLevel.Warning"/> is enabled.
    /// If <see cref="LogLevel.Warning"/> is not enabled, <c>GetTime()</c> is not called.
    /// </example>
    /// <param name="logger">The <see cref="ILogger"/> to use</param>
    /// <param name="eventId">The <see cref="EventId"/> to use</param>
    /// <param name="exception">The <see cref="Exception"/> to log</param>
    /// <param name="logHandler">The compiler-constructed <see cref="InterpolatedWarningLogHandler"/>. Just write your <c>$"Log {message}"</c></param>
    public static void LogWarningEx(
        this ILogger logger,
        EventId eventId,
        Exception? exception,
        [InterpolatedStringHandlerArgument("logger")]
        ref InterpolatedWarningLogHandler logHandler)
    {
        logHandler.LogAndClear(logger, eventId, exception);
    }

    /// <summary>
    /// String interpolation handler for the <c>LogWarningEx</c>-functions. To be used by the compiler.
    /// </summary>
    [InterpolatedStringHandler]
    public ref struct InterpolatedWarningLogHandler
    {
        private readonly bool _shouldAppend;
        private readonly StringBuilder _messageBuilder;
        private readonly object?[] _arguments;
        private int _nextArgument = 0;

        /// <summary>
        /// Creates a <see cref="InterpolatedWarningLogHandler"/>. To be used by the compiler.
        /// </summary>
        public InterpolatedWarningLogHandler(int literalLength, int formattedCount, ILogger logger,
            out bool shouldAppend)
        {
            _shouldAppend = shouldAppend = logger.IsEnabled(LogLevel.Warning);
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
        /// <see cref="M:Microsoft.Extensions.Logging.LoggerExtensions.LogWarning(Microsoft.Extensions.Logging.ILogger,Microsoft.Extensions.Logging.EventId,System.Exception,System.String,System.Object[])"/>. 
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to use</param>
        [SuppressMessage("Usage", "CA2254",
            Justification = "The logged message will always be the same, as always the same strings are appended")]
        public void LogAndClear(ILogger logger)
        {
            if (_shouldAppend)
            {
                logger.LogWarning(_messageBuilder.ToString(), _arguments);
                _messageBuilder.Clear();
            }
        }

        /// <summary>
        /// Send message to <paramref name="logger"/> using
        /// <see cref="M:Microsoft.Extensions.Logging.LoggerExtensions.LogWarning(Microsoft.Extensions.Logging.ILogger,Microsoft.Extensions.Logging.EventId,System.Exception,System.String,System.Object[])"/>. 
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to use</param>
        /// <param name="eventId">The <see cref="EventId"/> to use</param>
        [SuppressMessage("Usage", "CA2254",
            Justification = "The logged message will always be the same, as always the same strings are appended")]
        public void LogAndClear(ILogger logger, EventId eventId)
        {
            if (_shouldAppend)
            {
                logger.LogWarning(eventId, _messageBuilder.ToString(), _arguments);
                _messageBuilder.Clear();
            }
        }

        /// <summary>
        /// Send message to <paramref name="logger"/> using
        /// <see cref="M:Microsoft.Extensions.Logging.LoggerExtensions.LogWarning(Microsoft.Extensions.Logging.ILogger,System.Exception,System.String,System.Object[])"/>. 
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to use</param>
        /// <param name="exception">The <see cref="Exception"/> to log</param>
        [SuppressMessage("Usage", "CA2254",
            Justification = "The logged message will always be the same, as always the same strings are appended")]
        public void LogAndClear(ILogger logger, Exception? exception)
        {
            if (_shouldAppend)
            {
                logger.LogWarning(exception, _messageBuilder.ToString(), _arguments);
                _messageBuilder.Clear();
            }
        }

        /// <summary>
        /// Send message to <paramref name="logger"/> using
        /// <see cref="M:Microsoft.Extensions.Logging.LoggerExtensions.LogWarning(Microsoft.Extensions.Logging.ILogger,Microsoft.Extensions.Logging.EventId,System.Exception,System.String,System.Object[])"/>. 
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to use</param>
        /// <param name="eventId">The <see cref="EventId"/> to use</param>
        /// <param name="exception">The <see cref="Exception"/> to log</param>
        [SuppressMessage("Usage", "CA2254",
            Justification = "The logged message will always be the same, as always the same strings are appended")]
        public void LogAndClear(ILogger logger, EventId eventId, Exception? exception)
        {
            if (_shouldAppend)
            {
                logger.LogWarning(eventId, exception, _messageBuilder.ToString(), _arguments);
                _messageBuilder.Clear();
            }
        }
    }

    /// <summary>
    /// Log the interpolated string as formattable message to <paramref name="logger"/>, if it returns <c>true</c> from
    /// <see cref="ILogger.IsEnabled"/> for <see cref="LogLevel.Error"/>.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><description>Uses C# 10 compiler-features to let you construct <paramref name="logHandler"/>!</description></item>
    /// <item><description>The placeholders are not evaluated, if the <see cref="LogLevel.Error"/> is not enabled!</description></item>
    /// <item><description>Everything after the last <c>:</c> in a format-string is used as placeholder in the log-message. That means, that you need to type out a placeholder, if you use custom formats containing <c>:</c></description></item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// logger.LogErrorEx($"It is currently {GetTime():HH:mm:ss:logTime}!");
    /// </code>
    /// will have the same effect as
    /// <code>
    /// logger.Log("It is currently {logTime:HH:mm:ss}!", new object?[] {GetTime()});
    /// </code>
    /// if <see cref="LogLevel.Error"/> is enabled.
    /// If <see cref="LogLevel.Error"/> is not enabled, <c>GetTime()</c> is not called.
    /// </example>
    /// <param name="logger">The <see cref="ILogger"/> to use</param>
    /// <param name="logHandler">The compiler-constructed <see cref="InterpolatedErrorLogHandler"/>. Just write your <c>$"Log {message}"</c></param>
    public static void LogErrorEx(
        this ILogger logger,
        [InterpolatedStringHandlerArgument("logger")]
        ref InterpolatedErrorLogHandler logHandler)
    {
        logHandler.LogAndClear(logger);
    }

    /// <summary>
    /// Log the interpolated string as formattable message to <paramref name="logger"/>, if it returns <c>true</c> from
    /// <see cref="ILogger.IsEnabled"/> for <see cref="LogLevel.Error"/>.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><description>Uses C# 10 compiler-features to let you construct <paramref name="logHandler"/>!</description></item>
    /// <item><description>The placeholders are not evaluated, if the <see cref="LogLevel.Error"/> is not enabled!</description></item>
    /// <item><description>Everything after the last <c>:</c> in a format-string is used as placeholder in the log-message. That means, that you need to type out a placeholder, if you use custom formats containing <c>:</c></description></item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// logger.LogErrorEx($"It is currently {GetTime():HH:mm:ss:logTime}!");
    /// </code>
    /// will have the same effect as
    /// <code>
    /// logger.Log("It is currently {logTime:HH:mm:ss}!", new object?[] {GetTime()});
    /// </code>
    /// if <see cref="LogLevel.Error"/> is enabled.
    /// If <see cref="LogLevel.Error"/> is not enabled, <c>GetTime()</c> is not called.
    /// </example>
    /// <param name="logger">The <see cref="ILogger"/> to use</param>
    /// <param name="eventId">The <see cref="EventId"/> to use</param>
    /// <param name="logHandler">The compiler-constructed <see cref="InterpolatedErrorLogHandler"/>. Just write your <c>$"Log {message}"</c></param>
    public static void LogErrorEx(
        this ILogger logger,
        EventId eventId,
        [InterpolatedStringHandlerArgument("logger")]
        ref InterpolatedErrorLogHandler logHandler)
    {
        logHandler.LogAndClear(logger, eventId);
    }

    /// <summary>
    /// Log the interpolated string as formattable message to <paramref name="logger"/>, if it returns <c>true</c> from
    /// <see cref="ILogger.IsEnabled"/> for <see cref="LogLevel.Error"/>.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><description>Uses C# 10 compiler-features to let you construct <paramref name="logHandler"/>!</description></item>
    /// <item><description>The placeholders are not evaluated, if the <see cref="LogLevel.Error"/> is not enabled!</description></item>
    /// <item><description>Everything after the last <c>:</c> in a format-string is used as placeholder in the log-message. That means, that you need to type out a placeholder, if you use custom formats containing <c>:</c></description></item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// logger.LogErrorEx($"It is currently {GetTime():HH:mm:ss:logTime}!");
    /// </code>
    /// will have the same effect as
    /// <code>
    /// logger.Log("It is currently {logTime:HH:mm:ss}!", new object?[] {GetTime()});
    /// </code>
    /// if <see cref="LogLevel.Error"/> is enabled.
    /// If <see cref="LogLevel.Error"/> is not enabled, <c>GetTime()</c> is not called.
    /// </example>
    /// <param name="logger">The <see cref="ILogger"/> to use</param>
    /// <param name="exception">The <see cref="Exception"/> to log</param>
    /// <param name="logHandler">The compiler-constructed <see cref="InterpolatedErrorLogHandler"/>. Just write your <c>$"Log {message}"</c></param>
    public static void LogErrorEx(
        this ILogger logger,
        Exception? exception,
        [InterpolatedStringHandlerArgument("logger")]
        ref InterpolatedErrorLogHandler logHandler)
    {
        logHandler.LogAndClear(logger, exception);
    }

    /// <summary>
    /// Log the interpolated string as formattable message to <paramref name="logger"/>, if it returns <c>true</c> from
    /// <see cref="ILogger.IsEnabled"/> for <see cref="LogLevel.Error"/>.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><description>Uses C# 10 compiler-features to let you construct <paramref name="logHandler"/>!</description></item>
    /// <item><description>The placeholders are not evaluated, if the <see cref="LogLevel.Error"/> is not enabled!</description></item>
    /// <item><description>Everything after the last <c>:</c> in a format-string is used as placeholder in the log-message. That means, that you need to type out a placeholder, if you use custom formats containing <c>:</c></description></item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// logger.LogErrorEx($"It is currently {GetTime():HH:mm:ss:logTime}!");
    /// </code>
    /// will have the same effect as
    /// <code>
    /// logger.Log("It is currently {logTime:HH:mm:ss}!", new object?[] {GetTime()});
    /// </code>
    /// if <see cref="LogLevel.Error"/> is enabled.
    /// If <see cref="LogLevel.Error"/> is not enabled, <c>GetTime()</c> is not called.
    /// </example>
    /// <param name="logger">The <see cref="ILogger"/> to use</param>
    /// <param name="eventId">The <see cref="EventId"/> to use</param>
    /// <param name="exception">The <see cref="Exception"/> to log</param>
    /// <param name="logHandler">The compiler-constructed <see cref="InterpolatedErrorLogHandler"/>. Just write your <c>$"Log {message}"</c></param>
    public static void LogErrorEx(
        this ILogger logger,
        EventId eventId,
        Exception? exception,
        [InterpolatedStringHandlerArgument("logger")]
        ref InterpolatedErrorLogHandler logHandler)
    {
        logHandler.LogAndClear(logger, eventId, exception);
    }

    /// <summary>
    /// String interpolation handler for the <c>LogErrorEx</c>-functions. To be used by the compiler.
    /// </summary>
    [InterpolatedStringHandler]
    public ref struct InterpolatedErrorLogHandler
    {
        private readonly bool _shouldAppend;
        private readonly StringBuilder _messageBuilder;
        private readonly object?[] _arguments;
        private int _nextArgument = 0;

        /// <summary>
        /// Creates a <see cref="InterpolatedErrorLogHandler"/>. To be used by the compiler.
        /// </summary>
        public InterpolatedErrorLogHandler(int literalLength, int formattedCount, ILogger logger,
            out bool shouldAppend)
        {
            _shouldAppend = shouldAppend = logger.IsEnabled(LogLevel.Error);
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
        /// <see cref="M:Microsoft.Extensions.Logging.LoggerExtensions.LogError(Microsoft.Extensions.Logging.ILogger,Microsoft.Extensions.Logging.EventId,System.Exception,System.String,System.Object[])"/>. 
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to use</param>
        [SuppressMessage("Usage", "CA2254",
            Justification = "The logged message will always be the same, as always the same strings are appended")]
        public void LogAndClear(ILogger logger)
        {
            if (_shouldAppend)
            {
                logger.LogError(_messageBuilder.ToString(), _arguments);
                _messageBuilder.Clear();
            }
        }

        /// <summary>
        /// Send message to <paramref name="logger"/> using
        /// <see cref="M:Microsoft.Extensions.Logging.LoggerExtensions.LogError(Microsoft.Extensions.Logging.ILogger,Microsoft.Extensions.Logging.EventId,System.Exception,System.String,System.Object[])"/>. 
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to use</param>
        /// <param name="eventId">The <see cref="EventId"/> to use</param>
        [SuppressMessage("Usage", "CA2254",
            Justification = "The logged message will always be the same, as always the same strings are appended")]
        public void LogAndClear(ILogger logger, EventId eventId)
        {
            if (_shouldAppend)
            {
                logger.LogError(eventId, _messageBuilder.ToString(), _arguments);
                _messageBuilder.Clear();
            }
        }

        /// <summary>
        /// Send message to <paramref name="logger"/> using
        /// <see cref="M:Microsoft.Extensions.Logging.LoggerExtensions.LogError(Microsoft.Extensions.Logging.ILogger,System.Exception,System.String,System.Object[])"/>. 
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to use</param>
        /// <param name="exception">The <see cref="Exception"/> to log</param>
        [SuppressMessage("Usage", "CA2254",
            Justification = "The logged message will always be the same, as always the same strings are appended")]
        public void LogAndClear(ILogger logger, Exception? exception)
        {
            if (_shouldAppend)
            {
                logger.LogError(exception, _messageBuilder.ToString(), _arguments);
                _messageBuilder.Clear();
            }
        }

        /// <summary>
        /// Send message to <paramref name="logger"/> using
        /// <see cref="M:Microsoft.Extensions.Logging.LoggerExtensions.LogError(Microsoft.Extensions.Logging.ILogger,Microsoft.Extensions.Logging.EventId,System.Exception,System.String,System.Object[])"/>. 
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to use</param>
        /// <param name="eventId">The <see cref="EventId"/> to use</param>
        /// <param name="exception">The <see cref="Exception"/> to log</param>
        [SuppressMessage("Usage", "CA2254",
            Justification = "The logged message will always be the same, as always the same strings are appended")]
        public void LogAndClear(ILogger logger, EventId eventId, Exception? exception)
        {
            if (_shouldAppend)
            {
                logger.LogError(eventId, exception, _messageBuilder.ToString(), _arguments);
                _messageBuilder.Clear();
            }
        }
    }

    /// <summary>
    /// Log the interpolated string as formattable message to <paramref name="logger"/>, if it returns <c>true</c> from
    /// <see cref="ILogger.IsEnabled"/> for <see cref="LogLevel.Critical"/>.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><description>Uses C# 10 compiler-features to let you construct <paramref name="logHandler"/>!</description></item>
    /// <item><description>The placeholders are not evaluated, if the <see cref="LogLevel.Critical"/> is not enabled!</description></item>
    /// <item><description>Everything after the last <c>:</c> in a format-string is used as placeholder in the log-message. That means, that you need to type out a placeholder, if you use custom formats containing <c>:</c></description></item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// logger.LogCriticalEx($"It is currently {GetTime():HH:mm:ss:logTime}!");
    /// </code>
    /// will have the same effect as
    /// <code>
    /// logger.Log("It is currently {logTime:HH:mm:ss}!", new object?[] {GetTime()});
    /// </code>
    /// if <see cref="LogLevel.Critical"/> is enabled.
    /// If <see cref="LogLevel.Critical"/> is not enabled, <c>GetTime()</c> is not called.
    /// </example>
    /// <param name="logger">The <see cref="ILogger"/> to use</param>
    /// <param name="logHandler">The compiler-constructed <see cref="InterpolatedCriticalLogHandler"/>. Just write your <c>$"Log {message}"</c></param>
    public static void LogCriticalEx(
        this ILogger logger,
        [InterpolatedStringHandlerArgument("logger")]
        ref InterpolatedCriticalLogHandler logHandler)
    {
        logHandler.LogAndClear(logger);
    }

    /// <summary>
    /// Log the interpolated string as formattable message to <paramref name="logger"/>, if it returns <c>true</c> from
    /// <see cref="ILogger.IsEnabled"/> for <see cref="LogLevel.Critical"/>.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><description>Uses C# 10 compiler-features to let you construct <paramref name="logHandler"/>!</description></item>
    /// <item><description>The placeholders are not evaluated, if the <see cref="LogLevel.Critical"/> is not enabled!</description></item>
    /// <item><description>Everything after the last <c>:</c> in a format-string is used as placeholder in the log-message. That means, that you need to type out a placeholder, if you use custom formats containing <c>:</c></description></item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// logger.LogCriticalEx($"It is currently {GetTime():HH:mm:ss:logTime}!");
    /// </code>
    /// will have the same effect as
    /// <code>
    /// logger.Log("It is currently {logTime:HH:mm:ss}!", new object?[] {GetTime()});
    /// </code>
    /// if <see cref="LogLevel.Critical"/> is enabled.
    /// If <see cref="LogLevel.Critical"/> is not enabled, <c>GetTime()</c> is not called.
    /// </example>
    /// <param name="logger">The <see cref="ILogger"/> to use</param>
    /// <param name="eventId">The <see cref="EventId"/> to use</param>
    /// <param name="logHandler">The compiler-constructed <see cref="InterpolatedCriticalLogHandler"/>. Just write your <c>$"Log {message}"</c></param>
    public static void LogCriticalEx(
        this ILogger logger,
        EventId eventId,
        [InterpolatedStringHandlerArgument("logger")]
        ref InterpolatedCriticalLogHandler logHandler)
    {
        logHandler.LogAndClear(logger, eventId);
    }

    /// <summary>
    /// Log the interpolated string as formattable message to <paramref name="logger"/>, if it returns <c>true</c> from
    /// <see cref="ILogger.IsEnabled"/> for <see cref="LogLevel.Critical"/>.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><description>Uses C# 10 compiler-features to let you construct <paramref name="logHandler"/>!</description></item>
    /// <item><description>The placeholders are not evaluated, if the <see cref="LogLevel.Critical"/> is not enabled!</description></item>
    /// <item><description>Everything after the last <c>:</c> in a format-string is used as placeholder in the log-message. That means, that you need to type out a placeholder, if you use custom formats containing <c>:</c></description></item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// logger.LogCriticalEx($"It is currently {GetTime():HH:mm:ss:logTime}!");
    /// </code>
    /// will have the same effect as
    /// <code>
    /// logger.Log("It is currently {logTime:HH:mm:ss}!", new object?[] {GetTime()});
    /// </code>
    /// if <see cref="LogLevel.Critical"/> is enabled.
    /// If <see cref="LogLevel.Critical"/> is not enabled, <c>GetTime()</c> is not called.
    /// </example>
    /// <param name="logger">The <see cref="ILogger"/> to use</param>
    /// <param name="exception">The <see cref="Exception"/> to log</param>
    /// <param name="logHandler">The compiler-constructed <see cref="InterpolatedCriticalLogHandler"/>. Just write your <c>$"Log {message}"</c></param>
    public static void LogCriticalEx(
        this ILogger logger,
        Exception? exception,
        [InterpolatedStringHandlerArgument("logger")]
        ref InterpolatedCriticalLogHandler logHandler)
    {
        logHandler.LogAndClear(logger, exception);
    }

    /// <summary>
    /// Log the interpolated string as formattable message to <paramref name="logger"/>, if it returns <c>true</c> from
    /// <see cref="ILogger.IsEnabled"/> for <see cref="LogLevel.Critical"/>.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><description>Uses C# 10 compiler-features to let you construct <paramref name="logHandler"/>!</description></item>
    /// <item><description>The placeholders are not evaluated, if the <see cref="LogLevel.Critical"/> is not enabled!</description></item>
    /// <item><description>Everything after the last <c>:</c> in a format-string is used as placeholder in the log-message. That means, that you need to type out a placeholder, if you use custom formats containing <c>:</c></description></item>
    /// </list>
    /// </remarks>
    /// <example>
    /// <code>
    /// logger.LogCriticalEx($"It is currently {GetTime():HH:mm:ss:logTime}!");
    /// </code>
    /// will have the same effect as
    /// <code>
    /// logger.Log("It is currently {logTime:HH:mm:ss}!", new object?[] {GetTime()});
    /// </code>
    /// if <see cref="LogLevel.Critical"/> is enabled.
    /// If <see cref="LogLevel.Critical"/> is not enabled, <c>GetTime()</c> is not called.
    /// </example>
    /// <param name="logger">The <see cref="ILogger"/> to use</param>
    /// <param name="eventId">The <see cref="EventId"/> to use</param>
    /// <param name="exception">The <see cref="Exception"/> to log</param>
    /// <param name="logHandler">The compiler-constructed <see cref="InterpolatedCriticalLogHandler"/>. Just write your <c>$"Log {message}"</c></param>
    public static void LogCriticalEx(
        this ILogger logger,
        EventId eventId,
        Exception? exception,
        [InterpolatedStringHandlerArgument("logger")]
        ref InterpolatedCriticalLogHandler logHandler)
    {
        logHandler.LogAndClear(logger, eventId, exception);
    }

    /// <summary>
    /// String interpolation handler for the <c>LogCriticalEx</c>-functions. To be used by the compiler.
    /// </summary>
    [InterpolatedStringHandler]
    public ref struct InterpolatedCriticalLogHandler
    {
        private readonly bool _shouldAppend;
        private readonly StringBuilder _messageBuilder;
        private readonly object?[] _arguments;
        private int _nextArgument = 0;

        /// <summary>
        /// Creates a <see cref="InterpolatedCriticalLogHandler"/>. To be used by the compiler.
        /// </summary>
        public InterpolatedCriticalLogHandler(int literalLength, int formattedCount, ILogger logger,
            out bool shouldAppend)
        {
            _shouldAppend = shouldAppend = logger.IsEnabled(LogLevel.Critical);
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
        /// <see cref="M:Microsoft.Extensions.Logging.LoggerExtensions.LogCritical(Microsoft.Extensions.Logging.ILogger,Microsoft.Extensions.Logging.EventId,System.Exception,System.String,System.Object[])"/>. 
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to use</param>
        [SuppressMessage("Usage", "CA2254",
            Justification = "The logged message will always be the same, as always the same strings are appended")]
        public void LogAndClear(ILogger logger)
        {
            if (_shouldAppend)
            {
                logger.LogCritical(_messageBuilder.ToString(), _arguments);
                _messageBuilder.Clear();
            }
        }

        /// <summary>
        /// Send message to <paramref name="logger"/> using
        /// <see cref="M:Microsoft.Extensions.Logging.LoggerExtensions.LogCritical(Microsoft.Extensions.Logging.ILogger,Microsoft.Extensions.Logging.EventId,System.Exception,System.String,System.Object[])"/>. 
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to use</param>
        /// <param name="eventId">The <see cref="EventId"/> to use</param>
        [SuppressMessage("Usage", "CA2254",
            Justification = "The logged message will always be the same, as always the same strings are appended")]
        public void LogAndClear(ILogger logger, EventId eventId)
        {
            if (_shouldAppend)
            {
                logger.LogCritical(eventId, _messageBuilder.ToString(), _arguments);
                _messageBuilder.Clear();
            }
        }

        /// <summary>
        /// Send message to <paramref name="logger"/> using
        /// <see cref="M:Microsoft.Extensions.Logging.LoggerExtensions.LogCritical(Microsoft.Extensions.Logging.ILogger,System.Exception,System.String,System.Object[])"/>. 
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to use</param>
        /// <param name="exception">The <see cref="Exception"/> to log</param>
        [SuppressMessage("Usage", "CA2254",
            Justification = "The logged message will always be the same, as always the same strings are appended")]
        public void LogAndClear(ILogger logger, Exception? exception)
        {
            if (_shouldAppend)
            {
                logger.LogCritical(exception, _messageBuilder.ToString(), _arguments);
                _messageBuilder.Clear();
            }
        }

        /// <summary>
        /// Send message to <paramref name="logger"/> using
        /// <see cref="M:Microsoft.Extensions.Logging.LoggerExtensions.LogCritical(Microsoft.Extensions.Logging.ILogger,Microsoft.Extensions.Logging.EventId,System.Exception,System.String,System.Object[])"/>. 
        /// </summary>
        /// <param name="logger">The <see cref="ILogger"/> to use</param>
        /// <param name="eventId">The <see cref="EventId"/> to use</param>
        /// <param name="exception">The <see cref="Exception"/> to log</param>
        [SuppressMessage("Usage", "CA2254",
            Justification = "The logged message will always be the same, as always the same strings are appended")]
        public void LogAndClear(ILogger logger, EventId eventId, Exception? exception)
        {
            if (_shouldAppend)
            {
                logger.LogCritical(eventId, exception, _messageBuilder.ToString(), _arguments);
                _messageBuilder.Clear();
            }
        }
    }
}