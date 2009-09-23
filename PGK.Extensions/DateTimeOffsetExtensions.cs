using System;

/// <summary>
/// Extension methods for the DateTimeOffset data type.
/// </summary>
public static class DateTimeOffsetExtensions {

    /// <summary>
    /// Indicates whether the date is today.
    /// </summary>
    /// <param name="dto">The date.</param>
    /// <returns>
    /// 	<c>true</c> if the specified date is today; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsToday(this DateTimeOffset dto) {
        return (dto.Date.IsToday());
    }
}
