using System;

/// <summary>
///   Extension methods for all kinds of exceptions.
/// </summary>
public static class ExceptionExtensions {
    /// <summary>
    ///   Gets the original exception which is most inner exception.
    /// </summary>
    /// <param name = "exception">The exeption</param>
    /// <returns>The original exception</returns>
    /// <remarks>
    ///   Contributed by Kenneth Scott
    /// </remarks>
    public static Exception GetOriginalException(this Exception exception) {
        if (exception.InnerException == null) return exception;

        return exception.InnerException.GetOriginalException();
    }
}