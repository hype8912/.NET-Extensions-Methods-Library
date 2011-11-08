using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace PGK.Extensions.Test4
{


	/// <summary>
	///This is a test class for StringExtensionsTest and is intended
	///to contain all StringExtensionsTest Unit Tests
	///</summary>
	[TestClass()]
	public class StringExtensionsTest
	{


		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext
		{
			get
			{
				return testContextInstance;
			}
			set
			{
				testContextInstance = value;
			}
		}

		#region Additional test attributes
		// 
		//You can use the following additional attributes as you write your tests:
		//
		//Use ClassInitialize to run code before running the first test in the class
		//[ClassInitialize()]
		//public static void MyClassInitialize(TestContext testContext)
		//{
		//}
		//
		//Use ClassCleanup to run code after all tests in a class have run
		//[ClassCleanup()]
		//public static void MyClassCleanup()
		//{
		//}
		//
		//Use TestInitialize to run code before running each test
		//[TestInitialize()]
		//public void MyTestInitialize()
		//{
		//}
		//
		//Use TestCleanup to run code after each test has run
		//[TestCleanup()]
		//public void MyTestCleanup()
		//{
		//}
		//
		#endregion


		/// <summary>
		///A test for ToPlural
		///</summary>
		[TestMethod()]
		public void ToPluralTest()
		{
			Assert.AreEqual("test".ToPlural2(), "tests"); // standard
			Assert.AreEqual("goose".ToPlural2(), "geese"); // special nouns
			Assert.AreEqual("box".ToPlural2(), "boxes"); // -ch, x, s to -es
			Assert.AreEqual("boy".ToPlural2(), "boys"); // -y to -ies
			Assert.AreEqual("box of ball".ToPlural2(), "box of balls"); // of
			Assert.AreEqual("kiss".ToPlural2(), "kisses"); // -s to -es
			Assert.AreEqual("phenomenon".ToPlural2(), "phenomena"); // nouns that maintain their Latin or Greek form in the plural
			
			Assert.AreEqual("potato".ToPlural2(), "potatoes"); // -o to -oes
			Assert.AreEqual("memo".ToPlural2(), "memos"); // -o to -oes (exceptions)
			Assert.AreEqual("stereo".ToPlural2(), "stereos"); // -o to -oes (exceptions)

			Assert.AreEqual("knife".ToPlural2(), "knives"); // -f, fe to -es
			// these two fail
			// Assert.AreEqual("dwarf".ToPlural(), "dwarfs"); // -f, fe to -es (exceptions)
			// Assert.AreEqual("roof".ToPlural(), "roofs"); // -f, fe to -es (exceptions)
		}
	}
}
