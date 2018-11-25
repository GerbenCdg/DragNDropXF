using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using DragNDropXF;

using SKNativeView = SkiaSharp.Views.Android.SKCanvasView;

[assembly: ExportRenderer(typeof(SKCanvasStackLayout), typeof(DragNDropXF.Droid.CustomRenderers.SKCanvasStackLayoutRenderer))]

namespace DragNDropXF.Droid.CustomRenderers
{

    public class SKCanvasStackLayoutRenderer : SKCanvasViewRendererBase<SKCanvasStackLayout, SKNativeView>
    {

        public SKCanvasStackLayoutRenderer(Context context) : base(context)
        {
        }

        [Obsolete("This constructor is obsolete as of version 2.5")]
        public SKCanvasStackLayoutRenderer() : base()
        {

        }

    }

}