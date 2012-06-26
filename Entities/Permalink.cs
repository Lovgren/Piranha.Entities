using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piranha.Entities
{
	/// <summary>
	/// The permalink entity.
	/// </summary>
	public class Permalink : BaseEntity
	{
		#region Properties
		/// <summary>
		/// Gets/sets the unique id of the permalink.
		/// </summary>
		public Guid Id { get ; set ; }

		/// <summary>
		/// Gets/sets the type of entity the permalink is attached to (PAGE/POST).
		/// </summary>
		public string Type { get ; set ; }

		/// <summary>
		/// Gets/sets the unique permalink name.
		/// </summary>
		public string Name { get ; set ; }

		/// <summary>
		/// Gets/sets the date the permalink was initially created.
		/// </summary>
		public DateTime Created { get ; set ; }

		/// <summary>
		/// Gets/sets the date the permalink was last updated.
		/// </summary>
		public DateTime Updated { get ; set ; }

		/// <summary>
		/// Gets/sets the id of the user who initially created the permalink.
		/// </summary>
		public Guid CreatedById { get ; set ; }

		/// <summary>
		/// Gets/sets the id of the user who last updated the permalink.
		/// </summary>
		public Guid UpdatedById { get ; set ; }
		#endregion

		#region Relationships
		/// <summary>
		/// Gets/sets the user who initially created the permalink.
		/// </summary>
		public User CreatedBy { get ; set ; }

		/// <summary>
		/// Gets/sets the user who last updated the permalink.
		/// </summary>
		public User UpdatedBy { get ; set ; }
		#endregion
	}
}
