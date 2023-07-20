using System;
using System.Collections.Generic;
using InterpolatedStringExtensions;
using Microsoft.Extensions.Logging;

namespace InterpolatedStringExtensionsTests;

[TestClass]
public class LoggerExtensionsWithLogLevelParameterTests
{
    private const string FormatStringKey = "{OriginalFormat}";

    [TestMethod]
    public void LogExLogsInformationWhenActive()
    {
        var listLogger = new ListLogger(LogLevel.Information);
        var i = 0;

        listLogger.LogEx(LogLevel.Information, $"The value of i is {++i}");

        const string formatString = "The value of i is {++i}";
        const string formattedMessage = "The value of i is 1";

        listLogger.Messages.ShouldHaveSingleItem()
            .ShouldSatisfyAllConditions(
                m => m.logLevel.ShouldBe(LogLevel.Information),
                m => m.eventId.ShouldBe(0),
                m => m.state.ShouldBeAssignableTo<IEnumerable<KeyValuePair<string, object?>>>()
                    .ShouldBe(new[]
                    {
                        new KeyValuePair<string, object?>("++i", 1),
                        new KeyValuePair<string, object?>(FormatStringKey, formatString)
                    }),
                m => m.exception.ShouldBeNull(),
                m => m.formatter.DynamicInvoke(m.state, m.exception)
                    .ShouldBeAssignableTo<string>()
                    .ShouldBe(formattedMessage));
        i.ShouldBe(1);
    }

    [TestMethod]
    public void LogExDoesNotLogInformationWhenInactive()
    {
        var listLogger = new ListLogger(LogLevel.Warning);
        var i = 0;

        listLogger.LogEx(LogLevel.Information, $"The value of i is {++i}");

        listLogger.Messages.ShouldBeEmpty();
        i.ShouldBe(0);
    }

    [TestMethod]
    public void LogExLogsTraceWhenActive()
    {
        var listLogger = new ListLogger(LogLevel.Trace);
        var eventId = new EventId(1, "TimeEvent");
        var time = new TimeOnly(12, 42, 0, 123);

        listLogger.LogEx(LogLevel.Trace, eventId, $"It is currently {time:HH:mm:ss:logTime}!");

        const string formatString = "It is currently {logTime:HH:mm:ss}!";
        const string formattedMessage = "It is currently 12:42:00!";

        listLogger.Messages.ShouldHaveSingleItem()
            .ShouldSatisfyAllConditions(
                m => m.logLevel.ShouldBe(LogLevel.Trace),
                m => m.eventId.ShouldBe(eventId),
                m => m.state.ShouldBeAssignableTo<IEnumerable<KeyValuePair<string, object?>>>()
                    .ShouldBe(new[]
                    {
                        new KeyValuePair<string, object?>("logTime", time),
                        new KeyValuePair<string, object?>(FormatStringKey, formatString)
                    }),
                m => m.exception.ShouldBeNull(),
                m => m.formatter.DynamicInvoke(m.state, m.exception)
                    .ShouldBeAssignableTo<string>()
                    .ShouldBe(formattedMessage));
    }

    [TestMethod]
    public void LogExDoesNotLogTraceWhenInactive()
    {
        var listLogger = new ListLogger(LogLevel.Error);
        var eventId = new EventId(1, "TimeEvent");
        var time = new TimeOnly(12, 42, 0, 123);

        listLogger.LogEx(LogLevel.Trace, eventId, $"It is currently {time:HH:mm:ss:logTime}!");

        listLogger.Messages.ShouldBeEmpty();
    }
}