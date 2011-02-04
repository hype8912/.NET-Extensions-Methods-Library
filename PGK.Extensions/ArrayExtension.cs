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
}
