using System;
using System.Globalization;
using Foundation;
using MvvmCross.Platform.Converters;
using UIKit;

namespace MediaListingApp.Converters
{
    public class ImageUrlToUIImageValueConverter : IMvxValueConverter
    {
        public static ImageUrlToUIImageValueConverter Instance = new ImageUrlToUIImageValueConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string imageUrl = (string)value;

            if (string.IsNullOrWhiteSpace(imageUrl))
                return null;
            
            var url = new NSUrl(imageUrl);
            var data = NSData.FromUrl(url);
            return UIImage.LoadFromData(data);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
