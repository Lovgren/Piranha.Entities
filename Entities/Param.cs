using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piranha.Entities
{
	/// <summary>
	/// The param entity.
	/// </summary>
	public class Param : BaseEntity
	{
		#region Properties
		/// <summary>
		/// Gets/sets the unique parameter id.
		/// </summary>
		public Guid Id { get ; set ; }

		/// <summary>
		/// Gets/sets the name of the parameter.
		/// </summary>
		public string Name { get ; set ; }

		/// <summary>
		/// Gets/sets the value of the parameter.
		/// </summary>
		public string Value { get ; set ; }

		/// <summary>
		/// Gets/sets the parameter description.
		/// </summary>
		public string Description { get ; set ; }

		/// <summary>
		/// Gets/sets weather the parameter can be removed or not.
		/// </summary>
		public bool IsLocked { get ; set ; }

		/// <summary>
		/// Gets/sets the date the parameter was initially created.
		/// </summary>
		public DateTime Created { get ; set ; }

		/// <summary>
		/// Gets/sets the date the parameter was last updated.
		/// </summary>
		public DateTime Updated { get ; set ; }

		/// <summary>
		/// Gets/sets the id of the user who initially created the parameter.
		/// </summary>
		public Guid? CreatedById { get ; set ; }

		/// <summary>
		/// Gets/sets the id of the user who last updated the parameter.
		/// </summary>
		public Guid? UpdatedById { get ; set ; } 
		#endregion

		#region Relationships
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
