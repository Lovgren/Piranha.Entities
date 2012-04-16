﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.Mvc;

using Piranha.Entities;

namespace Piranha.Models.Manager.SettingModels
{
	/// <summary>
	/// Group edit model for the manager area.
	/// </summary>
	public class GroupEditModel
	{
		#region Properties
		/// <summary>
		/// Gets/sets the group.
		/// </summary>
		public Group Group { get ; set ; }
		
		/// <summary>
		/// Gets/sets of all of the other groups.
		/// </summary>
		public SelectList Groups { get ; set ; }

		/// <summary>
		/// Gets/sets the members of the group.
		/// </summary>
		public List<User> Members { get ; set ; }
		#endregion

		/// <summary>
		/// Default constructor. Creates a new model.
		/// </summary>
		public GroupEditModel() {
			Group = new Group() ;
	
			using (var db = new Data.PiranhaContext()) {
				var groups = db.Groups.OrderBy(g => g.Name).Select(g => new Group() { Id = g.Id, Name = g.Name }).ToList() ;
				groups.Insert(0, new Group() { Name = "" }) ;
				Groups = new SelectList(groups, "Id", "Name") ;
			}
		}

		/// <summary>
		/// Gets the model for the specified group.
		/// </summary>
		/// <param name="id">The id</param>
		/// <returns>The model</returns>
		public static GroupEditModel GetById(Guid id) {
			var m = new GroupEditModel() ;

			using (var db = new Data.PiranhaContext()) {
				var groups = db.Groups.Where(g => g.Id != id).OrderBy(g => g.Name).Select(g => new Group() { Id = g.Id, Name = g.Name }).ToList() ;
				groups.Insert(0, new Group() { Name = "" }) ;
				m.Groups = new SelectList(groups, "Id", "Name") ;
				m.Group = db.Groups.Where(g => g.Id == id).Single() ;
				m.Members = db.Users.Where(u => u.GroupId == id).ToList() ;
			}
			return m ;
		}

		/// <summary>
		/// Saves the access and all related information.
		/// </summary>
		/// <returns>Weather the action succeeded or not.</returns>
		public bool SaveAll() {
			using (var db = new Data.PiranhaContext()) {
				Group.Attach(db) ;
				return db.SaveChanges() > 0 ;
			}
		}

		/// <summary>
		/// Deletes the access and all related information.
		/// </summary>
		/// <returns>Weather the action succeeded or not.</returns>
		public bool DeleteAll() {
			using (var db = new Data.PiranhaContext()) {
				Group.Attach(db, EntityState.Deleted) ;
				return db.SaveChanges() > 0 ;
			}
		}
	}
}
