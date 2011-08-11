using System;
using System.Globalization;
using System.Security;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should.Fluent;

namespace PGK.Extensions.Tests
{
    [TestClass]
    public class StringExtensionsTest
    {
        [TestMethod]
        public void TestIsEmpty()
        {
            /* positive testing */
            String testValue = String.Empty;
            Assert.IsTrue(testValue.IsEmpty());
            /* negative testing */
            testValue = "non empty";
            Assert.IsFalse(testValue.IsEmpty());
        }

        [TestMethod]
        public void TestIsNotEmpty()
        {
            /* positive testing */
            String testValue = "the quick brown fox jumps over the lazy dog.";
            Assert.IsTrue(testValue.IsNotEmpty());
            /* negative testing */
            testValue = String.Empty;
            Assert.IsFalse(testValue.IsNotEmpty());

        }

        [TestMethod]
        public void TestIfEmpty()
        {
            /* positive testing */
            String testValue = String.Empty;
            String defaultValue = "default";
            Assert.AreEqual(testValue.IfEmpty(defaultValue), defaultValue);
            /* negative testing */
            testValue = "not default";
            defaultValue = "default";
            Assert.AreNotEqual(testValue.IfEmpty(defaultValue), defaultValue);

        }

        [TestMethod]
        public void TestTrimToMaxLength()
        {
            /* test for overloaded method with 1 parameter */

            /* positive testing */
            String testValue = "the quick brown fox jumps over the lazy dog.";
            String resultValue = "the quick brown fox";
            Assert.AreEqual(testValue.TrimToMaxLength(19), resultValue);
            /* negative testing */
            Assert.AreNotEqual(testValue.TrimToMaxLength(18), resultValue);

            /* test for overloaded method with 2 parameter */
            /* #TODO */
        }

        [TestMethod]
        public void TestReverse()
        {
            /* positive testing */
            String testValue = "dnpextensions";
            String validationValue = "snoisnetxepnd";
            Assert.AreEqual(testValue.Reverse(), validationValue);
            /* negative testing */
            validationValue = "snoisnetxepdn";
            Assert.AreNotEqual(testValue.Reverse(), validationValue);
        }

        [TestMethod]
        public void TestEnsureStartsWith()
        {
            /* positive testing */
            var extension = "txt";
            var validationValue = ".txt";
            Assert.AreEqual(extension.EnsureStartsWith("."), validationValue);
            /* negative testing */
            validationValue = ":txt";
            Assert.AreNotEqual(extension.EnsureStartsWith("."), validationValue);
        }

        [TestMethod]
        public void TestEnsureEndsWith()
        {
            /* positive testing */
            var url = "http://www.pgk.de";
            var validationValue = "http://www.pgk.de/";
            Assert.AreEqual(url.EnsureEndsWith("/"), validationValue);
            /* negative testing */
            validationValue = @"http://www.pgk.de\";
            Assert.AreNotEqual(url.EnsureEndsWith("/"), validationValue);
        }

        [TestMethod]
        public void TestRepeat()
        {
            /* positive testing */
            var character = "a";
            var validationValue = "aaaaa";
            Assert.AreEqual(character.Repeat(5), validationValue);
            /* negative testing */
            Assert.AreNotEqual(character.Repeat(4), validationValue);
        }

        [TestMethod]
        public void TestIsnumeric()
        {
            SetDotAsDecimalSeparator();

            /* positive testing */
            var validationValue = "12345";
            Assert.IsTrue(validationValue.IsNumeric());
            validationValue = "1123.45";
            Assert.IsTrue(validationValue.IsNumeric());
            /* negative testing */
            validationValue = "123$a45";
            Assert.IsFalse(validationValue.IsNumeric());
        }

        [TestMethod]
        public void TestExtractDigits()
        {
            /* positive testing */
            var testValue = @"1aO2%&3(45=\";
            var validationValue = "12345";
            Assert.AreEqual(testValue.ExtractDigits(), validationValue);
        }

        [TestMethod]
        public void TestAdjustString()
        {
            string testValue = @"%&btf678&//(b hbg";
            string validationValue = @"btf678bhbg";
            Assert.AreEqual(testValue.AdjustInput(), validationValue);
        }

