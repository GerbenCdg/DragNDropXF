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

        public delegate UIDropOperation DragUpdatedDelegate(DraggableContaineriOS containerThatReceivedTheDropOperation, UIDropInteraction dropInteraction, IUIDropSession dropSession);
        public delegate void PerfomDropDelegate(UIDropInteraction dropInteraction, IUIDropSession dropSession);

        public DragUpdatedDelegate ResolveDropOperation { get; set; }
        public PerfomDropDelegate PerformDropOperation { get; set; }

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
            if(ResolveDropOperation == null){
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