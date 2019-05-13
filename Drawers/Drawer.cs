using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintDesignPatterns.Drawers
{
    interface Drawer
    {
        void Draw(Graphics g, Pen pen, Rectangle rect, Pen highlightPen, bool isSelected);
        string ToString();
    }
}
