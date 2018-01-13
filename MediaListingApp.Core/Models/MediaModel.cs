using System;
using MvvmCross.Core.ViewModels;

namespace MediaListingApp.Core.Models
{
	public class MediaModel
	{
		public string Title { get; set; }
		public int Year { get; set; }
		public string Description { get; set; }
		public ImageModel Images { get; set; } 

        public string Image { get; set; }
        public string LandscapeImage { get; set; }

        public IMvxCommand TapCommand { get; set; }
	}
}
