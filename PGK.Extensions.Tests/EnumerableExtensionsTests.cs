using System;
using System.Collections.Generic;
using System.Linq;
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

        [TestMethod]
        public void TestAppend()
        {
            var ints = Enumerable.Range(0, 3);
            ints = ints.Append(3);

            new[] { 0, 1, 2, 3 }.SequenceEqual(ints).Should().Be.True();
        }

        [TestMethod]
        public void TestPrepend()
        {
            var ints = Enumerable.Range(1, 3);
            ints = ints.Prepend(0);

            new[] { 0, 1, 2, 3 }.SequenceEqual(ints).Should().Be.True();
        }

        [TestMethod]
        public void TestToArray()
        {
            var intStrings = Enumerable.Range(1, 3).ToArray(i => i.ToString());

            new[] { "1", "2", "3" }.SequenceEqual(intStrings).Should().Be.True();
        }

        [TestMethod]
        public void TestToList()
        {
            var intStrings = Enumerable.Range(1, 3).ToList(i => i.ToString());

            new[] { "1", "2", "3" }.SequenceEqual(intStrings).Should().Be.True();
        }

        [TestMethod]
        public void TestSum()
        {
            // test uint sum
            var uints = Enumerable.Range(1, 5).ToList(i => (uint)i);
            uints.Sum().Should().Equal(15U);

            // test ulong sum
            var ulongs = Enumerable.Range(1, 5).ToList(i => (ulong)i);
            ulongs.Sum().Should().Equal(15UL);

            // test uint? sum
            var nullableUints = new uint?[] { 1, 2, 3, 4, 5, null };
            nullableUints.Sum().Should().Equal(15U);

            nullableUints = new uint?[0];
            nullableUints.Sum().Should().Equal(0U);

            nullableUints = new uint?[] { null };
            nullableUints.Sum().Should().Equal(0U);

            // test ulong? sum
            var nullableUlongs = new ulong?[] { 1, 2, 3, 4, 5, null };
            nullableUlongs.Sum().Should().Equal(15UL);

            nullableUlongs = new ulong?[0];
            nullableUlongs.Sum().Should().Equal(0UL);

            nullableUlongs = new ulong?[] { null };
            nullableUlongs.Sum().Should().Equal(0UL);
        }
	}
}