        [TestMethod]
        public void TestRemoveAllSpecialCharacters()
        {
            string testValue = @"%&btf678&//(b hbg";
            string validationValue = @"btf678bhbg";
            Assert.AreEqual(testValue.RemoveAllSpecialCharacters(), validationValue);
        }

        [TestMethod]
        public void TestIsEmptyOrWhiteSpace()
        {
            string notEmpty = "NotEmpty";
            string withSpaces = "     ";
            string empty = string.Empty;

            Assert.IsFalse(notEmpty.IsEmptyOrWhiteSpace());
            Assert.IsTrue(withSpaces.IsEmptyOrWhiteSpace());
            Assert.IsTrue(empty.IsEmptyOrWhiteSpace());
        }

        [TestMethod]
        public void ToTitleCase()
        {
            var testValue = "this is a test";
            var expectedResult = "This Is A Test";
            var weirdTestValue = "this IS a tEst";

            var result = testValue.ToTitleCase();
            var result2 = weirdTestValue.ToTitleCase();

            Assert.AreEqual(result, expectedResult);
            Assert.AreNotEqual(result, testValue);
        }

        [TestMethod]
        public void SpaceOnUpper()
        {
            var value = "MyCamelCaseString";
            var expectedResult = "My Camel Case String";

            var numberTestValue = "MyCamel101CaseString";
            var expectedNumberTestResult = "My Camel 101 Case String";

            var allCaseTestValue = "MYCAMELCASESTRING";

            var result = value.SpaceOnUpper();
            var numberResult = numberTestValue.SpaceOnUpper();
            var allCaseresult = allCaseTestValue.SpaceOnUpper();

            Assert.AreEqual(result, expectedResult);
            Assert.AreNotEqual(result, value);

            // should put space even for number
            Assert.AreEqual(numberResult, expectedNumberTestResult);

            // shouldn't change
            Assert.AreEqual(allCaseresult, allCaseTestValue);
        }

        [TestMethod]
        public void TestPadBoth()
        {
            string baseString = "asdfqwer";
            string expectedResult = "--asdfqwer--";
            Assert.AreEqual(expectedResult, baseString.PadBoth(12, '-'));

            // test with truncate
            expectedResult = "asdf";
            Assert.AreEqual(expectedResult, baseString.PadBoth(4, '-', true));
        }

        [TestMethod]
        public void SecureStringConversion()
        {
            string testValue = @"asdf";
            SecureString validationValue = testValue.ToSecureString();
            Assert.AreEqual(testValue, validationValue.ToUnsecureString());
        }

        [TestMethod]
        public void ContainsEquivalenceTo()
        {
            string value;

            value = null;
            value.ContainsEquivalenceTo("something else").Should().Be.False();
            value.ContainsEquivalenceTo(null).Should().Be.True();

            value = "string containting the VaLuE with different case for each letter";
            value.ContainsEquivalenceTo("value").Should().Be.True();
            value.ContainsEquivalenceTo("VALUE").Should().Be.True();
            value.ContainsEquivalenceTo("VaLuE").Should().Be.True();

            value.ContainsEquivalenceTo("Not value").Should().Be.False();
        }

        [TestMethod]
        public void EquivalentTo()
        {
            string value;

            value = null;
            value.EquivalentTo("something else").Should().Be.False();
            value.EquivalentTo(null).Should().Be.True();

            value = "VaLuE";
            value.EquivalentTo("value").Should().Be.True();
            value.EquivalentTo("VALUE").Should().Be.True();
            value.EquivalentTo("VaLuE").Should().Be.True();
        }

        /// <summary>Tests the SubstringFrom(int index) from StringExtensions.cs</summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestSubstringFrom()
        {
            string testValue = null;

            testValue = "dnpextensions";

            Assert.AreEqual(testValue.SubstringFrom(0), "dnpextensions");
            Assert.AreEqual(testValue.SubstringFrom(1), "npextensions");
            Assert.AreEqual(testValue.SubstringFrom(5), "tensions");
            Assert.AreEqual(testValue.SubstringFrom(20), string.Empty);
        }

        private static void SetDotAsDecimalSeparator()
        {
            var copy = Thread.CurrentThread.CurrentCulture.Clone().CastTo<CultureInfo>();

            copy.NumberFormat.NumberDecimalSeparator = ".";
            Thread.CurrentThread.CurrentCulture = copy;
        }
    }
}
