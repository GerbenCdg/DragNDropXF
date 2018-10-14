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
    class AndroidDraggableView : LinearLayout, View.IOnTouchListener
    {
        public event EventHandler<OnTouchedEventArgs> OnTouched;

        public bool OnTouch(View v, MotionEvent e)
        {
            var clipData = new ClipData("Label", new string[] { ClipDescription.MimetypeTextPlain }, new ClipData.Item("Label"));
            v.StartDragAndDrop(clipData, new View.DragShadowBuilder(v), null, 0);

            OnTouched?.Invoke(this, new OnTouchedEventArgs(v));

            return true;
        }

        public AndroidDraggableView(Context context) : base(context)
        {
            LayoutInflater.FromContext(context).Inflate(Resource.Layout.DraggableView, this);
            SetOnTouchListener(this);            
        }

       
    }
}