﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// 	Extension methods for Dictionary.
/// </summary>
public static class DictionaryExtensions
{
	// todo: Needs xml documentation for these methods
	// todo: create unit testing for these methods
	public static IDictionary<TKey, TValue> Sort<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
	{
		if (dictionary == null)
			throw new ArgumentNullException("dictionary");

		return new SortedDictionary<TKey, TValue>(dictionary);
	}

	public static IDictionary<TKey, TValue> Sort<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, IComparer<TKey> comparer)
	{
		if (dictionary == null)
			throw new ArgumentNullException("dictionary");
		if (comparer == null)
			throw new ArgumentNullException("comparer");

		return new SortedDictionary<TKey, TValue>(dictionary, comparer);
	}

	public static IDictionary<TKey, TValue> SortByValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
	{
		return (new SortedDictionary<TKey, TValue>(dictionary)).OrderBy(kvp => kvp.Value).ToDictionary(item => item.Key, item => item.Value);
	}

	public static IDictionary<TValue, TKey> Invert<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
	{
		if (dictionary == null)
			throw new ArgumentNullException("dictionary");
		return dictionary.ToDictionary(pair => pair.Value, pair => pair.Key);
	}

	public static Hashtable ToHashTable<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
	{
		var table = new Hashtable();

		foreach (var item in dictionary)
			table.Add(item.Key, item.Value);

		return table;
	}

    /// <summary>
    /// Returns the value of the first entry found with one of the <paramref name="keys"/> received.
    /// <para>Returns <paramref name="defaultValue"/> if none of the keys exists in this collection </para>
    /// </summary>
    /// <param name="defaultValue">Default value if none of the keys </param>
    /// <param name="keys"> keys to search for (in order) </param>
	public static TValue GetFirstValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TValue defaultValue, params TKey[] keys)
	{
        foreach (var key in keys)
        {
            if (dictionary.ContainsKey(key))
                return dictionary[key];
        }
		return defaultValue;
	}

    /// <summary>
    /// Returns the value associated with the specified key, or a default value if no element is found.
    /// </summary>
    /// <typeparam name="TKey">The key data type</typeparam>
    /// <typeparam name="TValue">The value data type</typeparam>
    /// <param name="source">The source dictionary.</param>
    /// <param name="key">The key of interest.</param>
    /// <returns>The value associated with the specified key if the key is found, the default value for the value data type if the key is not found</returns>
    public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key)
    {
        return source.GetOrDefault(key, default(TValue));
    }

    /// <summary>
    /// Returns the value associated with the specified key, or the specified default value if no element is found.
    /// </summary>
    /// <typeparam name="TKey">The key data type</typeparam>
    /// <typeparam name="TValue">The value data type</typeparam>
    /// <param name="source">The source dictionary.</param>
    /// <param name="key">The key of interest.</param>
    /// <param name="defaultValue">The default value to return if the key is not found.</param>
    /// <returns>The value associated with the specified key if the key is found, the specified default value if the key is not found</returns>
    public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, TValue defaultValue)
    {
        TValue value;
        return source.TryGetValue(key, out value) ? value : defaultValue;
    }

    /// <summary>
    /// Returns the value associated with the specified key, or throw the specified exception if no element is found.
    /// </summary>
    /// <typeparam name="TKey">The key data type</typeparam>
    /// <typeparam name="TValue">The value data type</typeparam>
    /// <param name="source">The source dictionary.</param>
    /// <param name="key">The key of interest.</param>
    /// <param name="exception">The exception to throw if the key is not found.</param>
    /// <returns>The value associated with the specified key if the key is found, the specified exception is thrown if the key is not found</returns>
    public static TValue GetOrThrow<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, Exception exception)
    {
        TValue value;
        if (source.TryGetValue(key, out value))
        {
            return value;
        }

        throw exception;
    }
}
