using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using DragNDropXF.Events;
using Xamarin.Forms;

namespace DragNDropXF.CustomControl
{
    public class DraggableViewContainer : Xamarin.Forms.StackLayout
    {
        #region Delegates

        public delegate bool DragUpdatedDelegate(DragNDropEventArgs dndEventArgs);
        public delegate DropOperation DropProposalDelegate(DragNDropEventArgs dndEventArgs);

        public DragUpdatedDelegate DragUpdated { get; set; }
        public DropProposalDelegate DropProposal { get; set; }

        #endregion

        //public static readonly BindableProperty ChildrenProperty = BindableProperty.Create(nameof(Children), typeof(ObservableCollection<DraggableView>), typeof(DraggableViewContainer));

        //public ObservableCollection<DraggableView> Children
        //{
        //    get => (ObservableCollection<DraggableView>)GetValue(ChildrenProperty);
        //    set => SetValue(ChildrenProperty, value);
        //}

        public DraggableViewContainer()
        {
            //Children = new ObservableCollection<DraggableView>();
            HeightRequest = 100;
            WidthRequest = 200; // It's not working, because you need to take it into account in the renderer .. ?
            Spacing = 10;
            Orientation = StackOrientation.Horizontal;

        }
    }


    public enum DropOperation
    {
        Cancel = 0,
        Forbidden = 1,
        Copy = 2,
        Move = 3
    }
}
