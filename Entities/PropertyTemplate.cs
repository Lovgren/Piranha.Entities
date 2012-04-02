using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piranha.Entities
{
	/// <summary>
	/// Property template entity.
	/// </summary>
	public class PropertyTemplate
	{
		#region Fields
		/// <summary>
		/// Gets/sets the entity id.
		/// </summary>
		public Guid Id { get ; set ; }

		/// <summary>
		/// Gets/sets the id of the associated property.
		/// </summary>
		public Guid TemplateId { get ; set ; }

		/// <summary>
		/// Gets/sets the full type name of the property.
		/// </summary>
		public string Type { get ; set ; }

		/// <summary>
		/// Gets/sets the property name.
		/// </summary>
		public string Name { get ; set ; }
		#endregion
	}
}
