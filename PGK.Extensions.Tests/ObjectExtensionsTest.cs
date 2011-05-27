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
			string value = "test";

			// Act
			int result = value.CastTo<Int32>();

			// Assert
			result.Should().Equal(default(int));
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
		public void TestConvertToAndIgnoreException()
		{
			const string invalidValue = "test";
			const string stringValue = "1234";
			const int value = 1234;
			const int defaultValue = 999;

            invalidValue.ConvertToAndIgnoreException<int>().Should().Equal(0);
            invalidValue.ConvertToAndIgnoreException(defaultValue).Should().Equal(defaultValue);

            stringValue.ConvertToAndIgnoreException<int>().Should().Equal(value);
            stringValue.ConvertToAndIgnoreException(defaultValue).Should().Equal(value);
		}

        [TestMethod, ExpectedException(typeof(Exception))]
		public void TestConvertToAgainstNotConvertibleStringOnly()
		{
			"NotConvertibleToInt".ConvertTo<int>();
		}

		[TestMethod]
		public void TestConvertToAgainstStringDigit()
		{
			// Arrange
			var value = 123;
			var stringValue = "123";

			// Act
			var stringResult = stringValue.ConvertTo<int>();

			// Assert
			stringResult.Should().Equal(value);
			stringResult.Should().Not.Equal(0);
		}
	}
}