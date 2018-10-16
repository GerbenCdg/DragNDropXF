using System;
using System.Drawing;

using CoreGraphics;
using Foundation;
using UIKit;

namespace DragNDropXF.iOS.CustomControls
{
    /// <summary>
    /// Represents a native iOS Draggable View
    /// </summary>
    [Register("DraggableViewiOS")]
    public class DraggableViewiOS : UIView, IUIDragInteractionDelegate
    {
        #region Events
        public event EventHandler<OnTouchedEventArgs> OnTouched;
        #endregion

        #region Private Fields
        private UIDragInteraction _UIDragInteraction;
        #endregion

        #region Constructors

        public DraggableViewiOS()
        {
            Initialize();
        }

        public DraggableViewiOS(IntPtr handle) : base(handle)
        {
        }

        public DraggableViewiOS(CGRect bounds) : base(bounds)
        {
            Initialize();
        }

        public DraggableViewiOS(NSCoder coder) : base(coder)
        {
            Initialize();
        }
        #endregion

        #region Utility Methods
        public override void AwakeFromNib()
        {
            base.AwakeFromNib();

            Initialize();
        }

        void Initialize()
        {
            UserInteractionEnabled = true;
            _UIDragInteraction = new UIDragInteraction(this);
        }

        #region IUIDragInteractionDelegate
        public virtual UIDragItem[] GetItemsForBeginningSession(UIDragInteraction interaction, IUIDragSession session)
        {
            // no data needed since we directly have access to the view thanks to the OnTouched event
            return new UIDragItem[] { new UIDragItem(default(NSItemProvider)) };
        }


        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);
            OnTouched?.Invoke(this, new OnTouchedEventArgs(this));
        }
        #endregion


        #endregion

    }

}