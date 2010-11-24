﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

/// <summary>
/// 	Extension methods for the string data type
/// </summary>
public static class StringExtensions
{
	#region Common string extensions

	/// <summary>
	/// 	Determines whether the specified string is null or empty.
	/// </summary>
	/// <param name = "value">The string value to check.</param>
	public static bool IsEmpty(this string value)
	{
		return ((value == null) || (value.Length == 0));
	}

	/// <summary>
	/// 	Determines whether the specified string is not null or empty.
	/// </summary>
	/// <param name = "value">The string value to check.</param>
	public static bool IsNotEmpty(this string value)
	{
		return (value.IsEmpty() == false);
	}

	/// <summary>
	/// 	Checks whether the string is empty and returns a default value in case.
	/// </summary>
	/// <param name = "value">The string to check.</param>
	/// <param name = "defaultValue">The default value.</param>
	/// <returns>Either the string or the default value.</returns>
	public static string IfEmpty(this string value, string defaultValue)
	{
		return (value.IsNotEmpty() ? value : defaultValue);
	}

	/// <summary>
	/// 	Formats the value with the parameters using string.Format.
	/// </summary>
	/// <param name = "value">The input string.</param>
	/// <param name = "parameters">The parameters.</param>
	/// <returns></returns>
	public static string FormatWith(this string value, params object[] parameters)
	{
		return string.Format(value, parameters);
	}

	/// <summary>
	/// 	Trims the text to a provided maximum length.
	/// </summary>
	/// <param name = "value">The input string.</param>
	/// <param name = "maxLength">Maximum length.</param>
	/// <returns></returns>
	/// <remarks>
	/// 	Proposed by Rene Schulte
	/// </remarks>
	public static string TrimToMaxLength(this string value, int maxLength)
	{
		return (value == null || value.Length <= maxLength ? value : value.Substring(0, maxLength));
	}

	/// <summary>
	/// 	Trims the text to a provided maximum length and adds a suffix if required.
	/// </summary>
	/// <param name = "value">The input string.</param>
	/// <param name = "maxLength">Maximum length.</param>
	/// <param name = "suffix">The suffix.</param>
	/// <returns></returns>
	/// <remarks>
	/// 	Proposed by Rene Schulte
	/// </remarks>
	public static string TrimToMaxLength(this string value, int maxLength, string suffix)
	{
		return (value == null || value.Length <= maxLength ? value : string.Concat(value.Substring(0, maxLength), suffix));
	}

	/// <summary>
	/// 	Determines whether the comparison value strig is contained within the input value string
	/// </summary>
	/// <param name = "inputValue">The input value.</param>
	/// <param name = "comparisonValue">The comparison value.</param>
	/// <param name = "comparisonType">Type of the comparison to allow case sensitive or insensitive comparison.</param>
	/// <returns>
	/// 	<c>true</c> if input value contains the specified value, otherwise, <c>false</c>.
	/// </returns>
	public static bool Contains(this string inputValue, string comparisonValue, StringComparison comparisonType)
	{
		return (inputValue.IndexOf(comparisonValue, comparisonType) != -1);
	}

	/// <summary>
	/// 	Loads the string into a LINQ to XML XDocument
	/// </summary>
	/// <param name = "xml">The XML string.</param>
	/// <returns>The XML document object model (XDocument)</returns>
	public static XDocument ToXDocument(this string xml)
	{
		return XDocument.Parse(xml);
	}

	/// <summary>
	/// 	Loads the string into a XML DOM object (XmlDocument)
	/// </summary>
	/// <param name = "xml">The XML string.</param>
	/// <returns>The XML document object model (XmlDocument)</returns>
	public static XmlDocument ToXmlDOM(this string xml)
	{
		var document = new XmlDocument();
		document.LoadXml(xml);
		return document;
	}

