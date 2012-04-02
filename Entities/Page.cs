using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piranha.Entities
{
	public class Page : DraftEntity
	{
		#region Fields
		public Guid TemplateId { get ; set ; }
		public Guid? GroupId { get ; set ; }
		public Guid PermalinkId { get ; set ; }
		public Guid? ParentId { get ; set ; }
		public int Seqno { get ; set ; }
		public string Title { get ; set ; }
		public string NavigationTitle { get ; set ; }
		public bool IsHidden { get ; set ; }
		public string Keywords { get ; set ; }
		public string Description { get ; set ; }
		public string Attachments { get ; set ; }
		public string ViewTemplate { get ; set ; }
		public string ViewRedirect { get ; set ; }
		#endregion

		#region Associations
		public PageTemplate Template { get ; set ; }
		public Group Group { get ; set ; }
		public Permalink Permalink { get ; set ; }
		public IList<Region> Regions { get ; set ; }
		public IList<Property> Properties { get ; set ; }
		#endregion
	}
}
