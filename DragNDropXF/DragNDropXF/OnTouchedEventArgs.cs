using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DragNDropXF
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