	/// <summary>
	/// 	Loads the string into a XML XPath DOM (XPathDocument)
	/// </summary>
	/// <param name = "xml">The XML string.</param>
	/// <returns>The XML XPath document object model (XPathNavigator)</returns>
	public static XPathNavigator ToXPath(this string xml)
	{
		var document = new XPathDocument(new StringReader(xml));
		return document.CreateNavigator();
	}

	/// <summary>
	/// 	Reverses / mirrors a string.
	/// </summary>
	/// <param name = "value">The string to be reversed.</param>
	/// <returns>The reversed string</returns>
	public static string Reverse(this string value)
	{
		if (value.IsEmpty() || (value.Length == 1))
			return value;

		var chars = value.ToCharArray();
		Array.Reverse(chars);
		return new string(chars);
	}

	/// <summary>
	/// 	Ensures that a string starts with a given prefix.
	/// </summary>
	/// <param name = "value">The string value to check.</param>
	/// <param name = "prefix">The prefix value to check for.</param>
	/// <returns>The string value including the prefix</returns>
	/// <example>
	/// 	<code>
	/// 		var extension = "txt";
	/// 		var fileName = string.Concat(file.Name, extension.EnsureStartsWith("."));
	/// 	</code>
	/// </example>
	public static string EnsureStartsWith(this string value, string prefix)
	{
		return value.StartsWith(prefix) ? value : string.Concat(prefix, value);
	}

	/// <summary>
	/// 	Ensures that a string ends with a given suffix.
	/// </summary>
	/// <param name = "value">The string value to check.</param>
	/// <param name = "suffix">The suffix value to check for.</param>
	/// <returns>The string value including the suffix</returns>
	/// <example>
	/// 	<code>
	/// 		var url = "http://www.pgk.de";
	/// 		url = url.EnsureEndsWith("/"));
	/// 	</code>
	/// </example>
	public static string EnsureEndsWith(this string value, string suffix)
	{
		return value.EndsWith(suffix) ? value : string.Concat(value, suffix);
	}

	/// <summary>
	/// 	Repeats the specified string value as provided by the repeat count.
	/// </summary>
	/// <param name = "value">The original string.</param>
	/// <param name = "repeatCount">The repeat count.</param>
	/// <returns>The repeated string</returns>
	public static string Repeat(this string value, int repeatCount)
	{
		var sb = new StringBuilder();
		repeatCount.Times(() => sb.Append(value));
		return sb.ToString();
	}

	/// <summary>
	/// 	Tests whether the contents of a string is a numeric value
	/// </summary>
	/// <param name = "value">String to check</param>
	/// <returns>
	/// 	Boolean indicating whether or not the string contents are numeric
	/// </returns>
	/// <remarks>
	/// 	Contributed by Kenneth Scott
	/// </remarks>
	public static bool IsNumeric(this string value)
	{
		float output;
		return float.TryParse(value, out output);
	}

	/// <summary>
	/// 	Extracts all digits from a string.
	/// </summary>
	/// <param name = "value">String containing digits to extract</param>
	/// <returns>
	/// 	All digits contained within the input string
	/// </returns>
	/// <remarks>
	/// 	Contributed by Kenneth Scott
	/// </remarks>
	public static string ExtractDigits(this string value)
	{
		return string.Join(null, Regex.Split(value, "[^\\d]"));
	}

	/// <summary>
	/// 	Concatenates the specified string value with the passed additional strings.
	/// </summary>
	/// <param name = "value">The original value.</param>
	/// <param name = "values">The additional string values to be concatenated.</param>
	/// <returns>The concatenated string.</returns>
	public static string ConcatWith(this string value, params string[] values)
	{
		return string.Concat(value, string.Concat(values));
	}

	/// <summary>
	/// 	Convert the provided string to a Guid value.
	/// </summary>
	/// <param name = "value">The original string value.</param>
	/// <returns>The Guid</returns>
	public static Guid ToGuid(this string value)
	{
		return new Guid(value);
	}

