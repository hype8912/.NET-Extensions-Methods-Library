using System;

/// <summary>
/// Extension methods for the root data type object
/// </summary>
public static class ObjectExtensions {

    /// <summary>
    /// Determines whether the object is equal to any of the provided values.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj">The object to be compared.</param>
    /// <param name="values">The values to compare with the object.</param>
    /// <returns></returns>
    public static bool EqualsAny<T>(this T obj, params T[] values) {
        return (Array.IndexOf(values, obj) != -1);
    }
}
