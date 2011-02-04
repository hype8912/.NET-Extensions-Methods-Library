using System;
using System.IO;
using System.Web.Mvc;

public static class IViewExtensions
{
	///<summary>
	/// Get the name of the view
	///</summary>
	///<param name="view">Current view</param>
	///<returns>View name</returns>
	///<exception cref="InvalidOperationException"></exception>
	public static string GetWebFormViewName(this IView view)
	{
		if (view is WebFormView)
		{
			string viewUrl = ((WebFormView)view).ViewPath;
			string viewFileName = viewUrl.Substring(viewUrl.LastIndexOf('/'));
			string viewFileNameWithoutExtension = Path.GetFileNameWithoutExtension(viewFileName);
			return (viewFileNameWithoutExtension);
		}
		throw (new InvalidOperationException("This view is not a WebFormView"));
	}
}
