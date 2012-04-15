using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piranha.Entities
{
	public class PostTemplate : BaseEntity<PostTemplate>
	{
		#region Fields
		public string Name { get ; set ; }
		public string Description { get ; set ; }
		public string Preview { get ; set ; }
		public string ViewTemplate { get ; set ; }
		public bool ShowViewTemplate { get ; set ; }
		public string ArchiveTemplate { get ; set ; }
		public bool ShowArchiveTemplate { get ; set ; }
		#endregion

		#region Associations
		public List<PropertyTemplate> Properties { get ; set ; }
		#endregion
	}
}
