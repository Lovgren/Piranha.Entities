using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piranha.Entities
{
	public class Region : BaseEntity<Region>
	{
		#region Fields
		public bool IsDraft { get ; set ; }
		public Guid PageId { get ; set ; }
		public bool PageIsDraft { get ; set ; }
		public string Name { get ; set ; }
		public string Body { get ; set ; }
		#endregion

		#region Associations
		public Page Page { get ; set ; }
		#endregion
	}
}
