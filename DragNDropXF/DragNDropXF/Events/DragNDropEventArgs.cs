using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DragNDropXF.Events
{
    public class DragNDropEventArgs : EventArgs
    {
        public View View { get; private set; }
        public DragAction Action { get; private set; }

        public float X { get; private set; }
        public float Y { get; private set; }

        public DragNDropEventArgs(View v, DragAction action, float x, float y)
        {
            View = v;
            Action = action;
            X = x;
            Y = y;
        }

        public enum DragAction
        {
            Started,
            Entered,
            Updated,
            Exited,
            Ended,
            Dropped
        }
    }
}
