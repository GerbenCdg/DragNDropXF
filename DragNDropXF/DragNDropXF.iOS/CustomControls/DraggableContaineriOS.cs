using System;
using System.Drawing;

using CoreGraphics;
using Foundation;
using UIKit;

namespace DragNDropXF.iOS.CustomControls
{
    [Register("DraggableContaineriOS")]
    public class DraggableContaineriOS : UIView, IUIDropInteractionDelegate
    {

        public delegate UIDropOperation DragUpdatedDelegate(DraggableContaineriOS containerThatReceivedTheDropOperation);

        public DragUpdatedDelegate ResolveOperation { get; set; }

        #region Constructor
        public DraggableContaineriOS()
        {
            Initialize();
        }

        public DraggableContaineriOS(CGRect bounds) : base(bounds)
        {
            Initialize();
        }

        void Initialize()
        {
            BackgroundColor = UIColor.Yellow;
        }
        #endregion


        #region IUIDropInteractionDelegate

        /// <summary>
        /// Returns the visual proposal to make to the user on this container
        /// </summary>
        /// <param name="interaction"></param>
        /// <param name="session"></param>
        /// <returns></returns>
        [Export("dropInteraction:sessionDidUpdate:")]
        public virtual UIDropProposal SessionDidUpdate(UIDropInteraction interaction, IUIDropSession session)
        {
            return new UIDropProposal(ResolveOperation(this));
        }

        [Export("dropInteraction:performDrop:")]
        public virtual void PerformDrop(UIDropInteraction interaction, IUIDropSession session)
        {

        }
        #endregion
    }
}