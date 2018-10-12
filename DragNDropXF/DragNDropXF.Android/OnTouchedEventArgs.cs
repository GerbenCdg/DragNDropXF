using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace DragNDropXF.Droid
{
    public class OnTouchedEventArgs : EventArgs
    {
        public View View { get; private set; }

        public OnTouchedEventArgs(View v)
        {
            View = v;
        }
    }
}