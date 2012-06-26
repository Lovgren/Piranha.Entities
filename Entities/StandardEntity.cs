﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace Piranha.Entities
{
	/// <summary>
	/// Base class for a standard Piranha entity owned by a system user.
	/// </summary>
	/// <typeparam name="T">The entity type</typeparam>
	public abstract class StandardEntity<T> : BaseEntity where T : StandardEntity<T>
	{
		#region Properties
		/// <summary>
		/// Gets/sets the unique id.
		/// </summary>
		public Guid Id { get ; set ; }

		/// <summary>
		/// Gets/sets the date the entity was initially created.
		/// </summary>
		public DateTime Created { get ; set ; }

		/// <summary>
		/// Gets/sets the date the entity was last updated.
		/// </summary>
		public DateTime Updated { get ; set ; }

		/// <summary>
		/// Gets/sets the id of the user who initially created the entity.
		/// </summary>
		public Guid CreatedById { get ; set ; }

		/// <summary>
		/// Gets/sets the id of the user who last updated the entity.
		/// </summary>
		public Guid UpdatedById { get ; set ; }
		#endregion

		#region Navigation properties
		/// <summary>
		/// Gets/sets the user who initially created the entity.
		/// </summary>
		public User CreatedBy { get ; protected set ; }

		/// <summary>
		/// Gets/sets the user who last updated the entity.
		/// </summary>
		public User UpdatedBy { get ; protected set ; }
		#endregion

		/// <summary>
		/// Attaches the entity to the given context.
		/// </summary>
		/// <param name="db">The db context</param>
		public void Attach(DataContext db) {
			if (this.Id == Guid.Empty || db.Set<T>().Count(t => t.Id == this.Id) == 0)
				db.Entry(this).State = EntityState.Added ;
			else db.Entry(this).State = EntityState.Modified ;
		}

		/// <summary>
		/// Saves the current entity.
		/// </summary>
		/// <param name="state">The current entity state</param>
		public override void OnSave(System.Data.EntityState state) {
			var user = HttpContext.Current.User;

			if (user.Identity.IsAuthenticated) {
				if (state == EntityState.Added) {
					if (Id == Guid.Empty)
						Id = Guid.NewGuid() ;
					Created = Updated = DateTime.Now ;
					CreatedById = UpdatedById = new Guid(user.Identity.Name) ;
				} else if (state == EntityState.Modified) {
					Updated = DateTime.Now ;
					UpdatedById = new Guid(user.Identity.Name) ;
				}
			} else throw new UnauthorizedAccessException("User must be logged in to save entity") ;
		}

		/// <summary>
		/// Deletes the current entity.
		/// </summary>
		public override void OnDelete() {
			if (!HttpContext.Current.User.Identity.IsAuthenticated)
				throw new UnauthorizedAccessException("User must be logged in to delete entity") ;
		}
	}
}
