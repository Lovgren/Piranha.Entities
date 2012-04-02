using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Piranha.Entities.Maps
{
	/// <summary>
	/// Entity configuration map for the permission.
	/// </summary>
	internal class PermissionMap : BaseEntityMap<Permission>
	{
		/// <summary>
		/// Default constructur. Sets up the basic entity mapping.
		/// </summary>
		public PermissionMap() : base() {
			Property(p => p.Name).IsRequired().HasMaxLength(64) ;
			Property(p => p.Description).HasMaxLength(255) ;

			HasRequired(p => p.Group) ;
		}
	}
}
