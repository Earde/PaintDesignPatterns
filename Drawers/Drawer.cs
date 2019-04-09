using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintDesignPatterns
{
    abstract class Drawer
    {
        public abstract void Draw(Graphics g, Pen pen, Rectangle rect);
        public abstract override string ToString();
    }
}
