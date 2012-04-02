using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piranha.Entities
{
	/// <summary>
	/// Group entity.
	/// </summary>
	public class Group : BaseEntity
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
	}
}
