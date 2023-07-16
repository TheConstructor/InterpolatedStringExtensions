using System;
using System.Globalization;
using System.Text;
using Microsoft.Extensions.Logging;

namespace InterpolatedLog;

/// <summary>
/// Extensions for <see cref="ILogger"/> inspired by
/// <see href="https://devblogs.microsoft.com/dotnet/string-interpolation-in-c-10-and-net-6/">the blog-post on
/// interpolated string-handling in C# 10</see>
/// </summary>
public static partial class LoggerExtensions
{
    private const int AveragePlaceholderLength = 11;
    private static readonly char[] CurlyBraces = {'{', '}'};

    private static void AppendEscaped(StringBuilder stringBuilder, ReadOnlySpan<char> value)
    {
        var index = value.IndexOfAny(CurlyBraces);
        if (index == -1)
        {
            stringBuilder.Append(value);
            return;
        }

        do
        {
            stringBuilder.Append(value[..(index + 1)]);
            stringBuilder.Append(value[index]);
            value = value[(index + 1)..];
            if (value.IsEmpty)
            {
                return;
            }

            index = value.IndexOfAny(CurlyBraces);
        } while (index != -1);

        stringBuilder.Append(value);
    }

    private static void AppendPlaceholder(StringBuilder stringBuilder, string? expression, string? format, int pos)
    {
        stringBuilder.Append('{');
        var index = format?.LastIndexOf(':') ?? -1;
        if (index != -1 && index != format!.Length - 1)
        {
            AppendPlaceholderName(stringBuilder, format.AsSpan(index + 1));
            if (index != 0)
            {
                stringBuilder.Append(':');
                AppendEscaped(stringBuilder, format.AsSpan(0, index));
            }
        }
        else
        {
            if (!string.IsNullOrEmpty(expression))
            {
                AppendPlaceholderName(stringBuilder, expression);
            }
            else
            {
                stringBuilder.Append(CultureInfo.InvariantCulture, $"{pos}");
            }

            if (format != null && index != 0)
            {
                stringBuilder.Append(':');
                AppendEscaped(stringBuilder,
                    index == format.Length - 1
                        ? format.AsSpan(0, format.Length - 1)
                        : format.AsSpan());
            }
        }

        stringBuilder.Append('}');
    }

    private static void AppendPlaceholder(StringBuilder stringBuilder, string? expression, int alignment,
        string? format, int pos)
    {
        stringBuilder.Append('{');
        if (format?.LastIndexOf(':') is { } index && index != -1)
        {
            AppendPlaceholderName(stringBuilder, format.AsSpan(index + 1));

            stringBuilder.Append(',');
            stringBuilder.Append(CultureInfo.InvariantCulture, $"{alignment}");

            if (index != format.Length)
            {
                stringBuilder.Append(':');
                AppendEscaped(stringBuilder, format.AsSpan(0, index));
            }
        }
        else
        {
            if (!string.IsNullOrEmpty(expression))
            {
                AppendPlaceholderName(stringBuilder, expression);
            }
            else
            {
                stringBuilder.Append(CultureInfo.InvariantCulture, $"{pos}");
            }

            stringBuilder.Append('.');
            stringBuilder.Append(CultureInfo.InvariantCulture, $"{alignment}");

            if (format != null)
            {
                stringBuilder.Append(':');
                AppendEscaped(stringBuilder, format);
            }
        }

        stringBuilder.Append('}');
    }

    private static void AppendPlaceholderName(StringBuilder stringBuilder, ReadOnlySpan<char> value)
    {
        var index = value.IndexOfAny(CurlyBraces);
        if (index == -1)
        {
            stringBuilder.Append(value);
            return;
        }

        do
        {
            // I guess this is a bug, but currently } cannot be used inside a placeholder
            if (value[index] == '}')
            {
                return;
            }

            stringBuilder.Append(value[..(index + 1)]);
            stringBuilder.Append(value[index]);
            value = value[(index + 1)..];
            if (value.IsEmpty)
            {
                return;
            }

            index = value.IndexOfAny(CurlyBraces);
        } while (index != -1);

        stringBuilder.Append(value);
    }
}