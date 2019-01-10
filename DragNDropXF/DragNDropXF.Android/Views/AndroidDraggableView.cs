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

namespace DragNDropXF.Droid.Views
{
    class AndroidDraggableView : View, View.IOnTouchListener
    {
        public event EventHandler<OnTouchedEventArgs> OnTouched;

        public bool OnTouch(View v, MotionEvent e)
        {
            var shadow = new View.DragShadowBuilder(v);
            shadow.View.SetMinimumHeight(100);
            shadow.View.SetMinimumWidth(100);

            var clipData = new ClipData("Label", new string[] { ClipDescription.MimetypeTextPlain }, new ClipData.Item("Label"));
            v.StartDragAndDrop(clipData, shadow, null, 0);

            OnTouched?.Invoke(this, new OnTouchedEventArgs(v));

            return true;
        }

        public AndroidDraggableView(Context context) : base(context)
        {
            SetOnTouchListener(this);            
        }

    }
}