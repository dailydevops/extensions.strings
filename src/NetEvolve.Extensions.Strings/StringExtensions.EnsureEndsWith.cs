namespace System;

using NetEvolve.Arguments;

public static partial class StringExtensions
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
        Argument.ThrowIfNull(value);
        Argument.ThrowIfNull(suffix);

#pragma warning disable CA1062 // Validate arguments of public methods
        return value.EndsWith(suffix, comparison) ? value : $"{value}{suffix}";
#pragma warning restore CA1062 // Validate arguments of public methods
    }
}
