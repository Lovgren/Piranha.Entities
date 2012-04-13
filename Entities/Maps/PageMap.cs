using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Piranha.Entities.Maps
{
	/// <summary>
	/// Entity configuration map for the param.
	/// </summary>
	internal class PageMap : BaseEntityMap<Page>
	{
		/// <summary>
		/// Default constructur. Sets up the basic entity mapping.
		/// </summary>
		public PageMap() : base() {
			HasKey(p => new { p.Id, p.IsDraft }) ;

			Property(p => p.Title).IsRequired().HasMaxLength(128) ;
			Property(p => p.NavigationTitle).HasMaxLength(128) ;
			Property(p => p.Keywords).HasMaxLength(128) ;
			Property(p => p.Description).HasMaxLength(255) ;
			Property(p => p.ViewTemplate).HasMaxLength(128) ;
			Property(p => p.ViewRedirect).HasMaxLength(128) ;

			HasRequired(p => p.Template) ;
			HasOptional(p => p.Group) ;
			HasRequired(p => p.Permalink) ;
			HasMany(p => p.Regions).WithRequired(r => r.Page) ;
			HasMany(p => p.Properties).WithRequired().HasForeignKey(pr => new { pr.ParentId, pr.IsDraft }) ;
			HasMany(p => p.Content).WithMany().Map(m => m.ToTable("Attachments").MapLeftKey("ParentId").MapRightKey("ContentId")) ;
		}
	}
}
