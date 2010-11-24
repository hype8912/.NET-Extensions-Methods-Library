using System;

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
	public static bool WithinIndex(this Array source, int index)
	{
		return source != null && index >= 0 && index < source.Length;
	}
}
