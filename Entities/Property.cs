using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piranha.Entities
{
	/// <summary>
	/// The property entity
	/// </summary>
	public class Property
	{
		#region Properties
		/// <summary>
		/// Gets/sets the unique property id.
		/// </summary>
		public Guid Id { get ; set ; }

		/// <summary>
		/// Gets/sets weather this property instance is a draft.
		/// </summary>
		internal bool IsDraft { get ; set ; }

		/// <summary>
		/// Gets/sets the id of the parent this property is attached to.
		/// </summary>
		public Guid ParentId { get ; set ; }

		/// <summary>
		/// Gets/sets the property name.
		/// </summary>
		public string Name { get ; set ; }

		/// <summary>
		/// Gets/sets the property value.
		/// </summary>
		public string Value { get ; set ; }

		/// <summary>
		/// Gets/sets the date the property was initially created.
		/// </summary>
		public DateTime Created { get ; set ; }

		/// <summary>
		/// Gets/sets the date the property was last updated.
		/// </summary>
		public DateTime Updated { get ; set ; }

		/// <summary>
		/// Gets/sets the id of the user who intially created the property.
		/// </summary>
		public Guid CreatedById { get ; set ; }

		/// <summary>
		/// Gets/sets the id of the user who last updated the property.
		/// </summary>
		public Guid UpdatedById { get ; set ; }
		#endregion

		#region Relationships
		/// <summary>
		/// Gets/sets the user who initially created the property.
		/// </summary>
		public User CreatedBy { get ; set ; }

		/// <summary>
		/// Gets/sets the user who last updated the property.
		/// </summary>
		public User UpdatedBy { get ; set ; }		
		#endregion
	}
}
