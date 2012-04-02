using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piranha.Entities
{
	public class Upload
	{
		#region Fields
		public Guid Id { get ; set ; }
		public Guid ParentId { get ; set ; }
		public string Filename { get ; set ; }
		public string Type { get ; set ; }
		public DateTime Created { get ; set ; }
		public Guid CreatedById { get ; set ; }
		#endregion

		#region Associations
		public User CreatedBy { get ; set ; }
		#endregion
	}
}
