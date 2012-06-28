using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piranha.Entities
{
	/// <summary>
	/// The region entity
	/// </summary>
	public class Region : StandardEntity<Region>
	{
		#region Properties
		/// <summary>
		/// Gets/sets weather this is a draft or not
		/// </summary>
		public bool IsDraft { get ; set ; }

		/// <summary>
		/// Gets/sets the page id.
		/// </summary>
		public Guid PageId { get ; set ; }

		/// <summary>
		/// Gets/sets weather the page is a draft or not.
		/// </summary>
		public bool IsPageDraft { get ; set ; }

		/// <summary>
		/// Gets/sets the region name.
		/// </summary>
		public string Name { get ; set ; }

		/// <summary>
		/// Gets/sets the region body.
		/// </summary>
		public string Body { get ; set ; }
		#endregion

		#region Navigation properties
		/// <summary>
		/// Gets/sets the page this region is related to.
		/// </summary>
		public Page Page { get ; set ; }
		#endregion
	}
}
