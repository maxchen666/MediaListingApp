using System;
using System.Collections.Generic;
using System.Drawing;
using MediaListingApp.Core.Models;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace MediaListingApp.Views.Cells
{
    public class NormalTableViewCell: MvxTableViewCell
    {
        UILabel TitleLabel;
        UICollectionView CollectionView;

        public string Title
        {
            get { return TitleLabel.Text; }
            set { TitleLabel.Text = value; }
        }

        public NormalTableViewCell()
        {
            InitialiseSubviews();
            InitialiseBindings();
        }

        public NormalTableViewCell(IntPtr handle)
            : base(handle)
        {
            InitialiseSubviews();
            InitialiseBindings();
        }

        private void InitialiseSubviews()
        {
            SelectionStyle = UITableViewCellSelectionStyle.None;

            nfloat width = Bounds.Width;
            TitleLabel = new UILabel();
            TitleLabel.Font = UIFont.FromName("AvenirNextCondensed-Regular", 18f);
            TitleLabel.Text = "";
            TitleLabel.TextColor = UIColor.FromWhiteAlpha(0.1f, 1f);
            ContentView.AddSubview(TitleLabel);
            TitleLabel.TranslatesAutoresizingMaskIntoConstraints = false;
            NSLayoutConstraint.Create(TitleLabel, NSLayoutAttribute.Left, NSLayoutRelation.Equal, ContentView, NSLayoutAttribute.Left, 1.0f, 10f).Active = true;
            NSLayoutConstraint.Create(TitleLabel, NSLayoutAttribute.Top, NSLayoutRelation.Equal, ContentView, NSLayoutAttribute.Top, 1.0f, 2f).Active = true;
            NSLayoutConstraint.Create(TitleLabel, NSLayoutAttribute.Width, NSLayoutRelation.Equal, ContentView, NSLayoutAttribute.Width, 1.0f, -20f).Active = true;
            NSLayoutConstraint.Create(TitleLabel, NSLayoutAttribute.Height, NSLayoutRelation.Equal, ContentView, NSLayoutAttribute.Height, 0f, 20f).Active = true;

            UICollectionViewLayout layout = new UICollectionViewFlowLayout()
            {
                ItemSize = new SizeF(117, 191),
                ScrollDirection = UICollectionViewScrollDirection.Horizontal
            };

            CollectionView = new UICollectionView(new RectangleF(0f, 24f, (float)width, 191f), layout);
            CollectionView.BackgroundColor = UIColor.Clear;
            ContentView.AddSubview(CollectionView);
        }

        private void InitialiseBindings()
        {
            this.DelayBind(() =>
            {
                this.CreateBinding().For((cell) => cell.Title).To((CategoryModel category) => category.Category).Apply();
                var source = new CustomCollectionViewSource(CollectionView)
                {
                };

                this.AddBindings(new Dictionary<object, string>
                {
                    {source, "ItemsSource Items"}
                });
                CollectionView.Source = source;
                CollectionView.ReloadData();
            });
        }
    }
}
