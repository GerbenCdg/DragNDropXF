using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Text;

namespace DragNDropXF
{
    public interface ITouchable
    {
        void OnTouch(object sender, SKTouchEventArgs e);
    }
}