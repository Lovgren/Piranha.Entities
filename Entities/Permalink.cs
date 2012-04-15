using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piranha.Entities
{
	public class Permalink : BaseEntity<Permalink>
	{
		#region Fields
		public string Type { get ; set ; }
		public string Name { get ; set ; }
		#endregion
	}
}
