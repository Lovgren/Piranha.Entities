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
	internal class PostMap : BaseEntityMap<Post>
	{
		/// <summary>
		/// Default constructur. Sets up the basic entity mapping.
		/// </summary>
		public PostMap() : base() {
			HasKey(p => new { p.Id, p.IsDraft }) ;

			Property(p => p.Title).IsRequired().HasMaxLength(128) ;
			Property(p => p.Excerpt).HasMaxLength(255) ;
			Property(p => p.ViewTemplate).HasMaxLength(128) ;
			Property(p => p.ArchiveTemplate).HasMaxLength(128) ;

			HasRequired(p => p.Template) ;
			HasRequired(p => p.Permalink) ;
			HasMany(p => p.Properties).WithRequired().HasForeignKey(pr => new { pr.ParentId, pr.IsDraft }) ;
		}
	}
}
