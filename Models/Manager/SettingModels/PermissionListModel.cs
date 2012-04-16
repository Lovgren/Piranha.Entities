using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Piranha.Entities;

namespace Piranha.Models.Manager.SettingModels
{
	/// <summary>
	/// Permission list model for the manager area.
	/// </summary>
	public class PermissionListModel
	{
		#region Properties
		/// <summary>
		/// Gets/sets the available permissions.
		/// </summary>
		public List<Permission> Permissions { get ; set ; }
		#endregion

		/// <summary>
		/// Default constructor. Creates a new model.
		/// </summary>
		public PermissionListModel() {
			Permissions = new List<Permission>() ;
		}

		/// <summary>
		/// Gets the list model for all available permissions.
		/// </summary>
		/// <returns>The model</returns>
		public static PermissionListModel Get() {
			var m = new PermissionListModel() ;

			using (var db = new Data.PiranhaContext()) {
				m.Permissions = db.Permissions.OrderBy(p => p.Name).ToList() ;
			}
			return m ;
		}
	}
}
