using System.Collections.Generic;
using System.Web.Mvc;

///<summary>
/// A bunch of HTML helper extensions
///</summary>
public static class HTMLHelperExtensions
{
	///<summary>
	/// Returns an HTML image element for the given image options
	///</summary>
	///<param name="htmlHelper"></param>
	///<param name="imgSrc">Image source</param>
	///<param name="alt">Image alt text</param>
	///<param name="actionName">Link action name</param>
	///<param name="controllerName">Link controller name</param>
	///<param name="routeValues">Link route values</param>
	///<param name="htmlAttributes">Link html attributes</param>
	///<param name="imgHtmlAttributes">Image html attributes</param>
	///<returns>MvcHtmlString</returns>
	/// <remarks>
	/// 	Contributed by Michael T, http://stackoverflow.com/users/190249/michael-t
	/// </remarks>
	public static MvcHtmlString ImageLink(this HtmlHelper htmlHelper, string imgSrc = null, string alt = null, string actionName = null, string controllerName = null, object routeValues = null, object htmlAttributes = null, object imgHtmlAttributes = null)
	{
		var urlHelper = ((Controller)htmlHelper.ViewContext.Controller).Url;
		var imgTag = new TagBuilder("img");
		imgTag.MergeAttribute("src", imgSrc);
		imgTag.MergeAttributes((IDictionary<string, string>)imgHtmlAttributes, true);

		var url = urlHelper.Action(actionName, controllerName, routeValues);
		var imglink = new TagBuilder("a");
		imglink.MergeAttribute("href", url);
		imglink.InnerHtml = imgTag.ToString(TagRenderMode.SelfClosing);
		imglink.MergeAttributes((IDictionary<string, string>)htmlAttributes, true);

		return MvcHtmlString.Create(imglink.ToString());
	}

	///<summary>
	/// Returns an HTML image element for the given source and alt text.
	///</summary>
	///<param name="helper"></param>
	///<param name="src"></param>
	///<param name="alt"></param>
	///<returns>MvcHtmlString</returns>
	/// <remarks>
	/// 	Contributed by Michael T, http://stackoverflow.com/users/190249/michael-t
	/// </remarks>
	public static MvcHtmlString Image(this HtmlHelper helper, string src, string alt = null)
	{

		var tb = new TagBuilder("img");
		tb.Attributes.Add("src", helper.Encode(src));
		tb.Attributes.Add("alt", helper.Encode(alt));
		return MvcHtmlString.Create(tb.ToString(TagRenderMode.SelfClosing));
	}

	/// <summary>
	/// Returns an HTML label element for the given target and text.
	/// </summary>
	/// <param name="helper"></param>
	/// <param name="target"></param>
	/// <param name="text"></param>
	/// <param name="htmlAttributes"></param>
	/// <returns></returns>
	/// <remarks>
	/// 	Contributed by Michael T, http://stackoverflow.com/users/190249/michael-t
	/// </remarks>
	public static MvcHtmlString Label(this HtmlHelper helper, string target, string text, object htmlAttributes = null)
	{
		var tb = new TagBuilder("label");

		tb.MergeAttribute("for", target);
		tb.MergeAttributes((IDictionary<string, string>)htmlAttributes, true);
		tb.SetInnerText(text);

		return MvcHtmlString.Create(tb.ToString());
	}
}