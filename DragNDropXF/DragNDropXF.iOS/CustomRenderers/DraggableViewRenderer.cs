using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using CoreGraphics;
using DragNDropXF.CustomControl;
using DragNDropXF.Droid.CustomRenderer;
using DragNDropXF.iOS.CustomControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(DraggableView), typeof(DraggableViewRenderer))]
namespace DragNDropXF.Droid.CustomRenderer
{
    class DraggableViewRenderer : ViewRenderer<DraggableView, DraggableViewiOS>
    {

        protected override void OnElementChanged(ElementChangedEventArgs<DraggableView> e)
        {
            // If the control is null, we initialize it
            if (Control == null)
            {
                    
                // Initialize the draggable view
                var frame = new CGRect(0, 0, 50, 50);
                var view = new DraggableViewiOS(frame);

                // Setup Events
                view.OnTouched += View_OnTouched;

                SetNativeControl(view);
            }
        }

        private void View_OnTouched(object sender, iOS.CustomControls.OnTouchedEventArgs e)
        {
            var args = new DragNDropXF.OnTouchedEventArgs(Element);
            Element.RaiseOnTouched(args);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }

    }
}