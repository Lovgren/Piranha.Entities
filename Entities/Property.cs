﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piranha.Entities
{
	/// <summary>
	/// The property entity
	/// </summary>
	public class Property : StandardEntity<Property>
	{
		#region Properties
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
		#endregion
	}
}
