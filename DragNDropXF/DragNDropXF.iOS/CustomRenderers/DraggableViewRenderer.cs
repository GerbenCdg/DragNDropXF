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
            if (Control == null)
            {

                var frame = new CGRect(0, 0, 50, 50);
                var view = new DraggableViewiOS(frame);

                SetNativeControl(view);
            }
        }
                

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }

    }
}