using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piranha.Entities
{
	/// <summary>
	/// User entity.
	/// </summary>
	public class User
	{
		#region Fields
		/// <summary>
		/// Gets/sets the id.
		/// </summary>
		public Guid Id { get ; set ; }

		/// <summary>
		/// Gets/sets the group id.
		/// </summary>
		public Guid? GroupId { get ; set ; }

		/// <summary>
		/// Gets/sets the login name.
		/// </summary>
		public string Login { get ; set ; }

		/// <summary>
		/// Gets/sets the login password.
		/// </summary>
		public string Password { get ; set ; }

		/// <summary>
		/// Gets/sets the firstname.
		/// </summary>
		public string Firstname { get ; set ; }

		/// <summary>
		/// Gets/sets the surname.
		/// </summary>
		public string Surname { get ; set ; }

		/// <summary>
		/// Gets/sets the email address.
		/// </summary>
		public string Email { get ; set ; }

		/// <summary>
		/// Gets/sets the culture.
		/// </summary>
		public string Culture { get ; set ; }

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
		public Guid? CreatedById { get ; set ; }

		/// <summary>
		/// Gets/sets the id of the user who updated the entity.
		/// </summary>
		public Guid? UpdatedById { get ; set ; }
		#endregion

		#region Relations
		/// <summary>
		/// Gets/sets the user group.
		/// </summary>
		public Group Group { get ; set ; }
		#endregion
	}
}
