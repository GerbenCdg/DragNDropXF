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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _Width = App.Current.MainPage.Width;
            _Height = App.Current.MainPage.Height;

            DraggableViewContainer.DragUpdated = delegate (DragNDropEventArgs e)
            {
                Debug.WriteLine($"X : {e.X} Y : {e.Y}");
                XamlDraggableView.TranslationX = e.X/1080 * _Width;
                XamlDraggableView.TranslationY = e.Y/1920 * _Height ;

                return true;
            };

        }
    }
}
