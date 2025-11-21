namespace System.Tests.Unit;

using System;
using System.Threading.Tasks;
using TUnit.Core.Executors;

public sealed partial class StringExtensionsTests
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
}
