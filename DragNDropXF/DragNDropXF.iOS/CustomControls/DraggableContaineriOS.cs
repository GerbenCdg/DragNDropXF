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

        #region Delegates
        public delegate UIDropOperation DragUpdatedDelegate(DraggableContaineriOS containerThatReceivedTheDropOperation, UIDropInteraction dropInteraction, IUIDropSession dropSession);
        public delegate void PerfomDropDelegate(UIDropInteraction dropInteraction, IUIDropSession dropSession);
        #endregion

        #region Properties
        /// <summary>
        /// This is called when we need to know what you want to do with the object that is being hovered over the container
        /// </summary>
        public DragUpdatedDelegate ResolveDropOperation { get; set; }
        /// <summary>
        /// This is called when we want to perform the drop, once a has been allowed to do so.
        /// </summary>
        public PerfomDropDelegate PerformDropOperation { get; set; }

        /// <summary>
        /// The drop interaction charged of the drop operations in this container
        /// </summary>
        public UIDropInteraction DropInteraction { get; private set; }
        #endregion

        #region Constructor
        public DraggableContaineriOS()
        {
            Initialize();
        }

        public DraggableContaineriOS(CGRect bounds) : base(bounds)
        {
            Initialize();
        }

        internal void RemoveAllChildren()
        {
            foreach(var subview in Subviews)
            {
                subview.RemoveFromSuperview();
            }
        }

        void Initialize()
        {
            SetupDrop();
        }

        private void SetupDrop()
        {
            UserInteractionEnabled = true;
            DropInteraction = new UIDropInteraction(this);
            AddInteraction(DropInteraction);
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
            if (ResolveDropOperation == null)
            {
                throw new NullReferenceException("The ResolveDropOperation delegate must be defined before calling the 'SessionDidUpdate' method");
            }



            return new UIDropProposal(ResolveDropOperation(this, interaction, session));
        }

        [Export("dropInteraction:performDrop:")]
        public virtual void PerformDrop(UIDropInteraction interaction, IUIDropSession session)
        {
            if (PerformDropOperation == null)
            {
                throw new NullReferenceException("The PerformDropOperation delegate must be defined before calling the 'PerformDrop' method");
            }
            PerformDropOperation(interaction, session);
        }
        #endregion
    }
}