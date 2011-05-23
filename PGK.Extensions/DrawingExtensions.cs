using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace PGK.Extensions
{
    /// <summary>
    /// Extension methods for the System.Drawing class
    /// </summary>
    public static class DrawingExtensions
    {
        /// <summary>
        /// Split an Icon (that contains multiple icons) into an array of Icon each rapresenting a single icons.
        /// </summary>
        /// <param name="icon">Instance value.</param>
        /// <returns>An array of <see cref="System.Drawing.Icon"/> objects.</returns>
        public static Icon[] SplitIcon(this Icon icon)
        {
            if (icon == null)
            {
                throw new ArgumentNullException("Can't split the icon. Icon is null.");
            }

            // Get multiple .ico file image.
            byte[] srcBuf = null;
            using (MemoryStream stream = new MemoryStream())
            {
                icon.Save(stream);
                srcBuf = stream.ToArray();
            }

            List<Icon> splitIcons = new List<Icon>();
            {
                const int sICONDIR = 6;            // sizeof(ICONDIR) 
                const int sICONDIRENTRY = 16;      // sizeof(ICONDIRENTRY)

                int count = BitConverter.ToInt16(srcBuf, 4); // ICONDIR.idCount

                for (int i = 0; i < count; i++)
                {
                    using (MemoryStream destStream = new MemoryStream())
                    using (BinaryWriter writer = new BinaryWriter(destStream))
                    {
                        // Copy ICONDIR and ICONDIRENTRY.
                        writer.Write(srcBuf, 0, sICONDIR - 2);
                        writer.Write((short)1);    // ICONDIR.idCount == 1;

                        writer.Write(srcBuf, sICONDIR + sICONDIRENTRY * i, sICONDIRENTRY - 4);
                        writer.Write(sICONDIR + sICONDIRENTRY);    // ICONDIRENTRY.dwImageOffset = sizeof(ICONDIR) + sizeof(ICONDIRENTRY)

                        // Copy picture and mask data.
                        int imgSize = BitConverter.ToInt32(srcBuf, sICONDIR + sICONDIRENTRY * i + 8);       // ICONDIRENTRY.dwBytesInRes
                        int imgOffset = BitConverter.ToInt32(srcBuf, sICONDIR + sICONDIRENTRY * i + 12);    // ICONDIRENTRY.dwImageOffset
                        writer.Write(srcBuf, imgOffset, imgSize);

                        // Create new icon.
                        destStream.Seek(0, SeekOrigin.Begin);
                        splitIcons.Add(new Icon(destStream));
                    }
                }
            }

            return splitIcons.ToArray();
        }
    }
}