	/// <summary>
	/// 	Convert the provided string to a Guid value and returns Guid.Empty if conversion fails.
	/// </summary>
	/// <param name = "value">The original string value.</param>
	/// <returns>The Guid</returns>
	public static Guid ToGuidSave(this string value)
	{
		return value.ToGuidSave(Guid.Empty);
	}

	/// <summary>
	/// 	Convert the provided string to a Guid value and returns the provided default value if the conversion fails.
	/// </summary>
	/// <param name = "value">The original string value.</param>
	/// <param name = "defaultValue">The default value.</param>
	/// <returns>The Guid</returns>
	public static Guid ToGuidSave(this string value, Guid defaultValue)
	{
		if (value.IsEmpty())
			return defaultValue;

		try
		{
			return value.ToGuid();
		}
		catch
		{}

		return defaultValue;
	}

	/// <summary>
	/// 	Gets the string before the given string parameter.
	/// </summary>
	/// <param name = "value">The default value.</param>
	/// <param name = "x">The given string parameter.</param>
	/// <returns></returns>
	public static string GetBefore(this string value, string x)
	{
		var xPos = value.IndexOf(x);
		return xPos == -1 ? String.Empty : value.Substring(0, xPos);
	}

	/// <summary>
	/// 	Gets the string between the given string parameters.
	/// </summary>
	/// <param name = "value">The default value.</param>
	/// <param name = "x">The left string parameter.</param>
	/// <param name = "y">The right string parameter</param>
	/// <returns></returns>
	public static string GetBetween(this string value, string x, string y)
	{
		var xPos = value.IndexOf(x);
		var yPos = value.LastIndexOf(y);

		if (xPos == -1 || xPos == -1)
			return String.Empty;

		var startIndex = xPos + x.Length;
		return startIndex >= yPos ? String.Empty : value.Substring(startIndex, yPos - startIndex).Trim();
	}

	/// <summary>
	/// 	Gets the string after the given string parameter.
	/// </summary>
	/// <param name = "value">The default value.</param>
	/// <param name = "x">The given string parameter.</param>
	/// <returns></returns>
	public static string GetAfter(this string value, string x)
	{
		var xPos = value.LastIndexOf(x);

		if (xPos == -1)
			return String.Empty;

		var startIndex = xPos + x.Length;
		return startIndex >= value.Length ? String.Empty : value.Substring(startIndex).Trim();
	}

	/// <summary>
	/// 	A generic version of System.String.Join()
	/// </summary>
	/// <typeparam name = "T">
	/// 	The type of the array to join
	/// </typeparam>
	/// <param name = "separator">
	/// 	The separator to appear between each element
	/// </param>
	/// <param name = "value">
	/// 	An array of values
	/// </param>
	/// <returns>
	/// 	The join.
	/// </returns>
	public static string Join<T>(string separator, T[] value)
	{
		if (value == null || value.Length == 0)
			return string.Empty;
		if (separator == null)
			separator = string.Empty;
		Converter<T, string> converter = o => o.ToString();
		return string.Join(separator, Array.ConvertAll(value, converter));
	}

	/// <summary>
	/// 	Remove any instance of the given character from the current string.
	/// </summary>
	/// <param name = "value">
	/// 	The input.
	/// </param>
	/// <param name = "removeCharc">
	/// 	The remove char.
	/// </param>
	public static string Remove(this string value, params char[] removeCharc)
	{
		var result = value;
		if (!string.IsNullOrEmpty(result) && removeCharc != null)
			Array.ForEach(removeCharc, c => result = result.Remove(c.ToString()));

		return result;
	}

	/// <summary>
	/// 	Remove any instance of the given string pattern from the current string.
	/// </summary>
	/// <param name = "value">
	/// 	The input.
	/// </param>
	/// <param name = "removeStrings">
	/// 	The remove Strings.
	/// </param>
	public static string Remove(this string value, params string[] removeStrings)
	{
		var result = value;
		if (!string.IsNullOrEmpty(result) && removeStrings != null)
			Array.ForEach(removeStrings, s => result = result.Replace(s, string.Empty));

		return result;
	}

