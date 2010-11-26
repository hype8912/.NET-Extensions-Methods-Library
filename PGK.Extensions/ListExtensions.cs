using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.RegularExpressions;

/// <summary>
/// 	Extension methods for all kind of Lists implementing the IList&lt;T&gt; interface
/// </summary>
public static class ListExtensions
{
	/// <summary>
	/// 	Inserts an item uniquely to to a list and returns a value whether the item was inserted or not.
	/// </summary>
	/// <typeparam name = "T">The generic list item type.</typeparam>
	/// <param name = "list">The list to be inserted into.</param>
	/// <param name = "index">The index to insert the item at.</param>
	/// <param name = "item">The item to be added.</param>
	/// <returns>Indicates whether the item was inserted or not</returns>
	public static bool InsertUnqiue<T>(this IList<T> list, int index, T item)
	{
		if (list.Contains(item) == false)
		{
			list.Insert(index, item);
			return true;
		}
		return false;
	}

	/// <summary>
	/// 	Inserts a range of items uniquely to a list starting at a given index and returns the amount of items inserted.
	/// </summary>
	/// <typeparam name = "T">The generic list item type.</typeparam>
	/// <param name = "list">The list to be inserted into.</param>
	/// <param name = "startIndex">The start index.</param>
	/// <param name = "items">The items to be inserted.</param>
	/// <returns>The amount if items that were inserted.</returns>
	public static int InsertRangeUnique<T>(this IList<T> list, int startIndex, IEnumerable<T> items)
	{
		var index = startIndex + items.Count(item => list.InsertUnqiue(startIndex, item));
		return (index - startIndex);
	}

	/// <summary>
	/// 	Return the index of the first matching item or -1.
	/// </summary>
	/// <typeparam name = "T"></typeparam>
	/// <param name = "list">The list.</param>
	/// <param name = "comparison">The comparison.</param>
	/// <returns>The item index</returns>
	public static int IndexOf<T>(this IList<T> list, Func<T, bool> comparison)
	{
		for (var i = 0; i < list.Count; i++)
		{
			if (comparison(list[i]))
				return i;
		}
		return -1;
	}

	/// <summary>
	/// 	Join all the elements in the list and create a string seperated by the specified char.
	/// </summary>
	/// <param name = "list">
	/// 	The list.
	/// </param>
	/// <param name = "joinChar">
	/// 	The join char.
	/// </param>
	/// <typeparam name = "T">
	/// </typeparam>
	/// <returns>
	/// 	The resulting string of the elements in the list.
	/// </returns>
	/// <remarks>
	/// 	Contributed by Michael T, http://stackoverflow.com/users/190249/michael-t
	/// </remarks>
	public static string Join<T>(this IList<T> list, char joinChar)
	{
		return list.Join(joinChar.ToString());
	}

	/// <summary>
	/// 	Join all the elements in the list and create a string seperated by the specified string.
	/// </summary>
	/// <param name = "list">
	/// 	The list.
	/// </param>
	/// <param name = "joinString">
	/// 	The join string.
	/// </param>
	/// <typeparam name = "T">
	/// </typeparam>
	/// <returns>
	/// 	The resulting string of the elements in the list.
	/// </returns>
	/// <remarks>
	/// 	Contributed by Michael T, http://stackoverflow.com/users/190249/michael-t
	/// </remarks>
	public static string Join<T>(this IList<T> list, string joinString)
	{
		var result = string.Empty;
		if (list != null && list.Count > 0)
		{
			if (list.Count > 1)
			{
				for (var i = 0; i < list.Count; i++)
				{
					if (i != list.Count)
						result += list[i] + joinString;
					else
						result += list[i];
				}
			}
			else
				result = list[0].ToString();
		}
		return result;
	}

	/// <summary>
	/// 	Using Relugar Expression, find the top matches for each item in the source specified by the arguments to search.
	/// </summary>
	/// <param name = "list">
	/// 	The source.
	/// </param>
	/// <param name = "searchString">
	/// 	The search string.
	/// </param>
	/// <param name = "top">
	/// 	The top.
	/// </param>
	/// <param name = "args">
	/// 	The args.
	/// </param>
	/// <typeparam name = "T">
	/// </typeparam>
	/// <returns>
	/// 	A List of top matches.
	/// </returns>
	/// <remarks>
	/// 	Contributed by Michael T, http://stackoverflow.com/users/190249/michael-t
	/// </remarks>
	public static List<T> Match<T>(this IList<T> list, string searchString, int top, params Expression<Func<T, object>>[] args)
	{
		// Create a new list of results and matches;
		var results = new List<T>();
		var matches = new Dictionary<T, int>();
		var maxMatch = 0;
		// For each item in the source
		list.ForEach(s =>
		{
			// Generate the expression string from the argument.
			var regExp = string.Empty;
			if (args != null)
			{
				// For each argument
				Array.ForEach(args,
					a =>
					{
						// Compile the expression
						var property = a.Compile();
						// Attach the new property to the expression string
						regExp += (string.IsNullOrEmpty(regExp) ? "(?:" : "|(?:") + property(s) + ")+?";
					});
			}
			// Get the matches
			var match = Regex.Matches(searchString, regExp, RegexOptions.IgnoreCase);
			// If there are more than one match
			if (match.Count > 0)
			{
				// Add it to the match dictionary, including the match count.
				matches.Add(s, match.Count);
			}
			// Get the highest max matching
			maxMatch = match.Count > maxMatch ? match.Count : maxMatch;
		});
		// Convert the match dictionary into a list
		var matchList = matches.ToList();

		// Sort the list by decending match counts
		// matchList.Sort((s1, s2) => s2.Value.CompareTo(s1.Value));

		// Remove all matches that is less than the best match.
		matchList.RemoveAll(s => s.Value < maxMatch);

		// If the top value is set and is less than the number of matches
		var getTop = top > 0 && top < matchList.Count ? top : matchList.Count;

		// Add the maches into the result list.
		for (var i = 0; i < getTop; i++)
			results.Add(matchList[i].Key);

		return results;
	}

	///<summary>
	///	Cast this list into a List
	///</summary>
	///<param name = "source"></param>
	///<typeparam name = "T"></typeparam>
	///<returns></returns>
	/// <remarks>
	/// 	Contributed by Michael T, http://stackoverflow.com/users/190249/michael-t
	/// </remarks>
	public static List<T> Cast<T>(this IList source)
	{
		var list = new List<T>();
		list.AddRange(source.OfType<T>());
		return list;
	}
}
