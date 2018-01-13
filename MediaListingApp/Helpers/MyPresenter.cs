using System;
using CoreAnimation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.iOS.Views;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.iOS.Views.Presenters.Attributes;
using UIKit;

namespace MediaListingApp.Helpers
{
    public class AnimatedRootPresentationAttribute : MvxRootPresentationAttribute
    {
    }

    public class MyPresenter : MvxIosViewPresenter
    {
        public MyPresenter(IUIApplicationDelegate appDelegate, UIWindow window)
            : base(appDelegate, window)
        {
        }

        public override void RegisterAttributeTypes()
        {
            base.RegisterAttributeTypes();

            AttributeTypesToActionsDictionary.Add(typeof(AnimatedRootPresentationAttribute),
                new MvxPresentationAttributeAction
                {
                    ShowAction = (viewType, attribute, request) =>
                    {
                        var viewController = (UIViewController)this.CreateViewControllerFor(request);
                        ShowAnimatedRootViewController(viewController, (AnimatedRootPresentationAttribute)attribute, request);
                    },
                    CloseAction = (viewModel, attribute) => CloseAnimatedRootViewController(viewModel, (AnimatedRootPresentationAttribute)attribute)
                });
        }

        private void ShowAnimatedRootViewController(
            UIViewController viewController,
            AnimatedRootPresentationAttribute attribute,
            MvxViewModelRequest request)
        {
            ShowRootViewController(viewController, attribute, request);
            AddAnimation();
        }

        private void AddAnimation()
        {
            var transition = new CATransition
            {
                Duration = 0.3,
                Type = CAAnimation.TransitionMoveIn,
                Subtype = CAAnimation.TransitionFromRight
            };

            _window.RootViewController.View.Layer.AddAnimation(transition, null);
        }

        protected virtual bool CloseAnimatedRootViewController(IMvxViewModel viewModel, AnimatedRootPresentationAttribute attribute)
        {
            return CloseRootViewController(viewModel, attribute);
        }
    }
}
