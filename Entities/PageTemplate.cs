using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piranha.Entities
{
	public class PageTemplate : BaseEntity<PageTemplate>
	{
		#region Fields
		public string Name { get ; set ; }
		public string Description { get ; set ; }
		public string Preview { get ; set ; }
		public string Regions { get ; set ; }
		public string ViewTemplate { get ; set ; }
		public bool ShowViewTemplate { get ; set ; }
		public string ViewRedirect { get ; set ; }
		public bool ShowViewRedirect { get ; set ; }
		#endregion

		#region Associations
		public IList<PropertyTemplate> Properties { get ; set ; }
		#endregion
	}
}
