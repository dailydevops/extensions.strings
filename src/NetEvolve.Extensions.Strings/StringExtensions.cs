namespace NetEvolve.Extensions.Strings;

using System;
using NetEvolve.Arguments;

/// <summary>
/// Collection of <see cref="string"/> extension methods.
/// </summary>
public static class StringExtensions
{
    /// <summary>
    /// Ensures that the string ends with the specified prefix.
    /// </summary>
    /// <param name="value">The value to be checked.</param>
    /// <param name="suffix">The suffix to be checked.</param>
    /// <param name="comparison">Defines, how the <paramref name="value"/> and the <paramref name="suffix"/> are compared.</param>
    /// <returns>Suffixed value, if necessary.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="value"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentNullException">If <paramref name="suffix"/> is <see langword="null"/>.</exception>
    public static string EnsureEndsWith(
        this string value,
        string suffix,
        StringComparison comparison = StringComparison.CurrentCulture
    )
    {
        ArgumentNullException.ThrowIfNull(value);
        ArgumentNullException.ThrowIfNull(suffix);

        return value.EndsWith(suffix, comparison) ? value : $"{value}{suffix}";
    }

    /// <summary>
    /// Ensures that the string starts with the specified prefix.
    /// </summary>
    /// <param name="value">The value to be checked.</param>
    /// <param name="prefix">The prefix to be checked.</param>
    /// <param name="comparison">Defines, how the <paramref name="value"/> and the <paramref name="prefix"/> are compared.</param>
    /// <returns>Prefixed value, if necessary.</returns>
    /// <exception cref="ArgumentNullException">If <paramref name="value"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentNullException">If <paramref name="prefix"/> is <see langword="null"/>.</exception>
    public static string EnsureStartsWith(
        this string value,
        string prefix,
        StringComparison comparison = StringComparison.CurrentCulture
    )
    {
        ArgumentNullException.ThrowIfNull(value);
        ArgumentNullException.ThrowIfNull(prefix);

        return value.StartsWith(prefix, comparison) ? value : $"{prefix}{value}";
    }
}
