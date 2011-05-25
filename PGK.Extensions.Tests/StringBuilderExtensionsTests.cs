using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Should.Fluent;

namespace PGK.Extensions.Tests
{
	[TestClass]
    public class StringBuilderExtensionsTests
	{
		[TestMethod]
		public void AppendLineWithFormat()
		{
		    var builder = new StringBuilder();
		    string result;

            // Arrange
		    builder.AppendLine("Something to format ({0}.{1}) with a new line after", "String", "Format");
		    // Act
            result = builder.ToString();
		    // Assert
            result.Should().Not.Be.NullOrEmpty();
		    result.Split(Environment.NewLine).Should().Count.Exactly(2);
            result.Split(Environment.NewLine)[0].Should().Equal("Something to format (String.Format) with a new line after");
            result.Split(Environment.NewLine)[1].Should().Be.Empty();
		}
	}
}
