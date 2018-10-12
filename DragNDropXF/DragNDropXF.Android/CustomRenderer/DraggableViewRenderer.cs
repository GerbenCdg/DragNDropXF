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

[assembly: ExportRenderer(typeof(DraggableView), typeof(DraggableViewRenderer))]
namespace DragNDropXF.Droid.CustomRenderer
{
    class DraggableViewRenderer : ViewRenderer<DraggableView, AndroidDraggableView>
    {
        private readonly Context _context;

        public DraggableViewRenderer(Context context) : base(context)
        {
            _context = context;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<DraggableView> e)
        {
            if (Control == null)
            {
                var view = new AndroidDraggableView(_context);

                view.OnTouched += (s, evt) =>
                {
                    Element.RaiseOnTouched(Element);
                };

                SetNativeControl(view);
            }
        }
                

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
        }

    }
}