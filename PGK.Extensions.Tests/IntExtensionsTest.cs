using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PGK.Extensions.Tests
{
    [TestClass]
    public class IntExtensionsTest
    {
        [TestMethod]
        public void TestIsEven()
        {
            /* positive testing */
            int testValue = 4;
            Assert.IsTrue(testValue.IsEven());
            /* negative testing */
            testValue = 3;
            Assert.IsFalse(testValue.IsEven());
        }

        [TestMethod]
        public void TestIsOdd()
        {
            /* positive testing */
            int testValue = 3;
            Assert.IsTrue(testValue.IsOdd());
            /* negative testing */
            testValue = 4;
            Assert.IsFalse(testValue.IsOdd());
        }

    }
}
