using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piranha.Entities
{
	/// <summary>
	/// Property entity.
	/// </summary>
	public class Property : DraftEntity<Property>
	{
		#region Fields
		/// <summary>
		/// Gets/sets the id of the associated parent entity.
		/// </summary>
		public Guid ParentId { get ; set ; }

		/// <summary>
		/// Gets/sets the name.
		/// </summary>
		public string Name { get ; set ; }

		/// <summary>
		/// Gets/sets the value.
		/// </summary>
		public string Value { get ; set ; }
		#endregion
	}
}
