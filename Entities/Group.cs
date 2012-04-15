using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Piranha.Entities
{
	/// <summary>
	/// Group entity.
	/// </summary>
	public class Group : BaseEntity<Group>
	{
		#region Fields
		/// <summary>
		/// Gets/sets the optional parent id.
		/// </summary>
		public Guid? ParentId { get ; set ; }

		/// <summary>
		/// Gets/sets the name.
		/// </summary>
		public string Name { get ; set ; }

		/// <summary>
		/// Gets/sets the description.
		/// </summary>
		public string Description { get ; set ; }
		#endregion

		#region Properties
		/// <summary>
		/// Gets/sets the child groups. Note that the groups have to be fetched by using the
		/// Structure call to be sorted recursively.
		/// </summary>
		internal List<Group> Groups { get ; set ; }

		/// <summary>
		/// Gets/sets the structural level of the group. Note that the groups have to be fetched
		/// by using the Structure call to be sorted recursively.
		/// </summary>
		internal int Level { get ; set ; }
		#endregion

		/// <summary>
		/// Default constructor. Creates a new group.
		/// </summary>
		public Group() : base() {
			Groups = new List<Group>() ;
		}

		#region Associations
		/// <summary>
		/// Gets/sets the parent group.
		/// </summary>
		public Group Parent { get ; set ; }

		/// <summary>
		/// Gets/sets the users associated with this group.
		/// </summary>
		public IList<User> Users { get ; set ; }
		#endregion

		/// <summary>
		/// Invalidates the group cache.
		/// </summary>
		/// <param name="state">The current entity state</param>
		public override void OnInvalidate(System.Data.EntityState state) {
			// Invalidate entire cache as groups are recursivly linked
			HttpContext.Current.Cache.Remove(typeof(Group).Name) ;
		}
	}
}
