namespace NetEvolve.Extensions.Strings.Tests.Unit;

using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using global::TUnit.Core.Executors;
using NetEvolve.Extensions.TUnit;

[ExcludeFromCodeCoverage]
[UnitTest]
public sealed class StringExtensionsTests
{
    [Test]
    public void EnsureEndsWith_WhenStringIsNull_ThrowsArgumentNullException()
    {
        // Arrange
        var value = default(string);
        var suffix = "suffix";

        // Act
        void Act() => value.EnsureEndsWith(suffix);

        // Assert
        _ = Assert.Throws<ArgumentNullException>("value", Act);
    }

    [Test]
    public void EnsureEndsWith_WhenSuffixIsNull_ThrowsArgumentNullException()
    {
        // Arrange
        var value = "value";
        var suffix = default(string);

        // Act
        void Act() => value.EnsureEndsWith(suffix);

        // Assert
        _ = Assert.Throws<ArgumentNullException>("suffix", Act);
    }

    [Test]
    [MethodDataSource(nameof(GetEnsureEndsWithData))]
    [Culture("en-US")]
    public async Task EnsureEndsWith_Theory_Expected(
        string expected,
        string value,
        string suffix,
        StringComparison comparison
    )
    {
        // Act
        var result = value.EnsureEndsWith(suffix, comparison);

        // Assert
        _ = await Assert.That(expected).IsEqualTo(result);
    }

    public static IEnumerable<(string, string, string, StringComparison)> GetEnsureEndsWithData =>
        [
            ("valueSUFFIX", "value", "SUFFIX", StringComparison.CurrentCulture),
            ("valueSUFFIX", "value", "SUFFIX", StringComparison.CurrentCultureIgnoreCase),
            ("valueSUFFIX", "valueSUFFIX", "SUFFIX", StringComparison.OrdinalIgnoreCase),
            ("valueSUFFIX", "valueSUFFIX", "SUFFIX", StringComparison.Ordinal),
        ];

    [Test]
    public void EnsureStartsWith_WhenArgumentValueNull_ThrowsArgumentNullException()
    {
        // Arrange
        var value = default(string);
        var prefix = string.Empty;

        // Act
        void Act() => value.EnsureStartsWith(prefix);

        // Assert
        _ = Assert.Throws<ArgumentNullException>("value", Act);
    }

    [Test]
    public void EnsureStartsWith_WhenArgumentPrefixNull_ThrowsArgumentNullException()
    {
        // Arrange
        var value = string.Empty;
        var prefix = default(string);

        // Act
        void Act() => value.EnsureStartsWith(prefix);

        // Assert
        _ = Assert.Throws<ArgumentNullException>("prefix", Act);
    }

    [Test]
    [MethodDataSource(nameof(GetEnsureStartsWithData))]
    [Culture("en-US")]
    public async Task EnsureStartsWith_Theory_Expected(
        string expected,
        string value,
        string prefix,
        StringComparison comparison
    )
    {
        // Act
        var result = value.EnsureStartsWith(prefix, comparison);

        // Assert
        _ = await Assert.That(expected).IsEqualTo(result);
    }

    public static IEnumerable<(string, string, string, StringComparison)> GetEnsureStartsWithData =>
        [
            ("PREFIXvalue", "value", "PREFIX", StringComparison.CurrentCulture),
            ("PREFIXvalue", "value", "PREFIX", StringComparison.CurrentCultureIgnoreCase),
            ("PREFIXvalue", "PREFIXvalue", "PREFIX", StringComparison.OrdinalIgnoreCase),
            ("PREFIXvalue", "PREFIXvalue", "PREFIX", StringComparison.Ordinal),
        ];
}
