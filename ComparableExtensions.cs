using System;

/// <summary>
/// Extension methods for all comparable objects eg. string, DateTime, numeric values ...
/// </summary>
public static class ComparableExtensions {

    /// <summary>
    /// Determines whether the specified value is between the the defined minimum and maximum range (including those values).
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value">The value.</param>
    /// <param name="minValue">The minimum value.</param>
    /// <param name="maxValue">The maximum value.</param>
    /// <returns>
    /// 	<c>true</c> if the specified value is between min and max; otherwise, <c>false</c>.
    /// </returns>
    /// <example>
    /// var value = 5;
    /// if(value.IsBetween(1, 10)) { 
    ///     // ... 
    /// }
    /// </example>
    public static bool IsBetween<T>(this T value, T minValue, T maxValue) where T : IComparable<T> {
        return ((value.CompareTo(minValue) >= 0) && (value.CompareTo(maxValue) <= 0));
    }
}
