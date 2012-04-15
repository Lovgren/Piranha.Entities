using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;

using Piranha.Data;
using Piranha.Entities;

/// <summary>
/// Extensions for the group entity.
/// </summary>
public static class GroupExtensions
{
	/// <summary>
	/// Gets the recurisvely sorted group strucutre.
	/// </summary>
	/// <param name="db">The current db set.</param>
	/// <returns>The groups</returns>
	public static List<Group> Structure(this DbSet<Group> db) {
		if (HttpContext.Current.Cache[typeof(Group).Name] == null) {
			HttpContext.Current.Cache[typeof(Group).Name] = 
				Sort(db.OrderBy(g => g.ParentId).ToList(), Guid.Empty) ;
		}
		return (List<Group>)HttpContext.Current.Cache[typeof(Group).Name] ;
	}

	/// <summary>
	/// Flattens the recursive group structure into a one dimensional list.
	/// </summary>
	/// <param name="groups">The group structure</param>
	/// <returns>A flattened list</returns>
	public static List<Group> Flatten(this List<Group> groups) {
		var ret = new List<Group>() ;

		foreach (var group in groups) {
			ret.Add(group) ;
			if (group.Groups.Count > 0)
				ret.AddRange(Flatten(group.Groups)) ;
		}
		return ret ;
	}

	#region Private methods
	/// <summary>
	/// Sorts the groups. 
	/// </summary>
	/// <param name="groups">The groups</param>
	/// <param name="parentid">The current parent id</param>
	/// <param name="level">The current level</param>
	/// <returns>The sorted group list</returns>
	private static List<Group> Sort(List<Group> groups, Guid parentid, int level = 1) {
		var ret = new List<Group>() ;

		foreach (var group in groups) {
			if (group.ParentId == parentid) {
				group.Groups = Sort(groups, group.Id, level + 1) ;
				group.Level = level ;
				ret.Add(group) ;
			}
		}
		return ret;
	}
	#endregion
}
