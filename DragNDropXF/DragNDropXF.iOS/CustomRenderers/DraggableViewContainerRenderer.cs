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
using Xamarin.Forms.Internals;

[assembly: ExportRenderer(typeof(DraggableViewContainer), typeof(DraggableContainerRenderer))]
namespace DragNDropXF.iOS.CustomRenderer
{
    class DraggableContainerRenderer : ViewRenderer<DraggableViewContainer, DraggableContaineriOS>
    {

        private DraggableContaineriOS _iOSContainer;

        protected override void OnElementChanged(ElementChangedEventArgs<DraggableViewContainer> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                // Initialize
                var frame = new CGRect(0, 0, 100, 100);
                _iOSContainer = new DraggableContaineriOS(frame);

                var formsDraggableContainer = Element;

                // Set the drop delegate 
                SetDropDelegates(_iOSContainer, formsDraggableContainer);


                SetupVisuals(_iOSContainer, formsDraggableContainer);



                SetNativeControl(_iOSContainer);
            }
        }

        private void SetupVisuals(DraggableContaineriOS iOSContainer, DraggableViewContainer formsDraggableContainer)
        {
            
           //_iOSContainer.BackgroundColor = formsDraggableContainer.BackgroundColor.ToUIColor();
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            var formsContainer = Element as DraggableViewContainer;

            //if (e.PropertyName.Equals(DraggableViewContainer.ChildrenProperty.PropertyName))
            //{
            //   // SyncChildren(_iOSContainer, formsContainer);
            //}
        }


        private void SyncChildren(DraggableContaineriOS iOSDraggableContainer, DraggableViewContainer formsDraggableContainer)
        {


            //_iOSContainer.RemoveAllChildren();

            //formsDraggableContainer.Children.ForEach(child =>
            //    {
            //        _iOSContainer.AddSubview(new DraggableViewiOS()
            //        {
            //            BackgroundColor = child.BackgroundColor.ToUIColor(),
            //        });
            //    });


        }


        private void SetDropDelegates(DraggableContaineriOS iOSDraggableContainer, DraggableViewContainer formsDraggableContainer)
        {
            iOSDraggableContainer.ResolveDropOperation = delegate (DraggableContaineriOS containerThatReceivedTheDropOperation, UIDropInteraction dropInteraction, IUIDropSession dropSession)
            {
                // called on SessionDidUpdate ios method

                // Inform that the drag and drop has been updated
                formsDraggableContainer.DragUpdated?.Invoke(new DragNDropEventArgs(
                        dvc: formsDraggableContainer,
                        action: DragNDropEventArgs.DragAction.Updated,
                        x: (float)dropInteraction.View.Center.X,
                        y: (float)dropInteraction.View.Center.Y)
                        );


                // Ask the Xamarin.Forms control for an answer for this drop proposal

                var formsResponse = formsDraggableContainer.DropProposal?.Invoke(new DragNDropEventArgs(
                        dvc: formsDraggableContainer,
                        action: DragNDropEventArgs.DragAction.Updated,
                        x: (float)dropInteraction.View.Center.X,
                        y: (float)dropInteraction.View.Center.Y)
                        );

                UIDropOperation response;

                switch (formsResponse)
                {
                    case DropOperation.Cancel:
                        response = UIDropOperation.Cancel;
                        break;
                    case DropOperation.Copy:
                        response = UIDropOperation.Copy;
                        break;
                    case DropOperation.Forbidden:
                        response = UIDropOperation.Forbidden;
                        break;
                    case DropOperation.Move:
                        response = UIDropOperation.Move;
                        break;
                    default:
                        response = UIDropOperation.Forbidden;
                        break;
                }

                return response;

            };

            iOSDraggableContainer.PerformDropOperation = delegate (UIDropInteraction dropInteraction, IUIDropSession dropSession)
            {
                formsDraggableContainer.DragUpdated?.Invoke(new DragNDropEventArgs(
                        dvc: formsDraggableContainer,
                        action: DragNDropEventArgs.DragAction.Dropped,
                        x: (float)dropInteraction.View?.Center.X,
                        y: (float)dropInteraction.View?.Center.Y)
                        );
            };
        }


    }
}