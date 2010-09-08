using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PGK.Extensions
{
    /// <summary>
    /// Extension methods for string[]
    /// </summary>
    public static class StringArrayExtensions
    {
        public static string ToString(this string[] stringarray, string separator = ",", string quotation = "\"", string prepend = "(", string append = ")")
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(prepend);
            foreach (string s in stringarray)
                sb.Append(quotation).Append(s).Append(quotation).Append(separator);
            sb.Append(append);

            return sb.ToString();
        }
    }
}
