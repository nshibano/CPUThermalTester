using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace CPUCoolerTester
{
    class BlankControl : Control
    {
        protected override void OnPaintBackground(PaintEventArgs ev)
        {
            if (DesignMode)
            {
                var g = ev.Graphics;
                g.FillRectangle(Brushes.Black, g.VisibleClipBounds);
            }
        }
    }
}