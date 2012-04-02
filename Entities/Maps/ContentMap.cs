using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piranha.Entities.Maps
{
	/// <summary>
	/// Entity configuration map for the content.
	/// </summary>
	internal class ContentMap : BaseEntityMap<Content>
	{
		/// <summary>
		/// Default constructur. Sets up the basic entity mapping.
		/// </summary>
		public ContentMap() : base() {
			Property(c => c.Name).IsRequired().HasMaxLength(64) ;
			Property(c => c.Filename).IsRequired().HasMaxLength(128) ;
			Property(c => c.Type).IsRequired().HasMaxLength(64) ;
			Property(c => c.AltText).HasMaxLength(128) ;
			Property(c => c.Description).HasMaxLength(255) ;
		}
	}
}
