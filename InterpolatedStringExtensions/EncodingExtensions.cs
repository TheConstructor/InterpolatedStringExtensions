using System;
using System.Buffers;
using System.Globalization;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace InterpolatedStringExtensions;

/// <summary>
/// Extensions for <see cref="Encoding"/>
/// </summary>
public static class EncodingExtensions
{
    public static ArraySegment<byte> GetBytesEx(
        this Encoding encoding,
        [InterpolatedStringHandlerArgument("encoding")]
        GetBytesInterpolatedStringHandler handler)
    {
        return handler.ReturnAndClear();
    }

    public static ArraySegment<byte> GetBytesEx(
        this Encoding encoding,
        IFormatProvider? formatProvider,
        [InterpolatedStringHandlerArgument("encoding", "formatProvider")]
        GetBytesInterpolatedStringHandler handler)
    {
        return handler.ReturnAndClear();
    }

    [InterpolatedStringHandler]
    public ref struct GetBytesInterpolatedStringHandler
    {
        private const int BufferLength = 256;
        private readonly MemoryStream _memoryStream;
        private readonly StreamWriter _streamWriter;
        private readonly IFormatProvider? _formatProvider;
        private readonly bool _hasCustomFormatter;
        private char[]? _arrayToReturnToPool;

        public GetBytesInterpolatedStringHandler(int literalLength, int formattedCount, Encoding encoding)
            : this(literalLength, formattedCount, encoding, null)
        {
        }

        public GetBytesInterpolatedStringHandler(int literalLength, int formattedCount, Encoding encoding,
            IFormatProvider? formatProvider)
        {
            _formatProvider = formatProvider;
            _memoryStream = new MemoryStream(Math.Max(
                encoding.GetMaxByteCount(literalLength + formattedCount * 11),
                BufferLength));
            // StreamWriter doesn't write the Encoding-preamble if the Stream.Position is > 0
            _memoryStream.WriteByte(0);
            _streamWriter = new StreamWriter(_memoryStream, encoding, leaveOpen: true);
            _memoryStream.SetLength(0);
            _hasCustomFormatter = formatProvider is not null
                                  && formatProvider.GetType() != typeof(CultureInfo)
                                  && formatProvider.GetFormat(typeof(ICustomFormatter)) != null;
            _arrayToReturnToPool = null;
        }

        public void AppendLiteral(string value)
        {
            _streamWriter.Write(value);
        }

        public void AppendFormatted<T>(T value)
        {
            if (value is IFormattable formattable)
            {
                _streamWriter.Write(formattable.ToString(null, _formatProvider));
                return;
            }

            _streamWriter.Write(value?.ToString());
        }

        public void AppendFormatted<T>(T value, string? format)
        {
            if (_hasCustomFormatter)
            {
                var formatter = (ICustomFormatter) _formatProvider!.GetFormat(typeof(ICustomFormatter))!;
                _streamWriter.Write(formatter.Format(format, value, _formatProvider));
            }
            else if (value is IFormattable formattable)
            {
                if (formattable is ISpanFormattable spanFormattable)
                {
                    var buffer = GetPooledArray();
                    if (spanFormattable.TryFormat(buffer, out var charsWritten, format, _formatProvider))
                    {
                        _streamWriter.Write(buffer.AsSpan(0, charsWritten));
                        return;
                    }
                }

                _streamWriter.Write(formattable.ToString(format, _formatProvider));
            }
            else
            {
                _streamWriter.Write(value?.ToString());
            }
        }

        public void AppendFormatted<T>(T value, int alignment)
        {
            if (_hasCustomFormatter)
            {
                var formatter = (ICustomFormatter) _formatProvider!.GetFormat(typeof(ICustomFormatter))!;
                var formatted = formatter.Format(null, value, _formatProvider);

                if (alignment > 0 && formatted.Length < alignment)
                {
                    WriteAlignment(alignment - formatted.Length);
                }

                _streamWriter.Write(formatted);

                if (alignment < 0 && formatted.Length < -alignment)
                {
                    WriteAlignment(-alignment - formatted.Length);
                }
            }
            else if (value is IFormattable formattable)
            {
                if (formattable is ISpanFormattable spanFormattable)
                {
                    var buffer = GetPooledArray();
                    if (spanFormattable.TryFormat(buffer, out var charsWritten, (string?) null, _formatProvider))
                    {
                        if (alignment > 0 && charsWritten < alignment)
                        {
                            var alignmentBuffer = ArrayPool<char>.Shared.Rent(BufferLength);
                            WriteAlignment(alignmentBuffer, alignment - charsWritten);
                            ArrayPool<char>.Shared.Return(alignmentBuffer);
                        }

                        _streamWriter.Write(buffer.AsSpan(0, charsWritten));

                        if (alignment < 0 && charsWritten < -alignment)
                        {
                            WriteAlignment(-alignment - charsWritten);
                        }

                        return;
                    }
                }

                var formatted = formattable.ToString(null, _formatProvider);

                if (alignment > 0 && formatted.Length < alignment)
                {
                    WriteAlignment(alignment - formatted.Length);
                }

                _streamWriter.Write(formatted);

                if (alignment < 0 && formatted.Length < -alignment)
                {
                    WriteAlignment(-alignment - formatted.Length);
                }
            }
            else
            {
                var formatted = value?.ToString();
                if (formatted == null)
                {
                    WriteAlignment(Math.Abs(alignment));
                    return;
                }

                if (alignment > 0 && formatted.Length < alignment)
                {
                    WriteAlignment(alignment - formatted.Length);
                }

                _streamWriter.Write(formatted);

                if (alignment < 0 && formatted.Length < -alignment)
                {
                    WriteAlignment(-alignment - formatted.Length);
                }
            }
        }

        public void AppendFormatted<T>(T value, int alignment, string? format)
        {
            if (_hasCustomFormatter)
            {
                var formatter = (ICustomFormatter) _formatProvider!.GetFormat(typeof(ICustomFormatter))!;
                var formatted = formatter.Format(format, value, _formatProvider);

                if (alignment > 0 && formatted.Length < alignment)
                {
                    WriteAlignment(alignment - formatted.Length);
                }

                _streamWriter.Write(formatted);

                if (alignment < 0 && formatted.Length < -alignment)
                {
                    WriteAlignment(-alignment - formatted.Length);
                }
            }
            else if (value is IFormattable formattable)
            {
                if (formattable is ISpanFormattable spanFormattable)
                {
                    var buffer = GetPooledArray();
                    if (spanFormattable.TryFormat(buffer, out var charsWritten, format, _formatProvider))
                    {
                        if (alignment > 0 && charsWritten < alignment)
                        {
                            var alignmentBuffer = ArrayPool<char>.Shared.Rent(BufferLength);
                            WriteAlignment(alignmentBuffer, alignment - charsWritten);
                            ArrayPool<char>.Shared.Return(alignmentBuffer);
                        }

                        _streamWriter.Write(buffer.AsSpan(0, charsWritten));

                        if (alignment < 0 && charsWritten < -alignment)
                        {
                            WriteAlignment(-alignment - charsWritten);
                        }

                        return;
                    }
                }

                var formatted = formattable.ToString(format, _formatProvider);

                if (alignment > 0 && formatted.Length < alignment)
                {
                    WriteAlignment(alignment - formatted.Length);
                }

                _streamWriter.Write(formatted);

                if (alignment < 0 && formatted.Length < -alignment)
                {
                    WriteAlignment(-alignment - formatted.Length);
                }
            }
            else
            {
                var formatted = value?.ToString();
                if (formatted == null)
                {
                    WriteAlignment(Math.Abs(alignment));
                    return;
                }

                if (alignment > 0 && formatted.Length < alignment)
                {
                    WriteAlignment(alignment - formatted.Length);
                }

                _streamWriter.Write(formatted);

                if (alignment < 0 && formatted.Length < -alignment)
                {
                    WriteAlignment(-alignment - formatted.Length);
                }
            }
        }

        public void AppendFormatted(ReadOnlySpan<char> value)
        {
            _streamWriter.Write(value);
        }

        public void AppendFormatted(ReadOnlySpan<char> value, int alignment = 0, string? format = null)
        {
            if (alignment > 0 && value.Length < alignment)
            {
                WriteAlignment(alignment - value.Length);
            }

            _streamWriter.Write(value);

            if (alignment < 0 && value.Length < -alignment)
            {
                WriteAlignment(-alignment - value.Length);
            }
        }

        public void AppendFormatted(string? value)
        {
            if (_hasCustomFormatter)
            {
                var formatter = (ICustomFormatter) _formatProvider!.GetFormat(typeof(ICustomFormatter))!;
                _streamWriter.Write(formatter.Format(null, value, _formatProvider));
            }
            else
            {
                _streamWriter.Write(value);
            }
        }

        public void AppendFormatted(string? value, int alignment = 0, string? format = null)
        {
            if (_hasCustomFormatter)
            {
                var formatter = (ICustomFormatter) _formatProvider!.GetFormat(typeof(ICustomFormatter))!;
                var formatted = formatter.Format(format, value, _formatProvider);

                if (alignment > 0 && formatted.Length < alignment)
                {
                    WriteAlignment(alignment - formatted.Length);
                }

                _streamWriter.Write(formatted);

                if (alignment < 0 && formatted.Length < -alignment)
                {
                    WriteAlignment(-alignment - formatted.Length);
                }
            }
            else
            {
                if (value == null)
                {
                    WriteAlignment(Math.Abs(alignment));
                    return;
                }

                if (alignment > 0 && value.Length < alignment)
                {
                    WriteAlignment(alignment - value.Length);
                }

                _streamWriter.Write(value);

                if (alignment < 0 && value.Length < -alignment)
                {
                    WriteAlignment(-alignment - value.Length);
                }
            }
        }

        public ArraySegment<byte> ReturnAndClear()
        {
            _streamWriter.Close();
            if (!_memoryStream.TryGetBuffer(out var result))
            {
                result = _memoryStream.ToArray();
            }

            _memoryStream.Close();

            var toReturn = _arrayToReturnToPool;
            this = default;
            if (toReturn is not null)
            {
                ArrayPool<char>.Shared.Return(toReturn, true);
            }

            return result;
        }

        private char[] GetPooledArray()
        {
            return _arrayToReturnToPool ??= ArrayPool<char>.Shared.Rent(BufferLength);
        }

        private void WriteAlignment(int toAppend)
        {
            if (toAppend < 1)
            {
                return;
            }

            WriteAlignment(GetPooledArray(), toAppend);
        }

        private void WriteAlignment(Span<char> buffer, int toAppend)
        {
            if (toAppend <= buffer.Length)
            {
                var span = buffer[..toAppend];
                span.Fill(' ');
                _streamWriter.Write(span);
            }
            else
            {
                buffer.Fill(' ');
                for (var i = buffer.Length; i < toAppend; i += buffer.Length)
                {
                    _streamWriter.Write(buffer);
                }

                _streamWriter.Write(buffer[..(toAppend % buffer.Length)]);
            }
        }
    }
}