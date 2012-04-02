using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;

namespace Piranha.Entities.Maps
{
	/// <summary>
	/// Entity configuration map for the base entity. Providers primary key mapping
	/// and relations for CreateBy and UpdatedBy.
	/// </summary>
	/// <typeparam name="T">The entity type</typeparam>
	public abstract class BaseEntityMap<T> : EntityTypeConfiguration<T> where T : BaseEntity
	{
		/// <summary>
		/// Default constructur. Sets up the basic entity mapping.
		/// </summary>
		public BaseEntityMap() {
			HasKey(b => b.Id) ;
			HasRequired(g => g.CreatedBy) ;
			HasRequired(g => g.UpdatedBy) ;
		}
	}
}
