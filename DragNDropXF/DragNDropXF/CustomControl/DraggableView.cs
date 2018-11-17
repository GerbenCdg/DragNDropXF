using DragNDropXF.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace DragNDropXF.CustomControl
{
    public class DraggableView : Xamarin.Forms.View
    {
        #region Events

        public event EventHandler<OnTouchedEventArgs> OnTouched;    

        public void RaiseOnTouched(OnTouchedEventArgs args)
        {
            OnTouched?.Invoke(this, args);
        }

        #endregion
               
    }
}