	#endregion
	#region Regex based extension methods

	/// <summary>
	/// 	Uses regular expressions to determine if the string matches to a given regex pattern.
	/// </summary>
	/// <param name = "value">The input string.</param>
	/// <param name = "regexPattern">The regular expression pattern.</param>
	/// <returns>
	/// 	<c>true</c> if the value is matching to the specified pattern; otherwise, <c>false</c>.
	/// </returns>
	/// <example>
	/// 	<code>
	/// 		var s = "12345";
	/// 		var isMatching = s.IsMatchingTo(@"^\d+$");
	/// 	</code>
	/// </example>
	public static bool IsMatchingTo(this string value, string regexPattern)
	{
		return IsMatchingTo(value, regexPattern, RegexOptions.None);
	}

	/// <summary>
	/// 	Uses regular expressions to determine if the string matches to a given regex pattern.
	/// </summary>
	/// <param name = "value">The input string.</param>
	/// <param name = "regexPattern">The regular expression pattern.</param>
	/// <param name = "options">The regular expression options.</param>
	/// <returns>
	/// 	<c>true</c> if the value is matching to the specified pattern; otherwise, <c>false</c>.
	/// </returns>
	/// <example>
	/// 	<code>
	/// 		var s = "12345";
	/// 		var isMatching = s.IsMatchingTo(@"^\d+$");
	/// 	</code>
	/// </example>
	public static bool IsMatchingTo(this string value, string regexPattern, RegexOptions options)
	{
		return Regex.IsMatch(value, regexPattern, options);
	}

	/// <summary>
	/// 	Uses regular expressions to replace parts of a string.
	/// </summary>
	/// <param name = "value">The input string.</param>
	/// <param name = "regexPattern">The regular expression pattern.</param>
	/// <param name = "replaceValue">The replacement value.</param>
	/// <returns>The newly created string</returns>
	/// <example>
	/// 	<code>
	/// 		var s = "12345";
	/// 		var replaced = s.ReplaceWith(@"\d", m => string.Concat(" -", m.Value, "- "));
	/// 	</code>
	/// </example>
	public static string ReplaceWith(this string value, string regexPattern, string replaceValue)
	{
		return ReplaceWith(value, regexPattern, replaceValue, RegexOptions.None);
	}

	/// <summary>
	/// 	Uses regular expressions to replace parts of a string.
	/// </summary>
	/// <param name = "value">The input string.</param>
	/// <param name = "regexPattern">The regular expression pattern.</param>
	/// <param name = "replaceValue">The replacement value.</param>
	/// <param name = "options">The regular expression options.</param>
	/// <returns>The newly created string</returns>
	/// <example>
	/// 	<code>
	/// 		var s = "12345";
	/// 		var replaced = s.ReplaceWith(@"\d", m => string.Concat(" -", m.Value, "- "));
	/// 	</code>
	/// </example>
	public static string ReplaceWith(this string value, string regexPattern, string replaceValue, RegexOptions options)
	{
		return Regex.Replace(value, regexPattern, replaceValue, options);
	}

	/// <summary>
	/// 	Uses regular expressions to replace parts of a string.
	/// </summary>
	/// <param name = "value">The input string.</param>
	/// <param name = "regexPattern">The regular expression pattern.</param>
	/// <param name = "evaluator">The replacement method / lambda expression.</param>
	/// <returns>The newly created string</returns>
	/// <example>
	/// 	<code>
	/// 		var s = "12345";
	/// 		var replaced = s.ReplaceWith(@"\d", m => string.Concat(" -", m.Value, "- "));
	/// 	</code>
	/// </example>
	public static string ReplaceWith(this string value, string regexPattern, MatchEvaluator evaluator)
	{
		return ReplaceWith(value, regexPattern, RegexOptions.None, evaluator);
	}

