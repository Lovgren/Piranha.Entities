using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Piranha.Entities.Maps
{
	/// <summary>
	/// Entity configuration map for the property.
	/// </summary>
	internal class PropertyMap : EntityTypeConfiguration<Property>
	{
		/// <summary>
		/// Default constructur. Sets up the basic entity mapping.
		/// </summary>
		public PropertyMap() {
			Property(p => p.ParentId).IsRequired() ;
			Property(p => p.Name).IsRequired() ;
		}
	}
}
