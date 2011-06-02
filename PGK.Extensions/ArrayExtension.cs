using System;

/// <summary>
/// 	Extension methods for the array data type
/// </summary>
public static class ArrayExtension
{
	///<summary>
	///	Check if the array is null or empty
	///</summary>
	///<param name = "source"></param>
	///<returns></returns>
	public static bool IsNullOrEmpty(this Array source)
	{
		return source != null ? source.Length <= 0 : false;
	}

	///<summary>
	///	Check if the index is within the array
	///</summary>
	///<param name = "source"></param>
	///<param name = "index"></param>
	///<returns></returns>
	/// <remarks>
	/// 	Contributed by Michael T, http://about.me/MichaelTran
	/// </remarks>
	public static bool WithinIndex(this Array source, int index)
	{
		return source != null && index >= 0 && index < source.Length;
	}

	///<summary>
	///	Check if the index is within the array
	///</summary>
	///<param name = "source"></param>
	///<param name = "index"></param>
	///<param name="dimension"></param>
	///<returns></returns>
	/// <remarks>
	/// 	Contributed by Michael T, http://about.me/MichaelTran
	/// </remarks>
	public static bool WithinIndex(this Array source, int index, int dimension = 0)
	{
		return source != null && index >= source.GetLowerBound(dimension) && index <= source.GetUpperBound(dimension);
	}


    /// <summary>
    /// Combine two arrays into one.
    /// </summary>
    /// <typeparam name="T">Type of Array</typeparam>
    /// <param name="combineWith">Base array in which arrayToCombine will add.</param>
    /// <param name="arrayToCombine">Array to combine with Base array.</param>
    /// <returns></returns>
    /// <example>
    /// 	<code>
    /// 		int[] arrayOne = new[] { 1, 2, 3, 4 };
    /// 		int[] arrayTwo = new[] { 5, 6, 7, 8 };
    /// 		Array combinedArray = arrayOne.CombineArray<int>(arrayTwo);
    /// 	</code>
    /// </example>
    /// <remarks>
    /// 	Contributed by Mohammad Rahman, http://mohammad-rahman.blogspot.com/
    /// </remarks>
    /// 
    public static T[] CombineArray<T>(this T[] combineWith, T[] arrayToCombine)
    {
        if (combineWith != default(T[]) && arrayToCombine != default(T[]))
        {
            int initialSize = combineWith.Length;
            Array.Resize<T>(ref combineWith, initialSize + arrayToCombine.Length);
            Array.Copy(arrayToCombine, arrayToCombine.GetLowerBound(0), combineWith, initialSize, arrayToCombine.Length);
        }
        return combineWith;
    }
}
