using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Piranha.Entities.Maps
{
	/// <summary>
	/// Entity map for media.
	/// </summary>
	internal class MediaMap : EntityTypeConfiguration<Media>
	{
		public MediaMap() {
			ToTable("content") ;

			Property(m => m.Id).HasColumnName("content_id") ;
			Property(m => m.Filename).HasColumnName("content_filename").IsRequired().HasMaxLength(128) ;
			Property(m => m.ContentType).HasColumnName("content_type").IsRequired().HasMaxLength(255) ;
			Property(m => m.Size).HasColumnName("content_size") ;
			Property(m => m.IsImage).HasColumnName("content_image") ;
			Property(m => m.Width).HasColumnName("content_width") ;
			Property(m => m.Height).HasColumnName("content_height") ;
			Property(m => m.AltText).HasColumnName("content_alt").HasMaxLength(128) ;
			Property(m => m.Description).HasColumnName("content_description").HasMaxLength(255) ;
			Property(m => m.Created).HasColumnName("content_created") ;
			Property(m => m.Updated).HasColumnName("content_updated") ;
			Property(m => m.CreatedById).HasColumnName("content_created_by") ;
			Property(m => m.UpdatedById).HasColumnName("content_updated_by") ;

			HasRequired(m => m.CreatedBy) ;
			HasRequired(m => m.UpdatedBy) ;
		}
	}
}
