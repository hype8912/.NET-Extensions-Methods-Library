using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should.Fluent;

namespace PGK.Extensions.Tests
{
	[TestClass]
    public class EnumerableExtensionsTests
	{
		[TestMethod]
		public void FirstOrDefault()
		{
            IEnumerable<Double> list = new List<Double> { 1, 2 };
            IEnumerable<Double> emptyList = new List<Double>();

		    list.FirstOrDefault(999).Should().Equal(1d);
		    emptyList.FirstOrDefault(999).Should().Equal(999d);
		}

        [TestMethod]
        public void IsNullOrEmptyVsIsNotEmpty()
		{
            IEnumerable<Double> list = new List<Double> { 1, 2 };
            IEnumerable<Double> emptyList = new List<Double>();
		    IEnumerable<Double> nullList = null;

            list.IsNullOrEmpty().Should().Be.False();
            list.IsNotEmpty().Should().Be.True();

            emptyList.IsNullOrEmpty().Should().Be.True();
            emptyList.IsNotEmpty().Should().Be.False();

            nullList.IsNullOrEmpty().Should().Be.True();
            nullList.IsNotEmpty().Should().Be.False();
		}
	}
}
