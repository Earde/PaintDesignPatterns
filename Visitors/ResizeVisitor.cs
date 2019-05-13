using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaintDesignPatterns.Shapes;

namespace PaintDesignPatterns.Visitors
{
    class ResizeVisitor : IVisitor
    {
        Point movement;

        public ResizeVisitor(int dx, int dy)
        {
            movement = new Point(dx, dy);
        }

        public void Visit(Shape shape)
        {
            if (shape.IsSelected)
            {
                shape.Resize(movement.X, movement.Y);
            }
        }
    }
}
