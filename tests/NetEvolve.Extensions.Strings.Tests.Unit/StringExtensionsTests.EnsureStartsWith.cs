namespace System.Tests.Unit;

using System;
using System.Threading.Tasks;
using TUnit.Core.Executors;

public sealed partial class StringExtensionsTests
{
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
