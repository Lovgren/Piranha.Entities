using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piranha.Entities
{
	/// <summary>
	/// Category entitiy.
	/// </summary>
	public class Category : BaseEntity
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

		#region Relations
		/// <summary>
		/// Gets/sets the optional parent page.
		/// </summary>
		public Category Parent { get ; set ; }
		#endregion
	}
}
