using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Piranha.Entities
{
	public class Content : BaseEntity<Content>
	{
		#region Fields
		public string Name { get ; set ; }
		public string Filename { get ; set ; }
		public string Type { get ; set ; }
		public int Size { get ; set ; }
		public bool IsImage { get ; set ; }
		public int Width { get ; set ; }
		public int Height { get ; set ; }
		public string AltText { get ; set ; }
		public string Description { get ; set ; }
		#endregion
	}
}
