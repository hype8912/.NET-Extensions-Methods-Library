using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;

/// <summary>
/// 	Extension methods for the string data type
/// </summary>
public static partial class StringExtensions
{
	/// <summary>
	/// Returns the plural form of the specified word.
	/// </summary>
	/// <param name="singular">The singular string value</param>
	/// <param name="count">How many of the specified word there are. A count equal to 1 will not pluralize the specified word.</param>
	/// <param name="cultureInfo">Provide a culture info to pluralize (default to en-US)</param>
	/// <returns>A string that is the plural form of the input parameter.</returns>
	public static string ToPlural2(this string singular, int count = 0, CultureInfo cultureInfo = null)
	{
		return count == 1 ? singular : PluralizationService.CreateService(cultureInfo ?? new CultureInfo("en-US")).Pluralize(singular);
	}

}