using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PGK.Extensions.Tests
{
	[TestClass]
	public class DateTimeExtensionTest
	{
		[TestMethod]
		public void TestGetDaysInYear()
		{
			/* positive testing */
			var testValue = new DateTime(2010);
			var resultValue = 365;
			Assert.AreEqual(testValue.GetDays(), resultValue);
			/* negative testing */
			testValue = DateTime.Now.AddYears(1);
			Assert.AreNotEqual(testValue.GetDays(), resultValue);
		}
	}
}
