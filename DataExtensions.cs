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
	/// Gets the region with the given name from the region list.
	/// </summary>
	/// <param name="regions">The regions list</param>
	/// <param name="name">The name</param>
	/// <returns>The region</returns>
	public static Region ByName(this IList<Region> regions, string name) {
		return regions.Where(r => r.Name == name).Single() ;
	}

	/// <summary>
	/// Gets the images available in the media list.
	/// </summary>
	/// <param name="media">The media list</param>
	/// <returns>The images</returns>
	public static IList<Media> Images(this IList<Media> media) {
		return media.Where(m => m.IsImage).ToList() ;
	}

	/// <summary>
	/// Gets the documents available in the document list.
	/// </summary>
	/// <param name="media">The media list</param>
	/// <returns>The documents</returns>
	public static IList<Media> Documents(this IList<Media> media) {
		return media.Where(m => !m.IsImage).ToList() ;
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
