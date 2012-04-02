using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piranha.Entities
{
	/// <summary>
	/// Permission entity.
	/// </summary>
	public class Permission : BaseEntity
	{
		#region Fields
		public Guid GroupId { get ; set ; }
		public string Name { get ; set ; }
		public string Description { get ; set ; }
		public bool IsLocked { get ; set ; }
		#endregion

		#region Relations
		/// <summary>
		/// Gets/sets the group associated with the permission.
		/// </summary>
		public Group Group { get ; set ; }
		#endregion
	}
}
