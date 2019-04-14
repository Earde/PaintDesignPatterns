using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaintDesignPatterns.Shapes;

namespace PaintDesignPatterns.Commands
{
    class AddMove : ICommand
    {
        private List<Shape> movedShapes;
        private Point distance;

        public AddMove(List<Shape> movedShapes, Point distance)
        {
            this.movedShapes = movedShapes;
            this.distance = distance;
        }

        public void Execute(ref Context context)
        {
            foreach (Shape s in movedShapes)
            {
                s.Move(distance.X, distance.Y);
            }
            context.drawPanel.Invalidate();
        }

        public void Undo(ref Context context)
        {
            foreach (Shape s in movedShapes)
            {
                s.Move(-distance.X, -distance.Y);
            }
            context.drawPanel.Invalidate();
        }
    }
}
