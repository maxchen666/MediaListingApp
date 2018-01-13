using System;
using CoreGraphics;
using Foundation;
using MvvmCross.Binding.iOS.Views;
using UIKit;

namespace MediaListingApp.Views.Cells
{
    public class CustomCollectionViewSource : MvxCollectionViewSource
    {
        private static readonly NSString CollectionCellIdentifier = new NSString("CollectionCell");

        public CustomCollectionViewSource(UICollectionView collectionView)
            :base(collectionView)
        {
            collectionView.RegisterClassForCell(typeof(CustomUICollectionViewCell), CollectionCellIdentifier);
        }

        protected override UICollectionViewCell GetOrCreateCellFor(UICollectionView collectionView, NSIndexPath indexPath, object item)
        {
            return (UICollectionViewCell)CollectionView.DequeueReusableCell(CollectionCellIdentifier, indexPath);
        }
    }
}
