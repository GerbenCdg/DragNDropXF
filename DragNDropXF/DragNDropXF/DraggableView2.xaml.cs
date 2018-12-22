﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkiaSharp;
using SkiaSharp.Views.Forms;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DragNDropXF
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DraggableView2 : SKCanvasView, ITouchable, ICloneable
    {
        public ITouchable Touchable { get; set; }

        #region Xaml Fields
        public readonly BindableProperty SKPaintProperty = 
            BindableProperty.Create(
                nameof(SKPaint),
                typeof(SKPaint),
                typeof(DraggableView2),
                new SKPaint {
                    Color = SKColors.SkyBlue,
                    /*Style = SKPaintStyle.StrokeAndFill,
                    StrokeWidth = 1*/
                },
                BindingMode.TwoWay
             );

        public SKPaint SKPaint
        {
            get => (SKPaint)GetValue(SKPaintProperty);
            set => SetValue(SKPaintProperty, value);
        }

        //public readonly BindableProperty SKPaintColorProperty =
        //    BindableProperty.Create(
        //        nameof(SKColor),
        //        typeof(SKColor),
        //        typeof(DraggableView2),
        //        SKColors.AliceBlue
        //    );

        //public SKColor SKColor
        //{
        //    get => (SKColor)GetValue(SKPaintProperty);
        //    set => SetValue(SKPaintProperty, value);
        //}

        #endregion

        public DraggableView2()
        {
            InitializeComponent();
            EnableTouchEvents = true;
            Touchable = this;

            WidthRequest = 300;
            HeightRequest = 200;
        }

        private void DraggableView2_Touch(object sender, SKTouchEventArgs e)
        {
            Touchable.OnTouch(sender, e);
        }
        
        private void SKCanvasView_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKCanvas canvas = e.Surface.Canvas;

            int width = e.Info.Width;
            int height = e.Info.Height;

            Console.WriteLine($"Canvas : width :{width}, height: {height}");
            Console.WriteLine($"View : width : {Width}, height: {Height}");
            Console.WriteLine($"View (requested) : width : {WidthRequest}, height: {HeightRequest}");

            canvas.Clear(SKColors.Transparent);

            canvas.Translate(width / 2, height / 2);
            canvas.Scale(width / 800f, height / 600f);

            SKPath path = new SKPath();
            path.AddRect(new SKRect(-400, -300, 400, 300));
            path.AddArc(new SKRect(-50, -350, 50, -250), 180, -180);
            path.AddArc(new SKRect(-50, 250, 50, 350), 180, -180);

            canvas.DrawPath(path, SKPaint);

            #region exampleCode
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
            #endregion
        }

        private DraggableView2 DraggedView { get; set; }
        private View GhostView { get; set; }

        private double Dx { get; set; }
        private double Dy { get; set; }

        public void OnTouch(object sender, SKTouchEventArgs e)
        {
            //Console.WriteLine($"X: {e.Location.X} Y: {e.Location.Y}");
            float X = e.Location.X;
            float Y = e.Location.Y;

            switch (e.ActionType)
            {
                case SKTouchAction.Entered:
                    Console.WriteLine("Entered");
                    break;

                case SKTouchAction.Pressed:
                    DraggedView = sender as DraggableView2;
                    GhostView = (View)DraggedView.Clone();

                    ((Layout<View>)Parent.Parent).Children.Add(GhostView);
                    AbsoluteLayout.SetLayoutFlags(GhostView, AbsoluteLayoutFlags.PositionProportional);
                    Dx = X / 3 - GhostView.X - DraggedView.X;
                    Dy = Y / 3 - GhostView.Y - DraggedView.Y;
                    Console.WriteLine("Pressed");
                    break;

                case SKTouchAction.Moved:
                    GhostView.TranslationX = X / 3 - GhostView.X - Dx;
                    GhostView.TranslationY = Y / 3 - GhostView.Y - Dy;
                    //Console.WriteLine("Moved");
                    break;

                case SKTouchAction.Released:
                    ((AbsoluteLayout)Parent.Parent).Children.Remove(GhostView);
                    Console.WriteLine("Released");
                    break;
                case SKTouchAction.Cancelled:
                    Console.WriteLine("Cancelled");
                    break;

                case SKTouchAction.Exited:
                    Console.WriteLine("Cancelled");
                    break;
            }
            e.Handled = true;

        }

        public object Clone()
        {
            return new DraggableView2()
            {
                Scale = Scale,
                EnableTouchEvents = false,
                WidthRequest = WidthRequest,
                HeightRequest = HeightRequest,
                Touchable = null
            };
        }
    }
}