using System;
using System.Drawing;
using CoreGraphics;
using MediaListingApp.Converters;
using MediaListingApp.Core.Models;
using MediaListingApp.Core.ViewModels;
using MediaListingApp.Helpers;
using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using UIKit;

namespace MediaListingApp.Views
{
    [AnimatedRootPresentation(WrapInNavigationController = false)]
    public partial class DetailView: MvxViewController 
    {
        UIScrollView ContentView;
        UILabel TitleLabel;
        UIButton CloseButton;
        UIImageView MainImage;
        UILabel YearLabel;
        UILabel DescriptionLabel;

        public DetailView()
        {
        }

        public DetailView(IntPtr handle)
            : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            View.BackgroundColor = UIColor.White;

            float width = (float)View.Bounds.Width;
            ContentView = new UIScrollView();
            ContentView.BackgroundColor = UIColor.White;
            ContentView.ScrollEnabled = true;
            ContentView.ContentSize = new SizeF(width, 60f + (float)(width * 0.56) + 72f);
            View.Add(ContentView);
            ContentView.TranslatesAutoresizingMaskIntoConstraints = false;
            NSLayoutConstraint.Create(ContentView, NSLayoutAttribute.Left, NSLayoutRelation.Equal, View, NSLayoutAttribute.Left, 1.0f, 0f).Active = true;
            NSLayoutConstraint.Create(ContentView, NSLayoutAttribute.Top, NSLayoutRelation.Equal, View, NSLayoutAttribute.Top, 1.0f, 0f).Active = true;
            NSLayoutConstraint.Create(ContentView, NSLayoutAttribute.Right, NSLayoutRelation.Equal, View, NSLayoutAttribute.Right, 1.0f, 0f).Active = true;
            NSLayoutConstraint.Create(ContentView, NSLayoutAttribute.Bottom, NSLayoutRelation.Equal, View, NSLayoutAttribute.Bottom, 1.0f, 0f).Active = true;

            TitleLabel = new UILabel();
            TitleLabel.Font = UIFont.FromName("AvenirNextCondensed-Regular", 24f);
            TitleLabel.Text = "";
            TitleLabel.TextColor = UIColor.FromWhiteAlpha(0.1f, 1f);
            ContentView.AddSubview(TitleLabel);
            TitleLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            NSLayoutConstraint.Create(TitleLabel, NSLayoutAttribute.Left, NSLayoutRelation.Equal, ContentView, NSLayoutAttribute.Left, 1.0f, 10f).Active = true;
            NSLayoutConstraint.Create(TitleLabel, NSLayoutAttribute.Top, NSLayoutRelation.Equal, ContentView, NSLayoutAttribute.Top, 1.0f, 10f).Active = true;
            NSLayoutConstraint.Create(TitleLabel, NSLayoutAttribute.Width, NSLayoutRelation.Equal, ContentView, NSLayoutAttribute.Width, 1.0f, -50f).Active = true;
            NSLayoutConstraint.Create(TitleLabel, NSLayoutAttribute.Height, NSLayoutRelation.Equal, ContentView, NSLayoutAttribute.Height, 0f, 28f).Active = true;

            CloseButton = new UIButton(UIButtonType.Custom); 
            CloseButton.SetImage(UIImage.FromFile("close.png"), UIControlState.Normal);
            ContentView.AddSubview(CloseButton);
            CloseButton.TranslatesAutoresizingMaskIntoConstraints = false;
            NSLayoutConstraint.Create(CloseButton, NSLayoutAttribute.Left, NSLayoutRelation.Equal, TitleLabel, NSLayoutAttribute.Right, 1.0f, 10f).Active = true;
            NSLayoutConstraint.Create(CloseButton, NSLayoutAttribute.Top, NSLayoutRelation.Equal, ContentView, NSLayoutAttribute.Top, 1.0f, 12f).Active = true;
            NSLayoutConstraint.Create(CloseButton, NSLayoutAttribute.Width, NSLayoutRelation.Equal, ContentView, NSLayoutAttribute.Width, 0f, 20f).Active = true;
            NSLayoutConstraint.Create(CloseButton, NSLayoutAttribute.Height, NSLayoutRelation.Equal, ContentView, NSLayoutAttribute.Height, 0f, 20f).Active = true;

