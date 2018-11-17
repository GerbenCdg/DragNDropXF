using DragNDropXF.CustomControl;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DragNDropXF.Events
{
    public class DragNDropEventArgs : EventArgs
    {
        public DraggableViewContainer HoveredView { get; private set; }
        //public DraggableView DraggedView { get; private set; }
        //TODO solve problem : we dont have access to the xamarin dragged view

        public DragAction Action { get; private set; }

        public float X { get; private set; }
        public float Y { get; private set; }

        public DragNDropEventArgs(DraggableViewContainer dvc, /*DraggableView v,*/ DragAction action, float x, float y)
        {
            HoveredView = dvc;
          //  DraggedView = v;
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
