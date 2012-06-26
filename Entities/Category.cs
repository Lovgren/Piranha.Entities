using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piranha.Entities
{
	public class Category : BaseEntity
	{
		#region Properties
		public Guid Id { get ; set ; }
		public Guid? ParentId { get ; set ; }
		public Guid PermalinkId { get ; set ; }
		public string Name { get ; set ; }
		public string Description { get ; set ; }
		public DateTime Created { get ; set ; }
		public DateTime Updated { get ; set ; }
		public Guid CreatedById { get ; set ; }
		public Guid UpdatedById { get ; set ; }
		#endregion

		#region Relationships
		/// <summary>
		/// Gets/sets the optional parent category.
		/// </summary>
		public Category Parent { get ; set ; }

		/// <summary>
		/// Gets/sets the permalink used to access the category.
		/// </summary>
		public Permalink Permalink { get ; set ; }

		/// <summary>
		/// Gets/sets the user who initially created the category.
		/// </summary>
		public User CreatedBy { get ; set ; }

		/// <summary>
		/// Gets/sets the user who last updated the category.
		/// </summary>
		public User UpdatedBy { get ; set ; }
		#endregion
	}
}
