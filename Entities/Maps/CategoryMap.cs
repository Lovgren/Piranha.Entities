using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Piranha.Entities.Maps
{
	/// <summary>
	/// Entity configuration map for the category.
	/// </summary>
	public class CategoryMap : BaseEntityMap<Category> 
	{
		/// <summary>
		/// Default constructur. Sets up the basic entity mapping.
		/// </summary>
		public CategoryMap() : base() {
			Property(c => c.Name).IsRequired().HasMaxLength(64) ;
			Property(c => c.Description).HasMaxLength(255) ;

			HasOptional(c => c.Parent) ;
		}
	}
}
