using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piranha.Entities
{
	/// <summary>
	/// Param entity.
	/// </summary>
	public class Param : BaseEntity
	{
		#region Fields
		public string Name { get ; set ; }
		public string Value { get ; set ; }
		public string Description { get ; set ; }
		public bool IsLocked { get ; set ; }
		#endregion
	}
}
