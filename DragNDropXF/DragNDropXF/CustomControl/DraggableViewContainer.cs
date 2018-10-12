using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using DragNDropXF.Events;
using Xamarin.Forms;

namespace DragNDropXF.CustomControl
{
    public class DraggableViewContainer : Xamarin.Forms.AbsoluteLayout
    {
        #region Delegates

        public delegate bool DragUpdatedDelegate(DragNDropEventArgs dndEventArgs);
        public DragUpdatedDelegate DragUpdated { get; set; }

        #endregion

        //public static readonly BindableProperty ChildrenProperty =
        //    BindableProperty.Create(nameof(Children), typeof(ObservableCollection<DraggableView>), typeof(DraggableViewContainer));

        //public ObservableCollection<DraggableView> Children
        //{
        //    get => (ObservableCollection<DraggableView>)GetValue(ChildrenProperty);
        //    set => SetValue(ChildrenProperty, value);
        //}

        //public DraggableViewContainer()
        //{
        //    Children = new ObservableCollection<DraggableView>();
        //}
    }
}
