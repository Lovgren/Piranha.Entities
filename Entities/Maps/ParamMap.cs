using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Piranha.Entities.Maps
{
	/// <summary>
	/// Entity configuration map for the param.
	/// </summary>
	internal class ParamMap : BaseEntityMap<Param> 
	{
		/// <summary>
		/// Default constructur. Sets up the basic entity mapping.
		/// </summary>
		public ParamMap() : base() {
			Property(p => p.Name).IsRequired().HasMaxLength(64) ;
			Property(p => p.Value).HasMaxLength(128) ;
			Property(p => p.Description).HasMaxLength(255) ;
		}
	}
}
