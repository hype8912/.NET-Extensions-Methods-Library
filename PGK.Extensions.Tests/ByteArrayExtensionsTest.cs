using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PGK.Extensions.Tests
{
    
    
    /// <summary>
    ///This is a test class for ByteArrayExtensionsTest and is intended
    ///to contain all ByteArrayExtensionsTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ByteArrayExtensionsTest
    {

        /// <summary>
        ///A test for FindArrayInArray
        ///</summary>
        /// <remarks>
        /// 	Contributed by dkillewo, http://www.codeplex.com/site/users/view/dkillewo
        /// </remarks>
        [TestMethod()]
        public void FindArrayInArrayTest()
        {
            var subBytes = new List<byte>{1, 2, 3, 1, 4, 3};
            var bytes = new List<byte> {3, 4, 2, 1, 4, 5, 2};
            bytes.AddRange(subBytes);
            bytes.AddRange(new byte[]{7,4,5,8,3,1});

            var pos = bytes.ToArray().FindArrayInArray(subBytes.ToArray());

            Assert.AreEqual(7,pos);

        }
    }
}
