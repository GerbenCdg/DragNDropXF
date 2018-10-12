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
    class AndroidDraggableViewContainer : LinearLayout, View.IOnDragListener
    {
        public delegate bool DragUpdatedDelegate(View v, DragAction action, float x, float y);
        public DragUpdatedDelegate DragUpdated { get; set; }

        public bool OnDrag(View v, DragEvent e)
        {
            return DragUpdated.Invoke(v, e.Action, e.GetX(), e.GetY());
        }

        public AndroidDraggableViewContainer(Context context) : base(context)
        {
            LayoutInflater.FromContext(context).Inflate(Resource.Layout.DraggableView, this);
            SetOnDragListener(this);

            ChildViewAdded += OnChildViewAdded;
        }

        private void OnChildViewAdded(object sender, ChildViewAddedEventArgs e)
        {
            
        }
    }
}