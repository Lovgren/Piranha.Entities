using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Piranha.Entities.Maps
{
	/// <summary>
	/// Entity configuration map for the user.
	/// </summary>
	internal class UserMap : EntityTypeConfiguration<User>
	{
		/// <summary>
		/// Default constructur. Sets up the basic entity mapping.
		/// </summary>
		public UserMap() {
			HasKey(u => u.Id) ;

			Property(u => u.Login).IsRequired().HasMaxLength(64) ;
			Property(u => u.Password).HasMaxLength(64) ;
			Property(u => u.Firstname).HasMaxLength(128) ;
			Property(u => u.Surname).HasMaxLength(128) ;
			Property(u => u.Email).HasMaxLength(128) ;
			Property(u => u.Culture).HasMaxLength(5) ;

			HasOptional(u => u.Group) ;
		}
	}
}
