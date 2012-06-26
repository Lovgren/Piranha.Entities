using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Piranha.Entities
{
	/// <summary>
	/// Entity base class exposing some events.
	/// </summary>
	public class BaseEntity
	{
		/// <summary>
		/// Attaches the entity to the given context with the specified state.
		/// </summary>
		/// <param name="db">The db context</param>
		/// <param name="state">The entity state</param>
		public void Attach(DataContext db, EntityState state) {
			db.Entry(this).State = state ;
		}

		/// <summary>
		/// Called when the entity has been loaded.
		/// </summary>
		/// <param name="?"></param>
		public virtual void OnLoad() {}

		/// <summary>
		/// Called when the entity is about to get saved.
		/// </summary>
		/// <param name="state">The current entity state</param>
		public virtual void OnSave(EntityState state) {}

		/// <summary>
		/// Called when the entity is about to get deleted.
		/// </summary>
		public virtual void OnDelete() {}
	}
}
