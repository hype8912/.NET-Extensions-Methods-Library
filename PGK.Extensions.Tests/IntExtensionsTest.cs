using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should.Fluent;

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

		[TestMethod]
		public void TestInRange()
		{
			// Arrange
			var value = 5;
			var defaultValue = 9;
			// Act
			var no = value.InRange(6, 10);
			var yes = value.InRange(0, 10);
			var result = value.InRange(6, 10, defaultValue);
			// Assert
			no.Should().Be.False();
			yes.Should().Be.True();
			result.Should().Equal(defaultValue);
		}
	}
}
