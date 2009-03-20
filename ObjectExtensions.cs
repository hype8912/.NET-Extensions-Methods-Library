using System;
using System.ComponentModel;

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

    /// <summary>
    /// Determines whether the object is equal to none of the provided values.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="obj">The object to be compared.</param>
    /// <param name="values">The values to compare with the object.</param>
    /// <returns></returns>
    public static bool EqualsNone<T>(this T obj, params T[] values) {
        return (obj.EqualsAny(values) == false);
    }

    /// <summary>
    /// Converts an object to the specified target type or returns the default value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value">The value.</param>
    /// <returns>The target type</returns>
    public static T ConvertTo<T>(this object value) {
        return value.ConvertTo(default(T));
    }

    /// <summary>
    /// Converts an object to the specified target type or returns the default value.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value">The value.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>The target type</returns>
    public static T ConvertTo<T>(this object value, T defaultValue) {
        if(value != null) {
            var targetType = typeof(T);

            var converter = TypeDescriptor.GetConverter(value);
            if(converter != null) {
                if(converter.CanConvertTo(targetType)) return (T) converter.ConvertTo(value, targetType);
            }

            converter = TypeDescriptor.GetConverter(targetType);
            if(converter != null) {
                if(converter.CanConvertFrom(value.GetType())) return (T) converter.ConvertFrom(value);
            }
        }
        return defaultValue;
    }

    /// <summary>
    /// Determines whether the value can (in theory) be converted to the specified target type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="value">The value.</param>
    /// <returns>
    /// 	<c>true</c> if this instance can be convert to the specified target type; otherwise, <c>false</c>.
    /// </returns>
    public static bool CanConvertTo<T>(this object value) {
        if(value != null) {
            var targetType = typeof(T);

            var converter = TypeDescriptor.GetConverter(value);
            if(converter != null) {
                if(converter.CanConvertTo(targetType)) return true;
            }

            converter = TypeDescriptor.GetConverter(targetType);
            if(converter != null) {
                if(converter.CanConvertFrom(value.GetType())) return true;
            }
        }
        return false;
    }
}
