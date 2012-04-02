using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Piranha.Entities.Maps
{
	/// <summary>
	/// Entity configuration map for the upload.
	/// </summary>
	internal class UploadMap : EntityTypeConfiguration<Upload>
	{
		/// <summary>
		/// Default constructur. Sets up the basic entity mapping.
		/// </summary>
		public UploadMap() : base() {
			HasKey(u => u.Id) ;

			Property(u => u.Filename).IsRequired().HasMaxLength(128) ;
			Property(u => u.Type).IsRequired().HasMaxLength(64) ;

			HasRequired(u => u.CreatedBy) ;
		}
	}
}
