﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PGK.Extensions.Tests
{
	[TestClass]
	public class StringExtensionsTest
	{
		[TestMethod]
		public void TestIsEmpty()
		{
			/* positive testing */
			String testValue = String.Empty;
			Assert.IsTrue(testValue.IsEmpty());
			/* negative testing */
			testValue = "non empty";
			Assert.IsFalse(testValue.IsEmpty());
		}

		[TestMethod]
		public void TestIsNotEmpty()
		{
			/* positive testing */
			String testValue = "the quick brown fox jumps over the lazy dog.";
			Assert.IsTrue(testValue.IsNotEmpty());
			/* negative testing */
			testValue = String.Empty;
			Assert.IsFalse(testValue.IsNotEmpty());

		}

		[TestMethod]
		public void TestIfEmpty()
		{
			/* positive testing */
			String testValue = String.Empty;
			String defaultValue = "default";
			Assert.AreEqual(testValue.IfEmpty(defaultValue), defaultValue);
			/* negative testing */
			testValue = "not default";
			defaultValue = "default";
			Assert.AreNotEqual(testValue.IfEmpty(defaultValue), defaultValue);

		}

		[TestMethod]
		public void TestTrimToMaxLength()
		{
			/* test for overloaded method with 1 parameter */

			/* positive testing */
			String testValue = "the quick brown fox jumps over the lazy dog.";
			String resultValue = "the quick brown fox";
			Assert.AreEqual(testValue.TrimToMaxLength(19), resultValue);
			/* negative testing */
			Assert.AreNotEqual(testValue.TrimToMaxLength(18), resultValue);

			/* test for overloaded method with 2 parameter */
			/* #TODO */
		}

		[TestMethod]
		public void TestReverse()
		{
			/* positive testing */
			String testValue = "dnpextensions";
			String validationValue = "snoisnetxepnd";
			Assert.AreEqual(testValue.Reverse(), validationValue);
			/* negative testing */
			validationValue = "snoisnetxepdn";
			Assert.AreNotEqual(testValue.Reverse(), validationValue);
		}

		[TestMethod]
		public void TestEnsureStartsWith()
		{
			/* positive testing */
			var extension = "txt";
			var validationValue = ".txt";
			Assert.AreEqual(extension.EnsureStartsWith("."), validationValue);
			/* negative testing */
			validationValue = ":txt";
			Assert.AreNotEqual(extension.EnsureStartsWith("."), validationValue);
		}

		[TestMethod]
		public void TestEnsureEndsWith()
		{
			/* positive testing */
			var url = "http://www.pgk.de";
			var validationValue = "http://www.pgk.de/";
			Assert.AreEqual(url.EnsureEndsWith("/"), validationValue);
			/* negative testing */
			validationValue = @"http://www.pgk.de\";
			Assert.AreNotEqual(url.EnsureEndsWith("/"), validationValue);
		}

		[TestMethod]
		public void TestRepeat()
		{
			/* positive testing */
			var character = "a";
			var validationValue = "aaaaa";
			Assert.AreEqual(character.Repeat(5), validationValue);
			/* negative testing */
			Assert.AreNotEqual(character.Repeat(4), validationValue);
		}

		[TestMethod]
		public void TestIsnumeric()
		{
			/* positive testing */
			var validationValue = "12345";
			Assert.IsTrue(validationValue.IsNumeric());
			validationValue = "1123.45";
			Assert.IsTrue(validationValue.IsNumeric());
			/* negative testing */
			validationValue = "123$a45";
			Assert.IsFalse(validationValue.IsNumeric());
		}

		[TestMethod]
		public void TestExtractDigits()
		{
			/* positive testing */
			var testValue = @"1aO2%&3(45=\";
			var validationValue = "12345";
			Assert.AreEqual(testValue.ExtractDigits(), validationValue);
		}

		[TestMethod]
		public void TestAdjustString()
		{
			string testValue = @"%&btf678&//(b hbg";
			string validationValue = @"btf678bhbg";
			Assert.AreEqual(testValue.AdjustInput(), validationValue);
		}

		[TestMethod]
		public void TestRemoveAllSpecialCharacters()
		{
			string testValue = @"%&btf678&//(b hbg";
			string validationValue = @"btf678bhbg";
			Assert.AreEqual(testValue.RemoveAllSpecialCharacters(), validationValue);
		}

		[TestMethod]
		public void TestIsEmptyOrWhiteSpace()
		{

		}
	}
}
