using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piranha.Entities
{
	/// <summary>
	/// The core user entity.
	/// </summary>
	public class User : BaseEntity
	{
		#region Properties
		/// <summary>
		/// Gets/sets the unique user id.
		/// </summary>
		public Guid Id { get ; set ; }

		/// <summary>
		/// Gets/sets the id of the group to which the user belong.
		/// </summary>
		public Guid? GroupId { get ; set ; }

		/// <summary>
		/// Gets/sets the unique login name.
		/// </summary>
		public string Login { get ; set ; }

		/// <summary>
		/// Gets/sets the SHA2 encrypted password.
		/// </summary>
		public string Password { get ; set ; }

		/// <summary>
		/// Gets/sets the firstname of the user.
		/// </summary>
		public string Firstname { get ; set ; }

		/// <summary>
		/// Gets/sets the surname of the user.
		/// </summary>
		public string Surname { get ; set ; }

		/// <summary>
		/// Gets/sets the surname of the user.
		/// </summary>
		public string Email { get ; set ; }

		/// <summary>
		/// Gets/sets the users prefered culture.
		/// </summary>
		public string Culture { get ; set ; }

		/// <summary>
		/// Gets/sets the date the user was initially created.
		/// </summary>
		public DateTime Created { get ; set ; }

		/// <summary>
		/// Gets/sets the date the user was last updated.
		/// </summary>
		public DateTime Updated { get ; set ; }

		/// <summary>
		/// Gets/sets the id of the user who initially created the user.
		/// </summary>
		public Guid? CreatedById { get ; set ; }

		/// <summary>
		/// Gets/sets the id of the user who last updated the user.
		/// </summary>
		public Guid? UpdatedById { get ; set ; }
		#endregion

		#region Relationships
		/// <summary>
		/// Gets/sets the group to which the user belong.
		/// </summary>
		public Group Group { get ; set ; }
		#endregion
	}
}
