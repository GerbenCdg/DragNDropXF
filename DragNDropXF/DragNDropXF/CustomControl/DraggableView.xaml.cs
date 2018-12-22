using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DragNDropXF.CustomControl
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DraggableView : SKCanvasView
    {
        #region Events

        public event EventHandler<OnTouchedEventArgs> OnTouched;
        public void RaiseOnTouched()
        {
            OnTouched?.Invoke(this, new OnTouchedEventArgs(this));
        }

        #endregion

        public DraggableView()
        {
            InitializeComponent();
           
            Debug.WriteLine($"View Height : {Height} Width : { Width}");
            Debug.WriteLine($"Canvas Height : {CanvasSize.Height} Width : { CanvasSize.Width}");
        }

        private SKPaint _paint = new SKPaint
        {
            Color = SKColors.SkyBlue,
            Style = SKPaintStyle.Fill,
            StrokeWidth = 1
        };

        private void SKCanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKCanvas canvas = e.Surface.Canvas;

            int width = e.Info.Width;
            int height = e.Info.Height;

            Console.WriteLine($"Canvas : width :{width}, height: {height}");
            Console.WriteLine($"View : width : {Width}, height: {Height}");
            Console.WriteLine($"View (requested) : width : {WidthRequest}, height: {HeightRequest}");

            canvas.Translate(width / 2, height / 2);
            canvas.Scale(width / 800f, height / 600f);

            SKPath path = new SKPath();
            path.AddRect(new SKRect(-400, -300, 400, 300));
            path.AddArc(new SKRect(-50, -350, 50, -250), 180, -180);
            path.AddArc(new SKRect(-50, 250, 50, 350), 180, -180);

            canvas.DrawPath(path, _paint);
        }

    }
}