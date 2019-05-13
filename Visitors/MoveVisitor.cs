using PaintDesignPatterns.Shapes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaintDesignPatterns.Visitors
{
    class MoveVisitor : IVisitor
    {
        Point movement;

        public MoveVisitor(int dx, int dy)
        {
            movement = new Point(dx, dy);
        }

        public void Visit(Shape shape)
        {
            if (shape.IsSelected)
            {
                shape.Move(movement.X, movement.Y);
            }
        }
    }
}
