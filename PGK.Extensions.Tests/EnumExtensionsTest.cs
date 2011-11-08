using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PGK.Extensions.Tests
{
    [TestClass]
    public class EnumExtensionsTest
    {
        private enum OperatingSystem
        {
            Unknown,

            [DisplayString()]
            Unnamed,

            [DisplayString("MS-DOS")]
            Msdos,

            [DisplayString("Windows 98")]
            Win98,

            [DisplayString("Windows XP")]
            Xp,

            [DisplayString("Windows Vista")]
            Vista,

            [DisplayString("Windows 7")]
            Seven
        }

        [TestMethod]
        public void TestDisplayString()
        {
            OperatingSystem myOS;
            string myOSName;

            myOS = OperatingSystem.Seven;
            myOSName = myOS.DisplayString();
            Assert.AreEqual(myOSName, "Windows 7");

            myOS = OperatingSystem.Unknown;
            myOSName = myOS.DisplayString();
            Assert.AreEqual(myOSName, "Unknown");

            myOS = OperatingSystem.Unnamed;
            myOSName = myOS.DisplayString();
            Assert.AreEqual(myOSName, string.Empty);
        }

        [TestMethod]
        public void TestFlags()
        {
            var regexOptions = new RegexOptions();
            Assert.IsFalse(regexOptions.HasFlag(RegexOptions.Singleline));

            regexOptions = regexOptions.SetFlags(RegexOptions.Singleline, RegexOptions.ECMAScript);
            Assert.IsTrue(regexOptions.HasFlag(RegexOptions.Singleline));
            Assert.IsTrue(regexOptions.HasFlag(RegexOptions.ECMAScript));
            Assert.IsTrue(regexOptions.HasFlags(RegexOptions.ECMAScript));
            Assert.IsTrue(regexOptions.HasFlags(RegexOptions.Singleline, RegexOptions.ECMAScript));
            Assert.IsFalse(regexOptions.HasFlags(RegexOptions.Singleline, RegexOptions.ExplicitCapture));

            regexOptions = regexOptions.SetFlag(RegexOptions.ExplicitCapture);
            regexOptions = regexOptions.ClearFlags(RegexOptions.Singleline, RegexOptions.IgnorePatternWhitespace);
            Assert.IsFalse(regexOptions.HasFlag(RegexOptions.Singleline));
            Assert.IsTrue(regexOptions.HasFlag(RegexOptions.ExplicitCapture));

            regexOptions = regexOptions.ClearFlag(RegexOptions.ExplicitCapture);
            Assert.IsFalse(regexOptions.HasFlag(RegexOptions.ExplicitCapture));
        }
    }
}