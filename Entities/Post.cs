using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piranha.Entities
{
	public class Post : DraftEntity
	{
		#region Fields
		public Guid TemplateId { get ; set ; }
		public Guid PermalinkId { get ; set ; }
		public string Title { get ; set ; }
		public string Excerpt { get ; set ; }
		public string Body { get ; set ; }
		public string Attachments { get ; set ; }
		public string ViewTemplate { get ; set ; }
		public string ArchiveTemplate { get ; set ; }
		#endregion

		#region Associations
		public PostTemplate Template { get ; set ; }
		public Permalink Permalink { get ; set ; }
		public IList<Property> Properties { get ; set ; }
		#endregion
	}
}
