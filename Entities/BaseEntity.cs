using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Piranha.Entities
{
	/// <summary>
	/// Base class for entities in the Piranha entity model.
	/// </summary>
	public abstract class BaseEntity
	{
		#region Fields
		/// <summary>
		/// Gets/sets the entity id.
		/// </summary>
		public Guid Id { get ; set ; }

		/// <summary>
		/// Gets/sets the created date.
		/// </summary>
		public DateTime Created { get ; set ; }

		/// <summary>
		/// Gets/sets the updated date.
		/// </summary>
		public DateTime Updated { get ; set ; }

		/// <summary>
		/// Gets/sets the id of the user who created the entity.
		/// </summary>
		public Guid CreatedById { get ; set ; }

		/// <summary>
		/// Gets/sets the id of the user who last updated the entity.
		/// </summary>
		public Guid UpdatedById { get ; set ; }
		#endregion

		#region Associations
		/// <summary>
		/// Gets/sets the user who created the entity.
		/// </summary>
		public User CreatedBy { get ; set ; }

		/// <summary>
		/// Gets/sets the user who last updated the entity.
		/// </summary>
		public User UpdatedBy { get ; set ; }
		#endregion
	}
}
