using System;
using System.Collections.Generic;

/// <summary>
/// Extension methods for all kind of Lists implementing the IList&lt;T&gt; interface
/// </summary>
public static class ListExtensions {

    /// <summary>
    /// Inserts an item uniquely to to a list and returns a value whether the item was inserted or not.
    /// </summary>
    /// <typeparam name="T">The generic list item type.</typeparam>
    /// <param name="list">The list to be inserted into.</param>
    /// <param name="index">The index to insert the item at.</param>
    /// <param name="item">The item to be added.</param>
    /// <returns>Indicates whether the item was inserted or not</returns>
    public static bool InsertUnqiue<T>(this IList<T> list, int index, T item) {
        if (list.Contains(item) == false) {
            list.Insert(index, item);
            return true;
        }
        return false;
    }

    /// <summary>
    /// Inserts a range of items uniquely to a list starting at a given index and returns the amount of items inserted.
    /// </summary>
    /// <typeparam name="T">The generic list item type.</typeparam>
    /// <param name="list">The list to be inserted into.</param>
    /// <param name="startIndex">The start index.</param>
    /// <param name="items">The items to be inserted.</param>
    /// <returns>The amount if items that were inserted.</returns>
    public static int InsertRangeUnique<T>(this IList<T> list, int startIndex, IEnumerable<T> items) {
        var index = startIndex;
        foreach (var item in items) {
            if(list.InsertUnqiue(startIndex, item)) index++;
        }
        return (index - startIndex);
    }
}
