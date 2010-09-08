using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PGK.Extensions
{
    /// <summary>
    /// Extension methods for byte[]
    /// </summary>
    public static class ByteArrayExtensions
    {
        /// <summary>
        /// Find the first occurence of an byte[] in another byte[]
        /// </summary>
        /// <param name="buf1">the byte[] to search in</param>
        /// <param name="buf2">the byte[] to find</param>
        /// <returns>the first position of the found byte[] or -1 if not found</returns>
        public static int FindArrayInArray(this byte[] buf1, byte[] buf2)
        {
            int i, j;
            for (j = 0; j < buf1.Length - buf2.Length; j++)
            {
                for (i = 0; i < buf2.Length; i++)
                {
                    if (buf1[j + i] != buf2[i]) break;
                }
                if (i == buf2.Length)
                    return j;
            }

            return -1;
        }
    }
}
