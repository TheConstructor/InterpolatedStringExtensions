using System;
using System.Globalization;
using System.Text;
using InterpolatedStringExtensions;

namespace InterpolatedStringExtensionsTests;

[TestClass]
public class EncodingExtensionsTests
{
    [TestMethod]
    public void WorksForCurrentLocale()
    {
        var strDummy = "strDummy";
        ReadOnlySpan<char> spanDummy = "spanDummy";
        var expected = string.Create(CultureInfo.CurrentCulture,
            $"Int: {42}, {42,4}, {42:000}, {42,4:000} Str: {strDummy}, {strDummy,10} Span: {spanDummy}, {spanDummy,10}");
        Encoding.UTF8
            .GetBytesEx(
                $"Int: {42}, {42,4}, {42:000}, {42,4:000} Str: {strDummy}, {strDummy,10} Span: {spanDummy}, {spanDummy,10}")
            .ShouldSatisfyAllConditions(
                b => b.ShouldBe(Encoding.UTF8.GetBytes(expected)),
                b => Encoding.UTF8.GetString(b).ShouldBe(expected));
    }

    [TestMethod]
    public void WorksForCurrentLocaleLeftAligned()
    {
        var strDummy = "strDummy";
        ReadOnlySpan<char> spanDummy = "spanDummy";
        var expected = string.Create(CultureInfo.CurrentCulture,
            $"Int: {42}, {42,-4}, {42:000}, {42,-4:000} Str: {strDummy}, {strDummy,-10} Span: {spanDummy}, {spanDummy,-10}");
        Encoding.UTF8
            .GetBytesEx(
                $"Int: {42}, {42,-4}, {42:000}, {42,-4:000} Str: {strDummy}, {strDummy,-10} Span: {spanDummy}, {spanDummy,-10}")
            .ShouldSatisfyAllConditions(
                b => b.ShouldBe(Encoding.UTF8.GetBytes(expected)),
                b => Encoding.UTF8.GetString(b).ShouldBe(expected));
    }

    [TestMethod]
    public void WorksForInvariantLocale()
    {
        var strDummy = "strDummy";
        ReadOnlySpan<char> spanDummy = "spanDummy";
        var expected = string.Create(CultureInfo.InvariantCulture,
            $"Int: {42}, {42,4}, {42:000}, {42,4:000} Str: {strDummy}, {strDummy,10} Span: {spanDummy}, {spanDummy,10}");
        Encoding.UTF8
            .GetBytesEx(CultureInfo.InvariantCulture,
                $"Int: {42}, {42,4}, {42:000}, {42,4:000} Str: {strDummy}, {strDummy,10} Span: {spanDummy}, {spanDummy,10}")
            .ShouldSatisfyAllConditions(
                b => b.ShouldBe(Encoding.UTF8.GetBytes(expected)),
                b => Encoding.UTF8.GetString(b).ShouldBe(expected));
    }

    [TestMethod]
    public void WorksForInvariantLocaleLeftAligned()
    {
        var strDummy = "strDummy";
        ReadOnlySpan<char> spanDummy = "spanDummy";
        var expected = string.Create(CultureInfo.InvariantCulture,
            $"Int: {42}, {42,-4}, {42:000}, {42,-4:000} Str: {strDummy}, {strDummy,-10} Span: {spanDummy}, {spanDummy,-10}");
        Encoding.UTF8
            .GetBytesEx(CultureInfo.InvariantCulture,
                $"Int: {42}, {42,-4}, {42:000}, {42,-4:000} Str: {strDummy}, {strDummy,-10} Span: {spanDummy}, {spanDummy,-10}")
            .ShouldSatisfyAllConditions(
                b => b.ShouldBe(Encoding.UTF8.GetBytes(expected)),
                b => Encoding.UTF8.GetString(b).ShouldBe(expected));
    }
}