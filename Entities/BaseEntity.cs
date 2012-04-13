using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Web;

namespace Piranha.Entities
{
	/// <summary>
	/// Base class for entities in the Piranha entity model.
	/// </summary>
	public abstract class BaseEntity
	{
		#region Fields
		/// <summary>
		/// Gets/sets the entity id.
		/// </summary>
		public Guid Id { get ; set ; }

		/// <summary>
		/// Gets/sets the created date.
		/// </summary>
		public DateTime Created { get ; set ; }

		/// <summary>
		/// Gets/sets the updated date.
		/// </summary>
		public DateTime Updated { get ; set ; }

		/// <summary>
		/// Gets/sets the id of the user who created the entity.
		/// </summary>
		public Guid CreatedById { get ; set ; }

		/// <summary>
		/// Gets/sets the id of the user who last updated the entity.
		/// </summary>
		public Guid UpdatedById { get ; set ; }
		#endregion

		#region Associations
		/// <summary>
		/// Gets/sets the user who created the entity.
		/// </summary>
		public User CreatedBy { get ; set ; }

		/// <summary>
		/// Gets/sets the user who last updated the entity.
		/// </summary>
		public User UpdatedBy { get ; set ; }
		#endregion

		/// <summary>
		/// Executed before the entity is saved by the context.
		/// </summary>
		/// <param name="state">The current entity state</param>
		public virtual void OnSave(EntityState state) {
			var user = HttpContext.Current.User ;

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
			} else throw new AccessViolationException("User must be logged in to save data.") ;
		}

		/// <summary>
		/// Executed before the entity is deleted by the context.
		/// </summary>
		public virtual void OnDelete() {
			if (!HttpContext.Current.User.Identity.IsAuthenticated)
				throw new AccessViolationException("User must be logged in to delete data.") ;
		}
	}
}
