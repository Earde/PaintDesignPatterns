using PaintDesignPatterns.Visitors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintDesignPatterns.Shapes
{
    abstract class Shape
    {
        public Pen highlightPen = new Pen(Brushes.Blue, 3.0f);
        public Pen pen = new Pen(Brushes.Gray, 3.0f);

        public bool IsSelected { get; set; }
        public bool Select(int x, int y)
        {
            Rectangle rect = GetCoordinates();
            return rect.Left <= x && rect.Right >= x && rect.Top <= y && rect.Bottom >= y;
        }

        public abstract void Draw(Graphics g);
        public abstract Rectangle GetCoordinates();
        public abstract void Move(int dx, int dy);
        public abstract void Resize(int dx, int dy);
        public abstract override string ToString();
        public abstract void Accept(IVisitor visitor);
    }
}
