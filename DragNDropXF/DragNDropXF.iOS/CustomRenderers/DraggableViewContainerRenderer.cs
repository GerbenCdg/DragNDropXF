using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


using DragNDropXF.CustomControl;
using DragNDropXF.Droid.CustomRenderer;
using DragNDropXF.iOS.CustomControls;
using DragNDropXF.Events;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using CoreGraphics;

[assembly: ExportRenderer(typeof(DraggableViewContainer), typeof(DraggableContainerRenderer))]
namespace DragNDropXF.Droid.CustomRenderer
{
    class DraggableContainerRenderer : ViewRenderer<DraggableViewContainer, DraggableContaineriOS>
    {


        protected override void OnElementChanged(ElementChangedEventArgs<DraggableViewContainer> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                // Initialize
                var frame = new CGRect(0, 0, 100, 100);
                var iOSDraggableContainer = new DraggableContaineriOS(frame);
                var dvc = Element;

                SetDragNDropDelegate(iOSDraggableContainer, dvc);

                SetNativeControl(iOSDraggableContainer);
            }
        }

        private void SetDragNDropDelegate(DraggableContaineriOS androidDvc, DraggableViewContainer dvc)
        {
           
        }


    }
}