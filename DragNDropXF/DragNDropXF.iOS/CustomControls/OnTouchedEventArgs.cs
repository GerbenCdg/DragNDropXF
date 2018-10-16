using System;
using UIKit;

namespace DragNDropXF.iOS.CustomControls
{
    public class OnTouchedEventArgs
    {

        public UIView View;

        public OnTouchedEventArgs(UIView view)
        {
            View = view;
        }
    }
}
