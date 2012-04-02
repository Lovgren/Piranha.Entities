using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Piranha.Entities.Maps
{
	/// <summary>
	/// Entity configuration map for the permalink.
	/// </summary>
	internal class PermalinkMap : BaseEntityMap<Permalink> 
	{
		/// <summary>
		/// Default constructur. Sets up the basic entity mapping.
		/// </summary>
		public PermalinkMap() : base() {
			Property(p => p.Type).IsRequired().HasMaxLength(16) ;
			Property(p => p.Name).IsRequired().HasMaxLength(128) ;
		}
	}
}
