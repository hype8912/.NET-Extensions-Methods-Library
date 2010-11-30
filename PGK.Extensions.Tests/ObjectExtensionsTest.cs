using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should.Fluent;

namespace PGK.Extensions.Tests
{
	[TestClass]
	public class ObjectExtensionsTest
	{
		[TestMethod]
		public void TestCastTo()
		{
			// Arrange
			var value = "test";

			// Act
			var result = value.CastTo<Int32>();

			// Assert
			result.Should().Equal(null);
		}

		[TestMethod]
		public void TestCastAs()
		{
			// Arrange
			var value = new List<string>();

			// Act
			var result = value.CastAs<List<string>>();

			// Assert
			result.Should().Equal(new List<string>());
		}

		[TestMethod]
		public void TestConvertTo()
		{
			// Arrange
			var value = 123m;

			// Act
			var result = value.ConvertTo<Decimal>();

			// Assert
			result.Should().Equal(value);
			result.Should().Not.Equal("test");
		}
	}
}