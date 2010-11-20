using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
    }
}
