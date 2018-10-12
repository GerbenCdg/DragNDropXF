using Android.Runtime;
using Android.Views;
using System;

namespace DragNDropXF.Droid
{
    class DragNDropListener : Java.Lang.Object ,View.IOnDragListener
    {
        public delegate bool DragUpdatedDelegate(View v, DragAction action, float x, float y);
        public DragUpdatedDelegate DragUpdated { get; set; }

        public bool OnDrag(View v, DragEvent e)
        {
            return DragUpdated.Invoke(v, e.Action, e.GetX(), e.GetY());
        }

        public DragNDropListener()
        {
        }
    }
}