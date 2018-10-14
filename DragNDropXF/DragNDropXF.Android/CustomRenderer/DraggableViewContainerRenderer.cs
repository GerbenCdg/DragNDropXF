using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DragNDropXF.CustomControl;
using DragNDropXF.Droid.CustomRenderer;
using DragNDropXF.Droid.Views;
using DragNDropXF.Events;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(DraggableViewContainer), typeof(DraggableViewContainerRenderer))]
namespace DragNDropXF.Droid.CustomRenderer
{
    class DraggableViewContainerRenderer : ViewRenderer<DraggableViewContainer, AndroidDraggableViewContainer>
    {
        private readonly Context _context;

        public DraggableViewContainerRenderer(Context context) : base(context)
        {
            _context = Context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<DraggableViewContainer> e)
        {
            base.OnElementChanged(e);

            if (Control == null)
            {
                var androidDvc = new AndroidDraggableViewContainer(_context);
                var dvc = Element;

                SetDragNDropDelegate(androidDvc, dvc);

                SetNativeControl(androidDvc);
            }
        }

        private void SetDragNDropDelegate(AndroidDraggableViewContainer androidDvc, DraggableViewContainer dvc)
        {
            androidDvc.DragUpdated = delegate (Android.Views.View v, DragAction androidAction, float x, float y)
            {
                DragNDropEventArgs.DragAction action = DragNDropEventArgs.DragAction.Updated;

                switch (androidAction)
                {
                    case DragAction.Drop:
                        action = DragNDropEventArgs.DragAction.Dropped;
                        break;
                    case DragAction.Ended:
                        action = DragNDropEventArgs.DragAction.Ended;
                        break;
                    case DragAction.Entered:
                        action = DragNDropEventArgs.DragAction.Entered;
                        break;
                    case DragAction.Exited:
                        action = DragNDropEventArgs.DragAction.Exited;
                        break;
                    case DragAction.Location:
                        action = DragNDropEventArgs.DragAction.Updated;
                        break;
                    case DragAction.Started:
                        action = DragNDropEventArgs.DragAction.Started;
                        break;
                    default:
                        break;
                }

                if (dvc.DragUpdated == null)
                {
                    throw new NullReferenceException("DragUpdated delegate must be set on the Xamarin.Forms draggableView !");
                }
                return dvc.DragUpdated.Invoke(new DragNDropEventArgs(dvc, action, x, y));
            };
        }


        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }
    }
}