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
		public void TestGetKeyValue()
		{
			// Arrange
			var session = new Dictionary<int, string>
			              {
			              	{
			              		1, "test"
			              		},
			              	{
			              		2, "MT"
			              		}
			              };
			// Act
			var result = session.GetKeyValue(2, "error");
			var defaultValueResult = session.GetKeyValue(3, "error");

			// Assert
			result.Should().Equal("MT");
			result.Should().Not.Equal("test");
			defaultValueResult.Should().Equal("error");
			defaultValueResult.Should().Not.Equal("test");
		}

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
	}
}