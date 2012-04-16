using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Piranha.Entities;

namespace Piranha.Models.Manager.SettingModels
{
	/// <summary>
	/// Group list model for the manager area.
	/// </summary>
	public class GroupListModel
	{
		#region Properties
		/// <summary>
		/// Gets/sets the available groups.
		/// </summary>
		public List<Group> Groups { get ; set ; }
		#endregion

		/// <summary>
		/// Default constructor. Creates a new model.
		/// </summary>
		public GroupListModel() {
			Groups = new List<Group>() ;
		}

		/// <summary>
		/// Gets the list model for all available groups.
		/// </summary>
		/// <returns>The model</returns>
		public static GroupListModel Get() {
			var m = new GroupListModel() ;

			using (var db = new Data.PiranhaContext()) {
				m.Groups = db.Groups.GetFlattenedStructure() ;
			}
			return m ;
		}
	}
}
