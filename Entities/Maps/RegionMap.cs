using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Piranha.Entities.Maps
{
	/// <summary>
	/// Entity configuration map for the region.
	/// </summary>
	internal class RegionMap : BaseEntityMap<Region> 
	{
		/// <summary>
		/// Default constructur. Sets up the basic entity mapping.
		/// </summary>
		public RegionMap() : base() {
			HasKey(r => new { r.Id, r.IsDraft }) ;

			Property(p => p.Name).IsRequired().HasMaxLength(64) ;

			HasRequired(p => p.Page) ;
		}
	}
}
