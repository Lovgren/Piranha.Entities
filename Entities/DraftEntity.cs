using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piranha.Entities
{
	/// <summary>
	/// Base class for draftable entities in the Piranha entity model.
	/// </summary>
	public abstract class DraftEntity : BaseEntity
	{
		#region Fields
		/// <summary>
		/// Gets/sets weather this object is a draft or not.
		/// </summary>
		public bool IsDraft { get ; set ; }

		/// <summary>
		/// Gets/sets the initial publish date for the entity.
		/// </summary>
		public DateTime Published { get ; set ; }

		/// <summary>
		/// Gets/sets the last published date.
		/// </summary>
		public DateTime LastPublished { get ; set ; }
		#endregion
	}
}
