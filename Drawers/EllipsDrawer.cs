using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintDesignPatterns.Drawers
{
    class EllipsDrawer : Drawer
    {
        public void Draw(Graphics g, Pen pen, Rectangle rect)
        {
            g.DrawEllipse(pen, rect);
        }

        public override string ToString()
        {
            return "ellipse";
        }
    }
}
