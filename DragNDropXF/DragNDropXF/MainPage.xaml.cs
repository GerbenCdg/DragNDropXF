using DragNDropXF.CustomControl;
using DragNDropXF.Events;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DragNDropXF
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private double _Width = 0;
        private double _Height = 0;
        private DraggableView LastDraggedDV { get; set; }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _Width = App.Current.MainPage.Width;
            _Height = App.Current.MainPage.Height;

            //dvc1.DragUpdated = HandleDrag;
            //dvc2.DragUpdated = HandleDrag;
            //dvc3.DragUpdated = HandleDrag;
            //dvc4.DragUpdated = HandleDrag;
            //dvc5.DragUpdated = HandleDrag;

            //XamlDraggableView.OnTouched += XamlDraggableView_OnTouched;
        }

        private void XamlDraggableView_OnTouched(object sender, OnTouchedEventArgs e)
        {
            LastDraggedDV = e.View;
        }

        private bool HandleDrag(DragNDropEventArgs e)
        {
            Debug.WriteLine($"X : {e.X} Y : {e.Y}");
            // XamlDraggableView.TranslationX = e.X / 1080 * _Width;
            // XamlDraggableView.TranslationY = e.Y / 1920 * _Height; 

            switch (e.Action)
            {
                case DragNDropEventArgs.DragAction.Started:
                    return true;
                case DragNDropEventArgs.DragAction.Entered:
                    return true;
                case DragNDropEventArgs.DragAction.Updated:
                    return true;
                case DragNDropEventArgs.DragAction.Exited:
                    return true;
                case DragNDropEventArgs.DragAction.Ended:
                    return true;
                case DragNDropEventArgs.DragAction.Dropped:
                    SetViewInContainer(e.HoveredView);
                    return true;
                default:
                    return true;
            }
        }

        private void SetViewInContainer(DraggableViewContainer hovered)
        {
            var v = LastDraggedDV;

            ((DraggableViewContainer)v.Parent).Children.Remove(v);
            hovered.Children.Add(v);
        }
    }
}
