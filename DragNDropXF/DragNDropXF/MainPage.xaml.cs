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

            _Width = Application.Current.MainPage.Width;
            _Height = Application.Current.MainPage.Height;

            dvc1.DragUpdated = HandleDrag;
            dvc1.DropProposal += HandleDropProposal;
            //dvc2.DragUpdated = HandleDrag;
            //dvc3.DragUpdated = HandleDrag;
            //dvc4.DragUpdated = HandleDrag;
            //dvc5.DragUpdated = HandleDrag;
        }

        private DropOperation HandleDropProposal(DragNDropEventArgs e)
        {
            // this is called while there's a view hovering the container

            // define whether we want to allow or forbid the drop in this container using the arguments
            Debug.WriteLine($"X : {e.X} Y : {e.Y}");
            return DropOperation.Copy; // testing
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
            if (v != null)
            {

                var dragContainer = v.Parent as DraggableViewContainer;

                if (dragContainer != null)
                {
                    dragContainer.Children.Remove(v);
                }
                else
                {
                    var container = v.Parent as Layout<View>;
                    container.Children.Remove(v);
                }

                hovered.Children.Add(v);
            }

        }
    }
}
