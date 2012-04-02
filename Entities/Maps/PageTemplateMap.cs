using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Piranha.Entities.Maps
{
	/// <summary>
	/// Entity configuration map for the page template.
	/// </summary>
	internal class PageTemplateMap : BaseEntityMap<PageTemplate>
	{
		/// <summary>
		/// Default constructur. Sets up the basic entity mapping.
		/// </summary>
		public PageTemplateMap() : base() {
			Property(pt => pt.Name).IsRequired().HasMaxLength(64) ;
			Property(pt => pt.Description).HasMaxLength(255) ;
			Property(pt => pt.ViewTemplate).HasMaxLength(128) ;
			Property(pt => pt.ViewRedirect).HasMaxLength(128) ;

			HasMany(pt => pt.Properties).WithRequired().HasForeignKey(p => p.TemplateId) ;
		}
	}
}
