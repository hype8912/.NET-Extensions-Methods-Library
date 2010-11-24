using System;

/// <summary>
/// 	Extension methods for the reflection meta data type "Type"
/// </summary>
public static class TypeExtensions
{
	/// <summary>
	/// 	Creates and returns an instance of the desired type
	/// </summary>
	/// <param name = "type">The type to be instanciated.</param>
	/// <param name = "constructorParameters">Optional constructor parameters</param>
	/// <returns>The instanciated object</returns>
	/// <example>
	/// 	<code>
	/// 		var type = Type.GetType(".NET full qualified class Type")
	/// 		var instance = type.CreateInstance();
	/// 	</code>
	/// </example>
	public static object CreateInstance(this Type type, params object[] constructorParameters)
	{
		return CreateInstance<object>(type, constructorParameters);
	}

	/// <summary>
	/// 	Creates and returns an instance of the desired type casted to the generic parameter type T
	/// </summary>
	/// <typeparam name = "T">The data type the instance is casted to.</typeparam>
	/// <param name = "type">The type to be instanciated.</param>
	/// <param name = "constructorParameters">Optional constructor parameters</param>
	/// <returns>The instanciated object</returns>
	/// <example>
	/// 	<code>
	/// 		var type = Type.GetType(".NET full qualified class Type")
	/// 		var instance = type.CreateInstance&lt;IDataType&gt;();
	/// 	</code>
	/// </example>
	public static T CreateInstance<T>(this Type type, params object[] constructorParameters)
	{
		var instance = Activator.CreateInstance(type, constructorParameters);
		return (T) instance;
	}

	///<summary>
	///	Check if this is a base type
	///</summary>
	///<param name = "type"></param>
	///<param name = "checkingType"></param>
	///<returns></returns>
	public static bool IsBaseType(this Type type, Type checkingType)
	{
		while (type != typeof (object))
		{
			if (type == null)
				continue;

			if (type == checkingType)
				return true;

			type = type.BaseType;
		}
		return false;
	}

	///<summary>
	///	Check if this is a sub class generic type
	///</summary>
	///<param name = "generic"></param>
	///<param name = "toCheck"></param>
	///<returns></returns>
	public static bool IsSubclassOfRawGeneric(this Type generic, Type toCheck)
	{
		while (toCheck != typeof (object))
		{
			if (toCheck == null)
				continue;

			var cur = toCheck.IsGenericType ? toCheck.GetGenericTypeDefinition() : toCheck;
			if (generic == cur)
				return true;
			toCheck = toCheck.BaseType;
		}
		return false;
	}
}
