using System;
using System.Collections.Generic;
using System.IO;

namespace PGK.Extensions {

    /// <summary>
    /// Extension methods for the TextReader class and its sub classes (StreamReader, StringReader)
    /// </summary>
    public static class TextReaderExtensions {

        /// <summary>
        /// The method provides an iterator through all lines of the text reader.
        /// </summary>
        /// <param name="reader">The text reader.</param>
        /// <returns>The iterator</returns>
        /// <example>
        /// using(var reader = fileInfo.OpenText()) {
        ///  foreach(var line in reader.IterateLines()) {
        ///   // ...
        ///  }
        /// }
        /// </example>
        /// <remarks>Contributed by OlivierJ</remarks>
        public static IEnumerable<string> IterateLines(this TextReader reader) {
            string line = null;
            while((line = reader.ReadLine()) != null) {
                yield return line;
            }
        }
    }
}
