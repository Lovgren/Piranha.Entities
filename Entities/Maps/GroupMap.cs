using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Piranha.Entities.Maps
{
	/// <summary>
	/// Entity configuration map for the group.
	/// </summary>
	internal class GroupMap : BaseEntityMap<Group>
	{
		/// <summary>
		/// Default constructur. Sets up the basic entity mapping.
		/// </summary>
		public GroupMap() : base() {
			Property(g => g.Name).IsRequired().HasMaxLength(64) ;
			Property(g => g.Description).HasMaxLength(255) ;

			HasOptional(g => g.Parent) ;
			HasMany(g => g.Users).WithOptional(u => u.Group) ;

			Ignore(g => g.Level) ;
			Ignore(g => g.Groups) ;
		}
	}

}