	/// <summary>
	/// 	Uses regular expressions to replace parts of a string.
	/// </summary>
	/// <param name = "value">The input string.</param>
	/// <param name = "regexPattern">The regular expression pattern.</param>
	/// <param name = "options">The regular expression options.</param>
	/// <param name = "evaluator">The replacement method / lambda expression.</param>
	/// <returns>The newly created string</returns>
	/// <example>
	/// 	<code>
	/// 		var s = "12345";
	/// 		var replaced = s.ReplaceWith(@"\d", m => string.Concat(" -", m.Value, "- "));
	/// 	</code>
	/// </example>
	public static string ReplaceWith(this string value, string regexPattern, RegexOptions options, MatchEvaluator evaluator)
	{
		return Regex.Replace(value, regexPattern, evaluator, options);
	}

	/// <summary>
	/// 	Uses regular expressions to determine all matches of a given regex pattern.
	/// </summary>
	/// <param name = "value">The input string.</param>
	/// <param name = "regexPattern">The regular expression pattern.</param>
	/// <returns>A collection of all matches</returns>
	public static MatchCollection GetMatches(this string value, string regexPattern)
	{
		return GetMatches(value, regexPattern, RegexOptions.None);
	}

	/// <summary>
	/// 	Uses regular expressions to determine all matches of a given regex pattern.
	/// </summary>
	/// <param name = "value">The input string.</param>
	/// <param name = "regexPattern">The regular expression pattern.</param>
	/// <param name = "options">The regular expression options.</param>
	/// <returns>A collection of all matches</returns>
	public static MatchCollection GetMatches(this string value, string regexPattern, RegexOptions options)
	{
		return Regex.Matches(value, regexPattern, options);
	}

	/// <summary>
	/// 	Uses regular expressions to determine all matches of a given regex pattern and returns them as string enumeration.
	/// </summary>
	/// <param name = "value">The input string.</param>
	/// <param name = "regexPattern">The regular expression pattern.</param>
	/// <returns>An enumeration of matching strings</returns>
	/// <example>
	/// 	<code>
	/// 		var s = "12345";
	/// 		foreach(var number in s.GetMatchingValues(@"\d")) {
	/// 		Console.WriteLine(number);
	/// 		}
	/// 	</code>
	/// </example>
	public static IEnumerable<string> GetMatchingValues(this string value, string regexPattern)
	{
		return GetMatchingValues(value, regexPattern, RegexOptions.None);
	}

	/// <summary>
	/// 	Uses regular expressions to determine all matches of a given regex pattern and returns them as string enumeration.
	/// </summary>
	/// <param name = "value">The input string.</param>
	/// <param name = "regexPattern">The regular expression pattern.</param>
	/// <param name = "options">The regular expression options.</param>
	/// <returns>An enumeration of matching strings</returns>
	/// <example>
	/// 	<code>
	/// 		var s = "12345";
	/// 		foreach(var number in s.GetMatchingValues(@"\d")) {
	/// 		Console.WriteLine(number);
	/// 		}
	/// 	</code>
	/// </example>
	public static IEnumerable<string> GetMatchingValues(this string value, string regexPattern, RegexOptions options)
	{
		return from Match match in GetMatches(value, regexPattern, options)
		       where match.Success
		       select match.Value;
	}

	/// <summary>
	/// 	Uses regular expressions to split a string into parts.
	/// </summary>
	/// <param name = "value">The input string.</param>
	/// <param name = "regexPattern">The regular expression pattern.</param>
	/// <returns>The splitted string array</returns>
	public static string[] Split(this string value, string regexPattern)
	{
		return value.Split(regexPattern, RegexOptions.None);
	}

	/// <summary>
	/// 	Uses regular expressions to split a string into parts.
	/// </summary>
	/// <param name = "value">The input string.</param>
	/// <param name = "regexPattern">The regular expression pattern.</param>
	/// <param name = "options">The regular expression options.</param>
	/// <returns>The splitted string array</returns>
	public static string[] Split(this string value, string regexPattern, RegexOptions options)
	{
		return Regex.Split(value, regexPattern, options);
	}

