using System;
using System.Drawing;
using System.Linq;
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
            SetupDrag();
        }

        private void SetupDrag()
        {
            UserInteractionEnabled = true;
            _UIDragInteraction = new UIDragInteraction(this);
            AddInteraction(_UIDragInteraction);
            _UIDragInteraction.Enabled = true;

            SetupDragDelay();
        }

        private void SetupDragDelay()
        {

            UILongPressGestureRecognizer longPressGesture = new UILongPressGestureRecognizer();

            GestureRecognizers?.ToList().ForEach(gesture =>
            {
                var x = gesture as UILongPressGestureRecognizer;
                if (x != null)
                {
                    longPressGesture = x;
                }
            });

            longPressGesture.MinimumPressDuration = 0.0;
        }

        #region IUIDragInteractionDelegate
        public virtual UIDragItem[] GetItemsForBeginningSession(UIDragInteraction interaction, IUIDragSession session)
        {
            // no data needed since we directly have access to the view thanks to the OnTouched event
            // so we put stub data so that the provider doesn't provide null objects

            var provider = new NSItemProvider(new NSString(""));

            var item = new UIDragItem(provider)
            {
                LocalObject = new NSNumber(true)
            };

            return new UIDragItem[] { item };

            //return new UIDragItem[] { new UIDragItem(default(NSItemProvider)) };
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