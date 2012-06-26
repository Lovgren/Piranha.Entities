using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piranha.Entities
{
	/// <summary>
	/// The permission entity.
	/// </summary>
	public class Permission : BaseEntity
	{
		#region Properties
		/// <summary>
		/// Gets/sets the unique id of the permission.
		/// </summary>
		public Guid Id { get ; set ; }

		/// <summary>
		/// Gets/sets the id of the group who is attached to the permission.
		/// </summary>
		public Guid GroupId { get ; set ; }

		/// <summary>
		/// Gets/sets the name of the permission.
		/// </summary>
		public string Name { get ; set ; }

		/// <summary>
		/// Gets/sets the description shown in the manager interface.
		/// </summary>
		public string Description { get ; set ; }

		/// <summary>
		/// Gets/sets weather this permission can be removed or not.
		/// </summary>
		public bool IsLocked { get ; set ; }

		/// <summary>
		/// Gets/sets the date the permission was initially created.
		/// </summary>
		public DateTime Created { get ; set ; }

		/// <summary>
		/// Gets/sets the date the permission was last updated.
		/// </summary>
		public DateTime Updated { get ; set ; }

		/// <summary>
		/// Gets/sets the id of the user who initially created the permission.
		/// </summary>
		public Guid? CreatedById { get ; set ; }

		/// <summary>
		/// Gets/sets the id of the user who last updated the permission.
		/// </summary>
		public Guid? UpdatedById { get ; set ; }
		#endregion

		#region Relationships
		/// <summary>
		/// Gets/sets the group attached to the permission.
		/// </summary>
		public Group Group { get ; set ; }

		/// <summary>
		/// Gets/sets the user who initially created the permission.
		/// </summary>
		public User CreatedBy { get ; set ; }

		/// <summary>
		/// Gets/sets the user who last updated the permission.
		/// </summary>
		public User UpdatedBy { get ; set ; }
		#endregion
	}
}
