using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.Mvc;

using Piranha.Entities;

namespace Piranha.Models.Manager.SettingModels
{
	public class PermissionEditModel
	{
		#region Properties
		/// <summary>
		/// Gets/sets the current access record.
		/// </summary>
		public Permission Permission { get ; set ; }

		/// <summary>
		/// Gets/sets the available groups.
		/// </summary>
		public SelectList Groups { get ; set ; }
		#endregion

		/// <summary>
		/// Default constructor. Creates a new model.
		/// </summary>
		public PermissionEditModel() {
			Permission = new Permission() ;

			using (var db = new Data.PiranhaContext()) {
				var groups = db.Groups.GetFlattenedStructure() ;
				groups.Insert(0, new Group() { Name = "" }) ;
				Groups = new SelectList(groups, "Id", "Name") ;
			}
		}

		/// <summary>
		/// Gets the specified access model.
		/// </summary>
		/// <param name="id">The access id</param>
		/// <returns>The model</returns>
		public static PermissionEditModel GetById(Guid id) {
			var m = new PermissionEditModel() ;

			using (var db = new Data.PiranhaContext()) {
				m.Permission = db.Permissions.Where(p => p.Id == id).Single() ;
			}
			return m ;
		}

		/// <summary>
		/// Saves the access and all related information.
		/// </summary>
		/// <returns>Weather the action succeeded or not.</returns>
		public bool SaveAll() {
			using (var db = new Data.PiranhaContext()) {
				Permission.Attach(db) ;
				return db.SaveChanges() > 0 ;
			}
		}

		/// <summary>
		/// Deletes the access and all related information.
		/// </summary>
		/// <returns>Weather the action succeeded or not.</returns>
		public bool DeleteAll() {
			using (var db = new Data.PiranhaContext()) {
				Permission.Attach(db, EntityState.Deleted) ;
				return db.SaveChanges() > 0 ;
			}
		}
	}
}
