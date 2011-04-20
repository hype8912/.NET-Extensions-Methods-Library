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
            Assert.Inconclusive(list.Join<int>(", "));
        }
    }
}
