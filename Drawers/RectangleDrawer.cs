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
        private static RectangleDrawer drawer = null;
        public static RectangleDrawer Instance {
            get {
                if (drawer == null) drawer = new RectangleDrawer();
                return drawer;
            }
        }

        private RectangleDrawer() { }

        public void Draw(Graphics g, Pen pen, Rectangle rect, Pen highlightPen, bool isSelected)
        {
            g.DrawRectangle(pen, rect);
            if (isSelected)
            {
                g.DrawRectangle(highlightPen, new Rectangle(rect.Left - 3, rect.Top - 3, rect.Width + 6, rect.Height + 6));
            }
        }

        public override string ToString()
        {
            return "rectangle";
        }
    }
}
