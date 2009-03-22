using System;

/// <summary>
/// Extension methods for the string data type
/// </summary>
public static class StringExtensions {

    /// <summary>
    /// Determines whether the specified string is null or empty.
    /// </summary>
    /// <param name="value">The string value to check.</param>
    public static bool IsEmpty(this string value) {
        return ((value == null) || (value.Length == 0));
    }

    /// <summary>
    /// Determines whether the specified string is not null or empty.
    /// </summary>
    /// <param name="value">The string value to check.</param>
    public static bool IsNotEmpty(this string value) {
        return (value.IsEmpty() == false);
    }

    /// <summary>
    /// Checks whether the string is empty and returns a default value in case.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>Either the string or the default value.</returns>
    public static string IfEmpty(this string value, string defaultValue) {
        return (value.IsNotEmpty() ? value : defaultValue);
    }

    /// <summary>
    /// Formats the value with the parameters using string.Format.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="parameters">The parameters.</param>
    /// <returns></returns>
    public static string FormatWith(this string value, params object[] parameters) {
        return string.Format(value, parameters);
    }

    /// <summary>
    /// Trims the text to a provided maximum length.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="maxLength">Maximum length.</param>
    /// <returns></returns>
    public static string TrimToMaxLength(this string value, int maxLength) {
        return (value == null || value.Length <= maxLength ? value : value.Substring(0, maxLength));
    }

    /// <summary>
    /// Trims the text to a provided maximum length and adds a suffix if required.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="maxLength">Maximum length.</param>
    /// <param name="suffix">The suffix.</param>
    /// <returns></returns>
    public static string TrimToMaxLength(this string value, int maxLength, string suffix) {
        return (value == null || value.Length <= maxLength ? value : string.Concat(value.Substring(0, maxLength), suffix));
    }
}
