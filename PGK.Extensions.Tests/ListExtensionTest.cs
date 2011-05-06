using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PGK.Extensions.Tests
{
    [TestClass]
    public class ListExtensionTest
    {
        [TestMethod]
        public void TestJoinT()
        {
            List<int> list = new List<int>();

            for (int i = 0; i < 100; i++)
            {
                list.Add(i);
            }

            // result needs to be checked up manualy
            //Assert.Inconclusive(list.Join<int>(", "));

            string expected = "";
            for (int i = 0; i < 100; i++)
            {
                expected += i;
                if (i != 99)
                    expected += ", ";
            }
            Assert.AreEqual(list.Join<int>(", "),expected);
        }

        [TestMethod]
        public void InsertUnqiueTest()
        {
            var actual = new List<int> { 1, 2, 3, 4, 5 };
            var expected = new List<int>(actual);
            actual.InsertUnqiue<int>(1, 3);

            Assert.AreEqual(actual.Count, expected.Count, "A not unique item was inserted");

            for (int i = 0; i < actual.Count; i++)
                Assert.AreEqual(expected[i], actual[i]);

            actual.InsertUnqiue<int>(2, 6);

            Assert.AreEqual(actual.Count, expected.Count + 1);
            Assert.AreEqual(actual[2], 6, "Item not correctly inserted");
        }

        [TestMethod]
        public void InsertRangeUniqueTest()
        {
            var actual = new List<int> { 1, 2, 3, 4, 5 };
            var expected = new List<int>(actual);
            expected.InsertRange(3, new int[] { 7, 9, 10 });
            var nValues = new List<int> { 2, 4, 5, 7, 9, 10 };

            actual.InsertRangeUnique(3, nValues);

            Assert.AreEqual(expected.Count, actual.Count, "Wrong amount of items inserted");

            //bug: a revert collection is beeing inserted
            //test will fail here
            for (int i = 0; i < actual.Count; i++)
                Assert.AreEqual(expected[i], actual[i]);
        }
    }
}
