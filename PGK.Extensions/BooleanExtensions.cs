using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class BooleanExtensions
{
	/// <summary>
	/// Converts the value of this instance to its equivalent string representation (either "Yes" or "No").
	/// </summary>
	/// <param name="boolean"></param>
	/// <returns>string</returns>
	public static string ToYesNoString(this Boolean boolean)
	{
		return boolean ? "Yes" : "No";
	}
}
