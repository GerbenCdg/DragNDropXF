﻿using DragNDropXF.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace DragNDropXF.CustomControl
{
    public class DraggableView : Xamarin.Forms.ContentView
    {
        #region Events

        public event EventHandler<OnTouchedEventArgs> OnTouched;
        public void RaiseOnTouched()
        {
            OnTouched?.Invoke(this, new OnTouchedEventArgs(this));
        }

        #endregion
               
    }
}