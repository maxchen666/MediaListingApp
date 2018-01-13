using System;
using System.Collections.Generic;

namespace MediaListingApp.Core.Models
{
	public class CategoryModel
	{
		public string Category { get; set; }
		public List<MediaModel> Items { get; set; }

        public int Index { get; set; }
        public bool IsLandscaped { get; set; }
	}
}
