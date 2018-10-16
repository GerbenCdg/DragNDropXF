using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


using DragNDropXF.CustomControl;

using DragNDropXF.iOS.CustomControls;
using DragNDropXF.Events;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using CoreGraphics;
using DragNDropXF.iOS.CustomRenderer;
using UIKit;

[assembly: ExportRenderer(typeof(DraggableViewContainer), typeof(DraggableContainerRenderer))]
namespace DragNDropXF.iOS.CustomRenderer
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

        private void SetDragNDropDelegate(DraggableContaineriOS iOSDraggableContainer, DraggableViewContainer xamarinDraggableContainer)
        {
            iOSDraggableContainer.ResolveDropOperation = delegate (DraggableContaineriOS containerThatReceivedTheDropOperation, UIDropInteraction dropInteraction, IUIDropSession dropSession) {

                //var response = xamarinDraggableContainer.DragUpdated(new DragNDropEventArgs(Element,));

                return UIDropOperation.Copy;
            };

            // iOSDraggableContainer.PerformDrop 
        }


    }
}