	/// <summary>
	/// 	Splits the given string into words and returns a string array.
	/// </summary>
	/// <param name = "value">The input string.</param>
	/// <returns>The splitted string array</returns>
	public static string[] GetWords(this string value)
	{
		return value.Split(@"\W");
	}

	/// <summary>
	/// 	Gets the nth "word" of a given string, where "words" are substrings separated by a given separator
	/// </summary>
	/// <param name = "value">The string from which the word should be retrieved.</param>
	/// <param name = "index">Index of the word (0-based).</param>
	/// <returns>
	/// 	The word at position n of the string.
	/// 	Trying to retrieve a word at a position lower than 0 or at a position where no word exists results in an exception.
	/// </returns>
	/// <remarks>
	/// 	Originally contributed by MMathews
	/// </remarks>
	public static string GetWordByIndex(this string value, int index)
	{
		var words = value.GetWords();

		if ((index < 0) || (index > words.Length - 1))
			throw new IndexOutOfRangeException("The word number is out of range.");

		return words[index];
	}

	#endregion
	#region Bytes & Base64

	/// <summary>
	/// 	Converts the string to a byte-array using the default encoding
	/// </summary>
	/// <param name = "value">The input string.</param>
	/// <returns>The created byte array</returns>
	public static byte[] ToBytes(this string value)
	{
		return value.ToBytes(null);
	}

	/// <summary>
	/// 	Converts the string to a byte-array using the supplied encoding
	/// </summary>
	/// <param name = "value">The input string.</param>
	/// <param name = "encoding">The encoding to be used.</param>
	/// <returns>The created byte array</returns>
	/// <example>
	/// 	<code>
	/// 		var value = "Hello World";
	/// 		var ansiBytes = value.ToBytes(Encoding.GetEncoding(1252)); // 1252 = ANSI
	/// 		var utf8Bytes = value.ToBytes(Encoding.UTF8);
	/// 	</code>
	/// </example>
	public static byte[] ToBytes(this string value, Encoding encoding)
	{
		encoding = (encoding ?? Encoding.Default);
		return encoding.GetBytes(value);
	}

	/// <summary>
	/// 	Encodes the input value to a Base64 string using the default encoding.
	/// </summary>
	/// <param name = "value">The input value.</param>
	/// <returns>The Base 64 encoded string</returns>
	public static string EncodeBase64(this string value)
	{
		return value.EncodeBase64(null);
	}

	/// <summary>
	/// 	Encodes the input value to a Base64 string using the supplied encoding.
	/// </summary>
	/// <param name = "value">The input value.</param>
	/// <param name = "encoding">The encoding.</param>
	/// <returns>The Base 64 encoded string</returns>
	public static string EncodeBase64(this string value, Encoding encoding)
	{
		encoding = (encoding ?? Encoding.UTF8);
		var bytes = encoding.GetBytes(value);
		return Convert.ToBase64String(bytes);
	}

	/// <summary>
	/// 	Decodes a Base 64 encoded value to a string using the default encoding.
	/// </summary>
	/// <param name = "encodedValue">The Base 64 encoded value.</param>
	/// <returns>The decoded string</returns>
	public static string DecodeBase64(this string encodedValue)
	{
		return encodedValue.DecodeBase64(null);
	}

	/// <summary>
	/// 	Decodes a Base 64 encoded value to a string using the supplied encoding.
	/// </summary>
	/// <param name = "encodedValue">The Base 64 encoded value.</param>
	/// <param name = "encoding">The encoding.</param>
	/// <returns>The decoded string</returns>
	public static string DecodeBase64(this string encodedValue, Encoding encoding)
	{
		encoding = (encoding ?? Encoding.UTF8);
		var bytes = Convert.FromBase64String(encodedValue);
		return encoding.GetString(bytes);
	}

	#endregion
}
