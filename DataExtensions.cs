using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

using Piranha.Entities;

public static class DataExtensions
{
	/// <summary>
	/// Gets the property with the given name from the property list.
	/// </summary>
	/// <param name="properties">The property list</param>
	/// <param name="name">The name</param>
	/// <returns>The property</returns>
	public static Property ByName(this IList<Property> properties, string name) {
		return properties.Where(p => p.Name == name).Single() ;
	}

	/// <summary>
	/// Gets the current string as an html string.
	/// </summary>
	/// <param name="str">The string</param>
	/// <returns>The string as html</returns>
	public static HtmlString Html(this string str) {
		return new HtmlString(str) ;
	}
}