            MainImage = new UIImageView();
            MainImage.ContentMode = UIViewContentMode.ScaleAspectFill;
            ContentView.AddSubview(MainImage);
            MainImage.TranslatesAutoresizingMaskIntoConstraints = false;
            NSLayoutConstraint.Create(MainImage, NSLayoutAttribute.Left, NSLayoutRelation.Equal, ContentView, NSLayoutAttribute.Right, 1.0f, 0f).Active = true;
            NSLayoutConstraint.Create(MainImage, NSLayoutAttribute.Top, NSLayoutRelation.Equal, TitleLabel, NSLayoutAttribute.Bottom, 1.0f, 6f).Active = true;
            NSLayoutConstraint.Create(MainImage, NSLayoutAttribute.Width, NSLayoutRelation.Equal, ContentView, NSLayoutAttribute.Width, 1f, 0f).Active = true;
            NSLayoutConstraint.Create(MainImage, NSLayoutAttribute.Height, NSLayoutRelation.Equal, ContentView, NSLayoutAttribute.Width, 0.56f, 0f).Active = true;

            YearLabel = new UILabel();
            YearLabel.Font = UIFont.FromName("AvenirNextCondensed-Regular", 16f);
            YearLabel.Text = "";
            YearLabel.TextColor = UIColor.FromWhiteAlpha(0.1f, 1f);
            ContentView.AddSubview(YearLabel);
            YearLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            NSLayoutConstraint.Create(YearLabel, NSLayoutAttribute.Left, NSLayoutRelation.Equal, ContentView, NSLayoutAttribute.Right, 1.0f, 10f).Active = true;
            NSLayoutConstraint.Create(YearLabel, NSLayoutAttribute.Top, NSLayoutRelation.Equal, MainImage, NSLayoutAttribute.Bottom, 1.0f, 6f).Active = true;
            NSLayoutConstraint.Create(YearLabel, NSLayoutAttribute.Width, NSLayoutRelation.Equal, ContentView, NSLayoutAttribute.Width, 1f, 0f).Active = true;
            NSLayoutConstraint.Create(YearLabel, NSLayoutAttribute.Height, NSLayoutRelation.Equal, ContentView, NSLayoutAttribute.Height, 0f, 20f).Active = true;

            DescriptionLabel = new UILabel();
            DescriptionLabel.Font = UIFont.FromName("AvenirNextCondensed-Regular", 14f);
            DescriptionLabel.Text = "";
            DescriptionLabel.Lines = 0;
            DescriptionLabel.LineBreakMode = UILineBreakMode.WordWrap;
            DescriptionLabel.TextColor = UIColor.FromWhiteAlpha(0.1f, 1f);
            ContentView.AddSubview(DescriptionLabel);
            DescriptionLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            NSLayoutConstraint.Create(DescriptionLabel, NSLayoutAttribute.Left, NSLayoutRelation.Equal, ContentView, NSLayoutAttribute.Right, 1.0f, 10f).Active = true;
            NSLayoutConstraint.Create(DescriptionLabel, NSLayoutAttribute.Top, NSLayoutRelation.Equal, YearLabel, NSLayoutAttribute.Bottom, 1.0f, 6f).Active = true;
            NSLayoutConstraint.Create(DescriptionLabel, NSLayoutAttribute.Width, NSLayoutRelation.Equal, ContentView, NSLayoutAttribute.Width, 1f, 0f).Active = true;
            NSLayoutConstraint.Create(DescriptionLabel, NSLayoutAttribute.Height, NSLayoutRelation.LessThanOrEqual, ContentView, NSLayoutAttribute.Height, 0f, 60f).Active = true;

            // Binding
            var set = this.CreateBindingSet<DetailView, DetailViewModel>();
            set.Bind(TitleLabel).To(vm => vm.Media.Title);
            set.Bind(CloseButton).To(vm => vm.CloseCommand);
            set.Bind(MainImage).For((iv) => iv.Image).To(vm => vm.Media.LandscapeImage).WithConversion<ImageUrlToUIImageValueConverter>(ImageUrlToUIImageValueConverter.Instance);
            set.Bind(YearLabel).To(vm => vm.Media.Year);
            set.Bind(DescriptionLabel).To(vm => vm.Media.Description);
            set.Apply();
        }

        public override void ViewWillTransitionToSize(CGSize toSize, IUIViewControllerTransitionCoordinator coordinator)
        {
            base.ViewWillTransitionToSize(toSize, coordinator);

            coordinator.AnimateAlongsideTransition((obj) => {}, (obj) => {
                float width = (float)toSize.Width;
                ContentView.ContentSize = new SizeF(width, 60f + (float)(width * 0.56) + 72f);
            });

            View.LayoutIfNeeded();
        }
    }
}
