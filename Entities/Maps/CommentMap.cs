using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Piranha.Entities.Maps
{
	/// <summary>
	/// Entity map for comments.
	/// </summary>
	public class CommentMap : EntityTypeConfiguration<Comment>
	{
		public CommentMap() {
			Property(c => c.Id).HasColumnName("comment_id") ;
			Property(c => c.ParentId).HasColumnName("comment_parent_id") ;
			Property(c => c.IsApproved).HasColumnName("comment_is_approved") ;
			Property(c => c.Title).HasColumnName("comment_title").HasMaxLength(128) ;
			Property(c => c.Body).HasColumnName("comment_body") ;
			Property(c => c.Created).HasColumnName("comment_created") ;
			Property(c => c.Approved).HasColumnName("comment_approved") ;
			Property(c => c.CreatedById).HasColumnName("comment_created_by") ;
			Property(c => c.CreatedByName).HasColumnName("comment_created_by_name").HasMaxLength(64) ;
			Property(c => c.CreatedByEmail).HasColumnName("comment_created_by_email").HasMaxLength(128) ;
			Property(c => c.ApprovedById).HasColumnName("comment_approved_by") ;

			HasOptional(c => c.CreatedBy) ;
			HasOptional(c => c.ApprovedBy) ;
		}
	}
}
