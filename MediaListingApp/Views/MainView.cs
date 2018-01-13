using System;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;
using MediaListingApp.Helpers;
using MediaListingApp.Views.Cells;
using MvvmCross.Binding.BindingContext;
using MvvmCross.Binding.iOS.Views;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters.Attributes;
using UIKit;

namespace MediaListingApp.Views
{
    [MvxRootPresentation(WrapInNavigationController = false)]
    public partial class MainView : MvxTableViewController
    {
        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            //TransitioningDelegate = new MyTransitioningDelegate();

            var source = new TableSource(TableView)
            {
                UseAnimations = true,
                AddAnimation = UITableViewRowAnimation.Left,
                RemoveAnimation = UITableViewRowAnimation.Right
            };

            this.AddBindings(new Dictionary<object, string>
                {
                    {source, "ItemsSource Categories"}
                });

            TableView.Source = source;
            TableView.ReloadData();

        }

        public override void ViewWillTransitionToSize(CGSize toSize, IUIViewControllerTransitionCoordinator coordinator)
        {
            base.ViewWillTransitionToSize(toSize, coordinator);
            View.LayoutIfNeeded();
            TableView.ReloadData();
        }

        public class TableSource : MvxTableViewSource
        {
            private static readonly NSString FeatureCellIdentifier = new NSString("FeatureCell");
            private static readonly NSString NormalCellIdentifier = new NSString("NormalCell");

            public TableSource(UITableView tableView)
                : base(tableView)
            {
                tableView.SeparatorStyle = UITableViewCellSeparatorStyle.None;
                tableView.RegisterClassForCellReuse(typeof(FeatureTableViewCell), FeatureCellIdentifier);
                tableView.RegisterClassForCellReuse(typeof(NormalTableViewCell), NormalCellIdentifier);
            }

            public override nfloat GetHeightForRow(UITableView tableView, NSIndexPath indexPath)
            {
                if (indexPath.Row == 0)
                {
                    return 24.0f + 113.0f + 16.0f;
                }
                else
                {
                    return 24.0f + 175.0f + 16.0f;
                }
            }

            protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, NSIndexPath indexPath,
                                                                  object item)
            {
                NSString cellIdentifier;
                if (indexPath.Row == 0)
                {
                    cellIdentifier = FeatureCellIdentifier;
                }
                else
                {
                    cellIdentifier = NormalCellIdentifier;
                }

                return (UITableViewCell)TableView.DequeueReusableCell(cellIdentifier, indexPath);
            }

        }
    }
}
