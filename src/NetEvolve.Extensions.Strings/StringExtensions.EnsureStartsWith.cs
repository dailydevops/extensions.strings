namespace System;

using NetEvolve.Arguments;

public static partial class StringExtensions
{
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
        Argument.ThrowIfNull(value);
        Argument.ThrowIfNull(prefix);

#pragma warning disable CA1062 // Validate arguments of public methods
        return value.StartsWith(prefix, comparison) ? value : $"{prefix}{value}";
#pragma warning restore CA1062 // Validate arguments of public methods
    }
}
