using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DragNDropXF.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScratchView : ContentView
    {
        public ScratchView()
        {
            InitializeComponent();
        }

        private SKPaint paint = new SKPaint { Color = SKColors.SkyBlue };
        SKPaint thinLinePaint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Black,
            StrokeWidth = 2
        };

        private void SKCanvasView_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            int width = e.Info.Width;
            int height = e.Info.Height;

            canvas.Translate(width / 2, height / 2);
            //DrawRect(canvas, 800, 600);
            //// canvas.DrawCircle(0, -300, 50, new SKPaint { Color = SKColors.White });
            //// canvas.DrawCircle(0, 300, 50, Paint);

            //canvas.Save();
            //canvas.Translate(0, -300);

            //canvas.Translate(0, 600);
            //path = new SKPath();
            //path.AddArc(new SKRect(-50, -50, 50, 50), 0, 360);
            //canvas.DrawPath(path, paint);

            //canvas.Restore();

            SKPath path = new SKPath();
            path.AddRect(new SKRect(-400, -300, 400, 300));
            path.AddArc(new SKRect(-50, -350, 50, -250), 180, -180);
            path.AddArc(new SKRect(-50, 250, 50, 350), 180, -180);

            canvas.DrawPath(path, paint);

        }

        private void DrawRect(SKCanvas canvas, int width, int height)
        {
            canvas.DrawRect(new SKRect(-width / 2, -height / 2, width / 2, height / 2), paint);
        }
    }
}