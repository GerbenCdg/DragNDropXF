using DragNDropXF.CustomControl;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DragNDropXF
{
    public class OnTouchedEventArgs : EventArgs
    {
        public DraggableView View { get; private set; }

        public OnTouchedEventArgs(DraggableView v)
        {
            View = v;
        }
    }
}
