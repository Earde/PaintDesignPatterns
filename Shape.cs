using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintDesignPatterns
{
    abstract class Shape
    {
        public abstract void Draw(Graphics g);
        public abstract Rectangle GetCoordinates();
        public abstract bool Select(int x, int y);
        public abstract void Move(int dx, int dy);
        public abstract void Resize(int dx, int dy);
    }
}
