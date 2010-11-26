using System.Collections.Generic;
using System.Web.Mvc;

///<summary>
/// A bunch of HTML helper extensions
///</summary>
public static class HTMLHelperExtensions
{
	///<summary>
	///</summary>
	///<param name="htmlHelper"></param>
	///<param name="imgSrc"></param>
	///<param name="alt"></param>
	///<param name="actionName"></param>
	///<param name="controllerName"></param>
	///<param name="routeValues"></param>
	///<param name="htmlAttributes"></param>
	///<param name="imgHtmlAttributes"></param>
	///<returns></returns>
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
		imglink.InnerHtml = imgTag.ToString();
		imglink.MergeAttributes((IDictionary<string, string>)htmlAttributes, true);

		return MvcHtmlString.Create(imglink.ToString());
	}

	///<summary>
	///</summary>
	///<param name="helper"></param>
	///<param name="src"></param>
	///<param name="alt"></param>
	///<returns></returns>
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
}