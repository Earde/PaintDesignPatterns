using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintDesignPatterns.Drawers
{
    class RectangleDrawer : Drawer
    {
        public void Draw(Graphics g, Pen pen, Rectangle rect)
        {
            g.DrawRectangle(pen, rect);
        }

        public override string ToString()
        {
            return "rectangle";
        }
    }
}
