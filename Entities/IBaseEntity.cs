using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Piranha.Entities
{
	/// <summary>
	/// Interface for base entities.
	/// </summary>
	public interface IBaseEntity
	{
		/// <summary>
		/// Executed before the entity is saved by the context.
		/// </summary>
		/// <param name="state">The current entity state</param>
		void OnSave(EntityState state) ;

		/// <summary>
		/// Executed before the entity is deleted by the context.
		/// </summary>
		void OnDelete() ;

		/// <summary>
		/// Executed when an entity should be invalidated from any potential cache.
		/// </summary>
		/// <param name="state">The entity state</param>
		void OnInvalidate(EntityState state) ;

	}
}
