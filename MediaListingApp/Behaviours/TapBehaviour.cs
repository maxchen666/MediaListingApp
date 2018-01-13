using System;
using System.Windows.Input;
using UIKit;

namespace MediaListingApp.Behaviours
{
    public class TapBehaviour
    {
        public ICommand Command { get; set; }

        public TapBehaviour(UIView view)
        {
            var tap = new UITapGestureRecognizer(() =>
            {
                var command = Command;
                if (command != null)
                    command.Execute(null);
            });
            view.AddGestureRecognizer(tap);
        }
    }

    public static class BehaviourExtensions
    {
        public static TapBehaviour Tap(this UIView view)
        {
            return new TapBehaviour(view);
        }
    }
}
