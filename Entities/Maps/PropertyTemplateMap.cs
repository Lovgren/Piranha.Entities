using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Piranha.Entities.Maps
{
	/// <summary>
	/// Entity configuration map for the property template.
	/// </summary>
	internal class PropertyTemplateMap : EntityTypeConfiguration<PropertyTemplate>
	{
		/// <summary>
		/// Default constructur. Sets up the basic entity mapping.
		/// </summary>
		public PropertyTemplateMap() {
			HasKey(p => p.Id) ;

			Property(p => p.TemplateId).IsRequired() ;
			Property(p => p.Name).IsRequired() ;
			Property(p => p.Type).IsRequired() ;
		}
	}
}
