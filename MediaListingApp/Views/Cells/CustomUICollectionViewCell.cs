using System;
using System.Drawing;
using MediaListingApp.Converters;
using MediaListingApp.Core.Models;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.Platform.Converters;
using MediaListingApp.Behaviours;
using UIKit;

namespace MediaListingApp.Views.Cells
{
    public class CustomUICollectionViewCell: MvxCollectionViewCell
    {
        UILabel TitleLabel;
        UIImageView MainImage;
        private readonly MvxImageViewLoader _loader;

        public string Title
        {
            get { return TitleLabel.Text; }
            set { TitleLabel.Text = value; }
        }

        public CustomUICollectionViewCell()
        {
            InitialiseSubviews();
            InitialiseBindings();
        }

        public CustomUICollectionViewCell(IntPtr handle) : base(handle)
        {
            _loader = new MvxImageViewLoader(() => MainImage);
            InitialiseSubviews();
            InitialiseBindings();
        }
       
        private void InitialiseSubviews()
        {
            nfloat width = Bounds.Width;
            nfloat height = Bounds.Height;
            TitleLabel = new UILabel();
            TitleLabel.Font = UIFont.FromName("AvenirNextCondensed-Regular", 14f);
            TitleLabel.Text = "";
            TitleLabel.TextColor = UIColor.FromWhiteAlpha(0.1f, 1f);
            ContentView.AddSubview(TitleLabel);
            TitleLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            NSLayoutConstraint.Create(TitleLabel, NSLayoutAttribute.Left, NSLayoutRelation.Equal, ContentView, NSLayoutAttribute.Left, 1.0f, 10f).Active = true;
            NSLayoutConstraint.Create(TitleLabel, NSLayoutAttribute.Top, NSLayoutRelation.Equal, ContentView, NSLayoutAttribute.Bottom, 1.0f, -20f).Active = true;
            NSLayoutConstraint.Create(TitleLabel, NSLayoutAttribute.Width, NSLayoutRelation.Equal, ContentView, NSLayoutAttribute.Width, 1.0f, -20f).Active = true;
            NSLayoutConstraint.Create(TitleLabel, NSLayoutAttribute.Height, NSLayoutRelation.Equal, ContentView, NSLayoutAttribute.Height, 0f, 20f).Active = true;


            MainImage = new UIImageView();
            MainImage.ContentMode = UIViewContentMode.ScaleAspectFill;
            MainImage.Layer.CornerRadius = 4;
            MainImage.Layer.MasksToBounds = true;
            ContentView.AddSubview(MainImage);
            MainImage.TranslatesAutoresizingMaskIntoConstraints = false;
            NSLayoutConstraint.Create(MainImage, NSLayoutAttribute.Left, NSLayoutRelation.Equal, ContentView, NSLayoutAttribute.Left, 1.0f, 0f).Active = true;
            NSLayoutConstraint.Create(MainImage, NSLayoutAttribute.Top, NSLayoutRelation.Equal, ContentView, NSLayoutAttribute.Top, 1.0f, 0f).Active = true;
            NSLayoutConstraint.Create(MainImage, NSLayoutAttribute.Width, NSLayoutRelation.Equal, ContentView, NSLayoutAttribute.Width, 1.0f, 0f).Active = true;
            NSLayoutConstraint.Create(MainImage, NSLayoutAttribute.Height, NSLayoutRelation.Equal, ContentView, NSLayoutAttribute.Height, 1.0f, -20f).Active = true;
        }

        private void InitialiseBindings()
        {
            this.DelayBind(() =>
            {
                this.CreateBinding().For((cell) => cell.Title).To((MediaModel media) => media.Title).Apply();
                //this.CreateBinding(MainImage).For((iv) => iv.Image).To((MediaModel media) => media.Image).WithConversion<ImageUrlToUIImageValueConverter>(ImageUrlToUIImageValueConverter.Instance).Apply();
                this.CreateBinding(_loader).To((MediaModel media) => media.Image).Apply();
                this.CreateBinding(this.Tap()).For((iv) => iv.Command).To((MediaModel media) => media.TapCommand).Apply();
            });
        }
    }
}
