using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Piranha.Entities;

namespace Piranha.Models.Manager.SettingModels
{
	/// <summary>
	/// Param list model for the manager area.
	/// </summary>
	public class ParamListModel
	{
		#region Properties
		/// <summary>
		/// Gets/sets the available params.
		/// </summary>
		public List<Param> Params { get ; set ; }
		#endregion

		/// <summary>
		/// Default constructor. Creates a new model.
		/// </summary>
		public ParamListModel() {
			Params = new List<Param>() ;
		}

		/// <summary>
		/// Gets the list model for all available params.
		/// </summary>
		/// <returns>The model</returns>
		public static ParamListModel Get() {
			var m = new ParamListModel() ;

			using (var db = new Data.PiranhaContext()) {
				m.Params = db.Params.OrderBy(p => p.Name).ToList() ;
			}
			return m ;
		}
	}
}
