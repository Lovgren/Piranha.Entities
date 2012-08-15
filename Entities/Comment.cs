using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace Piranha.Entities
{
	/// <summary>
	/// The comment entity. Comments can be attached to any object.
	/// </summary>
	public class Comment : BaseEntity
	{
		#region Properties
		/// <summary>
		/// Gets/sets the comment id.
		/// </summary>
		public Guid Id { get ; set ; }

		/// <summary>
		/// Gets/sets the optional id of the parent comment.
		/// </summary>
		public Guid? ParentId { get ; set ; }

		/// <summary>
		/// Gets/sets weather the comment is approved or not.
		/// </summary>
		public bool IsApproved { get ; set ; }

		/// <summary>
		/// Gets/sets the optional comment title.
		/// </summary>
		public string Title { get ; set ; }

		/// <summary>
		/// Gets/sets the comment body.
		/// </summary>
		public string Body { get ; set ; }

		/// <summary>
		/// Gets/sets the date the comment was created.
		/// </summary>
		public DateTime Created { get ; set ; }

		/// <summary>
		/// Gets/sets the date the comment was approved.
		/// </summary>
		public DateTime Approved { get ; set ; }

		/// <summary>
		/// Gets/sets the optional id of the user who created the comment.
		/// </summary>
		public Guid? CreatedById { get ; set ; }

		/// <summary>
		/// Gets/sets the optional name of the user who created the comment.
		/// </summary>
		public string CreatedByName { get ; set ; }

		/// <summary>
		/// Gets/sets the optional email of the user who created the comment.
		/// </summary>
		public string CreatedByEmail { get ; set ; }

		/// <summary>
		/// Gets/sets the optional id of the user who approved the comment.
		/// </summary>
		public Guid? ApprovedById { get ; set ; }
		#endregion

		#region Navigation properties
		/// <summary>
		/// Gets/sets the optional user who created the comment.
		/// </summary>
		public User CreatedBy { get ; set ; }

		/// <summary>
		/// Gets/sets the optinal user who approved the comment.
		/// </summary>
		public User ApprovedBy { get ; set ; }
		#endregion

		#region Events
		/// <summary>
		/// Saves the current entity.
		/// </summary>
		/// <param name="state">The current entity state</param>
		public override void OnSave(System.Data.EntityState state) {
			var user = HttpContext.Current.User;

			if (state == EntityState.Added) {
				if (Id == Guid.Empty)
					Id = Guid.NewGuid() ;
				Created = DateTime.Now ;
				if (user.Identity.IsAuthenticated)
					CreatedById = new Guid(user.Identity.Name) ;
			}
		}
		#endregion
	}
}
