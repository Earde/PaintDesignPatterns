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
        // Singleton pattern
        private static EllipsDrawer drawer = null;
        public static EllipsDrawer Instance {
            get {
                if (drawer == null) drawer = new EllipsDrawer();
                return drawer;
            }
        }

        private EllipsDrawer() { }

        public void Draw(Graphics g, Pen pen, Rectangle rect, Pen highlightPen, bool isSelected)
        {
            g.DrawEllipse(pen, rect);
            if (isSelected)
            {
                g.DrawEllipse(highlightPen, new Rectangle(rect.Left - 3, rect.Top - 3, rect.Width + 6, rect.Height + 6));
            }
        }

        public override string ToString()
        {
            return "ellipse";
        }
    }
}
