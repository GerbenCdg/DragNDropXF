using System;
using System.Drawing;

using CoreGraphics;
using Foundation;
using UIKit;

namespace DragNDropXF.iOS.CustomControls
{
    /// <summary>
    /// Represents a normal native iOS Draggable View
    /// </summary>
    [Register("DraggableViewiOS")]
    public class DraggableViewiOS : UIView, IUIDragInteractionDelegate
    {

        #region Private Fields
        private UIDropInteraction _UIDropInteraction;
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
            BackgroundColor = UIColor.Blue;
            UserInteractionEnabled = true;
            _UIDragInteraction = new UIDragInteraction(this);
        }

        #region IUIDragInteractionDelegate
        public virtual UIDragItem[] GetItemsForBeginningSession(UIDragInteraction interaction, IUIDragSession session)
        {
            return new UIDragItem[] { new UIDragItem(default(NSItemProvider)) };
        }

        public override void TouchesBegan(NSSet touches, UIEvent evt)
        {
            base.TouchesBegan(touches, evt);

        }
        #endregion


        #endregion

    }
}