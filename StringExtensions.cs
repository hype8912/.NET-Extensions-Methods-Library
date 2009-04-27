using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

/// <summary>
/// Extension methods for the string data type
/// </summary>
public static class StringExtensions {

    /// <summary>
    /// Determines whether the specified string is null or empty.
    /// </summary>
    /// <param name="value">The string value to check.</param>
    public static bool IsEmpty(this string value) {
        return ((value == null) || (value.Length == 0));
    }

    /// <summary>
    /// Determines whether the specified string is not null or empty.
    /// </summary>
    /// <param name="value">The string value to check.</param>
    public static bool IsNotEmpty(this string value) {
        return (value.IsEmpty() == false);
    }

    /// <summary>
    /// Checks whether the string is empty and returns a default value in case.
    /// </summary>
    /// <param name="value">The string to check.</param>
    /// <param name="defaultValue">The default value.</param>
    /// <returns>Either the string or the default value.</returns>
    public static string IfEmpty(this string value, string defaultValue) {
        return (value.IsNotEmpty() ? value : defaultValue);
    }

    /// <summary>
    /// Formats the value with the parameters using string.Format.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="parameters">The parameters.</param>
    /// <returns></returns>
    public static string FormatWith(this string value, params object[] parameters) {
        return string.Format(value, parameters);
    }

    /// <summary>
    /// Trims the text to a provided maximum length.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="maxLength">Maximum length.</param>
    /// <returns></returns>
    /// <remarks>Proposed by Rene Schulte</remarks>
    public static string TrimToMaxLength(this string value, int maxLength) {
        return (value == null || value.Length <= maxLength ? value : value.Substring(0, maxLength));
    }

    /// <summary>
    /// Trims the text to a provided maximum length and adds a suffix if required.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="maxLength">Maximum length.</param>
    /// <param name="suffix">The suffix.</param>
    /// <returns></returns>
    /// <remarks>Proposed by Rene Schulte</remarks>
    public static string TrimToMaxLength(this string value, int maxLength, string suffix) {
        return (value == null || value.Length <= maxLength ? value : string.Concat(value.Substring(0, maxLength), suffix));
    }

    /// <summary>
    /// Loads the string into a LINQ to XML XDocument
    /// </summary>
    /// <param name="xml">The XML string.</param>
    /// <returns>The XML document object model (XDocument)</returns>
    public static XDocument ToXDocument(this string xml) {
        return XDocument.Parse(xml);
    }

    /// <summary>
    /// Loads the string into a XML DOM object (XmlDocument)
    /// </summary>
    /// <param name="xml">The XML string.</param>
    /// <returns>The XML document object model (XmlDocument)</returns>
    public static XmlDocument ToXmlDOM(this string xml) {
        var document = new XmlDocument();
        document.LoadXml(xml);
        return document;
    }

    /// <summary>
    /// Loads the string into a XML XPath DOM (XPathDocument)
    /// </summary>
    /// <param name="xml">The XML string.</param>
    /// <returns>The XML XPath document object model (XPathNavigator)</returns>
    public static XPathNavigator ToXPath(this string xml) {
        var document = new XPathDocument(new StringReader(xml));
        return document.CreateNavigator();
    }
}
