namespace System.Tests.Unit;

using System;
using NetEvolve.Extensions.XUnit;
using Xunit;

public sealed partial class StringExtensionsTests
{
    [Fact]
    public void EnsureStartsWith_WhenArgumentValueNull_ThrowsArgumentNullException()
    {
        // Arrange
        var value = default(string);
        var prefix = string.Empty;

        // Act
        string Act() => value.EnsureStartsWith(prefix);

        // Assert
        _ = Assert.Throws<ArgumentNullException>("value", Act);
    }

    [Fact]
    public void EnsureStartsWith_WhenArgumentPrefixNull_ThrowsArgumentNullException()
    {
        // Arrange
        var value = string.Empty;
        var prefix = default(string);

        // Act
        string Act() => value.EnsureStartsWith(prefix);

        // Assert
        _ = Assert.Throws<ArgumentNullException>("prefix", Act);
    }

    [Theory]
    [MemberData(nameof(GetEnsureStartsWithData))]
    [SetCulture("en-US")]
    public void EnsureStartsWith_Theory_Expected(
        string expected,
        string value,
        string prefix,
        StringComparison comparison
    )
    {
        // Act
        var result = value.EnsureStartsWith(prefix, comparison);

        // Assert
        Assert.Equal(expected, result);
    }

    public static TheoryData<string, string, string, StringComparison> GetEnsureStartsWithData()
    {
        var data = new TheoryData<string, string, string, StringComparison>
        {
            { "PREFIXvalue", "value", "PREFIX", StringComparison.CurrentCulture },
            { "PREFIXvalue", "value", "PREFIX", StringComparison.CurrentCultureIgnoreCase },
            { "PREFIXvalue", "PREFIXvalue", "PREFIX", StringComparison.OrdinalIgnoreCase },
            { "PREFIXvalue", "PREFIXvalue", "PREFIX", StringComparison.Ordinal }
        };

        return data;
    }
}
