using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using Piranha.Entities;

namespace Piranha.Models.Manager.SettingModels
{
	/// <summary>
	/// Param edit model for the manager area.
	/// </summary>
	public class ParamEditModel
	{
		#region Properties
		/// <summary>
		/// Gets/sets the current param.
		/// </summary>
		public Param Param { get ; set ; }
		#endregion

		/// <summary>
		/// Default construtctor. Creates a new model.
		/// </summary>
		public ParamEditModel() {
			Param = new Param() ;
		}

		/// <summary>
		/// Gets the model for the specified param
		/// </summary>
		/// <param name="id">The id</param>
		/// <returns>The model</returns>
		public ParamEditModel GetById(Guid id) {
			var m = new ParamEditModel() ;

			using (var db = new Data.PiranhaContext()) {
				m.Param = db.Params.Where(p => p.Id == id).Single() ;
			}
			return m ;
		}

		/// <summary>
		/// Saves the current model.
		/// </summary>
		/// <returns>Weather the action was successful</returns>
		public bool SaveAll() {
			using (var db = new Data.PiranhaContext()) {
				Param.Attach(db) ;
				return db.SaveChanges() > 0 ;
			}
		}

		/// <summary>
		/// Deletes the current model.
		/// </summary>
		/// <returns>Weather the action was successful</returns>
		public bool DeleteAll() {
			using (var db = new Data.PiranhaContext()) {
				Param.Attach(db, EntityState.Deleted) ;
				return db.SaveChanges() > 0 ;
			}
		}
	}
}
