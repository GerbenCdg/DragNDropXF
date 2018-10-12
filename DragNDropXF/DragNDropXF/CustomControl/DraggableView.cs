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
        public void RaiseOnTouched(Xamarin.Forms.View view)
        {
            OnTouched?.Invoke(this, new OnTouchedEventArgs(view));
        }

        #endregion
               
    }
}
