using System;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should.Fluent;

namespace PGK.Extensions.Tests
{
	[TestClass]
	public class DictionaryExtensionsTests
	{
		[TestMethod]
		public void TestSort()
		{
			// Arrange
			var notSortedDictionary = new Dictionary<int, string>
			                          {
			                          	{1, "a"},
			                          	{3, "c"},
			                          	{2, "b"}
			                          };
			var sortedDictionary = new Dictionary<int, string>
			                          {
			                          	{1, "a"},
			                          	{2, "b"},
																	{3, "c"},
			                          };
			// Act
			var result = notSortedDictionary.Sort();
			var sortByCompareResult = notSortedDictionary.Sort(new ComparableExtensions.AscendingComparer<int>());

			// Assert
			result.Should().Equal(sortedDictionary);
			result.Should().Not.Equal(notSortedDictionary);
			sortByCompareResult.Should().Equal(sortedDictionary);
		}

		[TestMethod]
		public void TestSortByValue()
		{
			// Arrange
			var notSortedDictionary = new Dictionary<int, string>
			                          {
			                          	{1, "a"},
			                          	{3, "c"},
			                          	{2, "b"}
			                          };
			var sortedDictionary = new Dictionary<int, string>
			                          {
			                          	{1, "a"},
			                          	{2, "b"},
																	{3, "c"},
			                          };
			// Act
			var result = notSortedDictionary.SortByValue();

			// Assert
			result.Should().Equal(sortedDictionary);
			result.Should().Not.Equal(notSortedDictionary);
		}

		[TestMethod]
		public void TestInvert()
		{
			// Arrange
			var notInvertedDictionary = new Dictionary<int, string>
			                          {
			                          	{1, "a"},
			                          	{2, "b"},
			                          	{3, "c"},
			                          };
			var invertedDictionary = new Dictionary<string, int>
			                          {
																	{"a", 1},
																	{"b", 2},
																	{"c", 3}
			                          };
			// Act
			var result = notInvertedDictionary.Invert();

			// Assert
			result.Should().Equal(invertedDictionary);
			result.GetType().Should().Not.Equal(notInvertedDictionary);
		}

		[TestMethod]
		public void TestToHashTable()
		{
			// Arrange
			var ht = new Hashtable
			         {
			         	{"house", "Dwelling"},
			         	{"car", "Means of transport"},
			         	{"book", "Collection of printed words"},
			         	{"apple", "Edible fruit"}
			         };
			// Add elements to the table 

			var dic = new Dictionary<string, string>
			          {
			          	{"house", "Dwelling"},
			         		{"car", "Means of transport"},
			         		{"book", "Collection of printed words"},
			         		{"apple", "Edible fruit"}
			          };
			// Act
			var result = dic.ToHashTable();

			// Assert
			result.Should().Equal(ht);
			result.Should().Not.Equal(dic);
		}
	}
}
