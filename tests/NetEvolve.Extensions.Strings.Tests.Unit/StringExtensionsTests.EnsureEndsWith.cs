namespace System.Tests.Unit;

using NetEvolve.Extensions.XUnit;
using System;
using Xunit;

public sealed partial class StringExtensionsTests
{
    [Fact]
    public void EnsureEndsWith_WhenStringIsNull_ThrowsArgumentNullException()
    {
        // Arrange
        var value = default(string);
        var suffix = "suffix";

        // Act
        string Act() => value.EnsureEndsWith(suffix);

        // Assert
        _ = Assert.Throws<ArgumentNullException>("value", Act);
    }

    [Fact]
    public void EnsureEndsWith_WhenSuffixIsNull_ThrowsArgumentNullException()
    {
        // Arrange
        var value = "value";
        var suffix = default(string);

        // Act
        string Act() => value.EnsureEndsWith(suffix);

        // Assert
        _ = Assert.Throws<ArgumentNullException>("suffix", Act);
    }

    [Theory]
    [MemberData(nameof(GetEnsureEndsWithData))]
    [SetCulture("en-US")]
    public void EnsureEndsWith_Theory_Expected(
        string expected,
        string value,
        string suffix,
        StringComparison comparison
    )
    {
        // Act
        var result = value.EnsureEndsWith(suffix, comparison);

        // Assert
        Assert.Equal(expected, result);
    }

    public static TheoryData GetEnsureEndsWithData()
    {
        var data = new TheoryData<string, string, string, StringComparison>
        {
            { "valueSUFFIX", "value", "SUFFIX", StringComparison.CurrentCulture },
            { "valueSUFFIX", "value", "SUFFIX", StringComparison.CurrentCultureIgnoreCase },
            { "valueSUFFIX", "valueSUFFIX", "SUFFIX", StringComparison.OrdinalIgnoreCase },
            { "valueSUFFIX", "valueSUFFIX", "SUFFIX", StringComparison.Ordinal }
        };

        return data;
    }
}
